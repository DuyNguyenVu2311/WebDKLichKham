using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDKLichKham.Data;
using WebDKLichKham.Models;

namespace WebDKLichKham.Controllers;

public class PortalController : Controller
{
    private readonly ApplicationDbContext _context;

    public PortalController(ApplicationDbContext context)
    {
        _context = context;
    }

    // Màn hình dành cho Bệnh nhân / Khách hàng
    public async Task<IActionResult> PatientDashboard()
    {
        var role = Request.Cookies["PortalRole"];
        if (role != "Customer")
        {
            return RedirectToAction("Login", "Home");
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        PatientProfile? profile = null;

        if (!string.IsNullOrEmpty(userId))
        {
            profile = await _context.PatientProfiles
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.Doctor)
                        .ThenInclude(d => d!.SpecialtyInfo)
                .FirstOrDefaultAsync(p => p.UserId == userId);
        }

        if (profile == null)
        {
            // Không có hồ sơ — chuyển sang trang đặt lịch và thông báo
            TempData["InfoMessage"] = "Bạn chưa có hồ sơ bệnh nhân. Hãy đặt lịch khám để tạo hồ sơ, hoặc cập nhật thông tin tài khoản.";
            return View(new PatientProfile
            {
                FullName = User.Identity?.Name ?? "Bệnh nhân",
                Appointments = new List<Appointment>()
            });
        }

        return View(profile);
    }

    // Không gian làm việc dành cho Bác sĩ
    public IActionResult DoctorDashboard()
    {
        var role = Request.Cookies["PortalRole"];
        if (role != "Doctor")
        {
            return RedirectToAction("Login", "Home");
        }
        return View();
    }

    // Bảng điều khiển dành cho Quản lý / Admin
    public async Task<IActionResult> AdminDashboard()
    {
        var role = Request.Cookies["PortalRole"];
        if (role != "Admin")
        {
            return RedirectToAction("Login", "Home");
        }
        var doctors = await _context.Doctors.Include(d => d.SpecialtyInfo).ToListAsync();
        return View(doctors);
    }

    [HttpGet]
    public async Task<IActionResult> GetPatientRecords()
    {
        var role = Request.Cookies["PortalRole"];
        if (role != "Admin")
        {
            return Forbid();
        }

        var appointments = await _context.Appointments
            .OrderByDescending(a => a.CreatedAt)
            .Take(20)
            .Select(a => new
            {
                id = a.Id,
                patientName = a.PatientName,
                patientPhone = a.PatientPhone,
                patientGender = a.PatientGender ?? "Không rõ",
                dob = a.PatientDateOfBirth != null ? a.PatientDateOfBirth.Value.ToString("dd/MM/yyyy") : "Chưa cập nhật",
                appointmentDate = a.AppointmentDate.ToString("dd/MM/yyyy"),
                service = a.MedicalService ?? (a.Doctor != null && a.Doctor.SpecialtyInfo != null ? a.Doctor.SpecialtyInfo.Name : "Khám bệnh"),
                status = a.Status.ToString()
            })
            .ToListAsync();
            
        return Json(appointments);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSymptomStatus(int appointmentId, string status)
    {
        var role = Request.Cookies["PortalRole"];
        if (role != "Customer")
        {
            return Json(new { success = false, message = "Bạn không có quyền thực hiện chức năng này." });
        }

        if (status != "Giảm nhiều" && status != "Chưa giảm")
        {
            return Json(new { success = false, message = "Trạng thái không hợp lệ." });
        }

        if (appointmentId == 0)
        {
            return Json(new { success = true });
        }

        var appt = await _context.Appointments
            .Include(a => a.PatientProfile)
            .FirstOrDefaultAsync(a => a.Id == appointmentId);

        if (appt == null)
        {
            return Json(new { success = false, message = "Không tìm thấy lịch hẹn." });
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!string.IsNullOrEmpty(userId))
        {
            if (appt.PatientProfile == null || appt.PatientProfile.UserId != userId)
            {
                return Json(new { success = false, message = "Bạn không có quyền cập nhật lịch hẹn này." });
            }
        }
        else
        {
            return Json(new { success = false, message = "Vui lòng đăng nhập để thực hiện cập nhật này." });
        }

        appt.FollowUpSymptoms = status;
        await _context.SaveChangesAsync();

        return Json(new { success = true });
    }
}
