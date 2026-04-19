using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDKLichKham.Data;
using WebDKLichKham.Models;
using WebDKLichKham.Models.ViewModels;

namespace WebDKLichKham.Controllers;

[Authorize]
public class AppointmentsController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
        {
            return Challenge();
        }

        var profile = await _context.PatientProfiles
            .Include(p => p.Appointments)
            .ThenInclude(a => a.Doctor)
            .FirstOrDefaultAsync(p => p.UserId == userId);

        var appointments = profile?.Appointments
            .OrderBy(a => a.AppointmentDate)
            .ThenBy(a => a.StartTime)
            .Select(a => new AppointmentListItemViewModel
            {
                Id = a.Id,
                DoctorName = a.Doctor?.FullName ?? string.Empty,
                Specialty = a.Doctor?.Specialty ?? string.Empty,
                AppointmentDate = a.AppointmentDate,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                Status = a.Status,
                ReasonForVisit = a.ReasonForVisit
            })
            .ToList() ?? [];

        var today = DateTime.Today;
        var model = new MyAppointmentsViewModel
        {
            PatientName = profile?.FullName ?? User.Identity?.Name ?? "Bệnh nhân",
            UpcomingAppointments = appointments.Where(a => a.AppointmentDate >= today).ToList(),
            HistoryAppointments = appointments.Where(a => a.AppointmentDate < today).ToList()
        };

        return View(model);
    }

    public async Task<IActionResult> Create()
    {
        var model = new AppointmentBookingViewModel();
        await PopulateDoctorsAsync(model);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AppointmentBookingViewModel model)
    {
        await PopulateDoctorsAsync(model);

        if (model.EndTime <= model.StartTime)
        {
            ModelState.AddModelError(nameof(model.EndTime), "Giờ kết thúc phải sau giờ bắt đầu.");
        }

        var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == model.DoctorId && d.IsActive);
        if (doctor is null)
        {
            ModelState.AddModelError(nameof(model.DoctorId), "Bác sĩ không tồn tại hoặc đang ngừng hoạt động.");
        }

        var isDuplicate = await _context.Appointments.AnyAsync(a =>
            a.DoctorId == model.DoctorId &&
            a.AppointmentDate == model.AppointmentDate.Date &&
            a.StartTime == model.StartTime);

        if (isDuplicate)
        {
            ModelState.AddModelError(nameof(model.StartTime), "Khung giờ này đã được đặt. Vui lòng chọn giờ khác.");
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrWhiteSpace(userId))
        {
            return Challenge();
        }

        var profile = await _context.PatientProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
        if (profile is null)
        {
            profile = new PatientProfile
            {
                UserId = userId,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                MedicalHistory = model.MedicalHistory
            };
            _context.PatientProfiles.Add(profile);
        }
        else
        {
            profile.FullName = model.FullName;
            profile.PhoneNumber = model.PhoneNumber;
            profile.Address = model.Address;
            profile.MedicalHistory = model.MedicalHistory;
        }

        var appointment = new Appointment
        {
            DoctorId = model.DoctorId,
            PatientProfile = profile,
            AppointmentDate = model.AppointmentDate.Date,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            ReasonForVisit = model.ReasonForVisit,
            Status = AppointmentStatus.Pending
        };

        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Đặt lịch thành công. Phòng khám sẽ xác nhận lịch hẹn sớm.";
        return RedirectToAction(nameof(Index));
    }

    private async Task PopulateDoctorsAsync(AppointmentBookingViewModel model)
    {
        model.Doctors = await _context.Doctors
            .Where(d => d.IsActive)
            .OrderBy(d => d.Specialty)
            .ThenBy(d => d.FullName)
            .Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = $"{d.FullName} - {d.Specialty}"
            })
            .ToListAsync();
    }
}
