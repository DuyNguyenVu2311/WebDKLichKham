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
                Specialty = a.Doctor?.SpecialtyInfo?.Name ?? a.Doctor?.Specialty ?? string.Empty,
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

    [AllowAnonymous]
    public async Task<IActionResult> Create(int? specialtyId, int? doctorId, string? fullName, string? phoneNumber, DateTime? appointmentDate, string? facility, TimeSpan? startTime, TimeSpan? endTime, string? medicalService, string? passcode, string? confirmPasscode)
    {
        var model = new AppointmentBookingViewModel
        {
            SpecialtyId = specialtyId,
            FullName = fullName ?? string.Empty,
            PhoneNumber = phoneNumber ?? string.Empty,
            Facility = facility,
            AppointmentDate = appointmentDate ?? DateTime.Today.AddDays(1),
            MedicalService = medicalService,
            Passcode = passcode ?? string.Empty,
            ConfirmPasscode = confirmPasscode ?? string.Empty
        };

        if (startTime.HasValue)
        {
            model.StartTime = startTime.Value;
        }
        else
        {
            model.StartTime = new TimeSpan(7, 0, 0);
        }

        if (endTime.HasValue)
        {
            model.EndTime = endTime.Value;
        }
        else
        {
            model.EndTime = new TimeSpan(12, 0, 0);
        }

        // Nếu có doctorId, tự động điền facility từ bác sĩ
        if (doctorId.HasValue)
        {
            var doctorObj = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == doctorId.Value && d.IsActive);
            if (doctorObj != null)
            {
                model.DoctorId = doctorId.Value;
                if (string.IsNullOrEmpty(facility))
                {
                    if (doctorObj.Workplace != null && doctorObj.Workplace.Contains("Nhơn Trạch"))
                        model.Facility = "CS2";
                    else if (doctorObj.Workplace != null && doctorObj.Workplace.Contains("Thủ Đức"))
                        model.Facility = "CS1";
                }
            }
        }

        await PopulateReferenceDataAsync(model, specialtyId, model.Facility);

        if (User.Identity?.IsAuthenticated == true)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var profile = await _context.PatientProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
            if (profile is not null)
            {
                if (string.IsNullOrEmpty(model.FullName)) model.FullName = profile.FullName;
                if (string.IsNullOrEmpty(model.PhoneNumber)) model.PhoneNumber = profile.PhoneNumber ?? string.Empty;
                model.Address = profile.Address;
                model.MedicalHistory = profile.MedicalHistory;
                model.DateOfBirth = profile.DateOfBirth;
                model.Gender = profile.Gender;
                model.IdentityCard = profile.IdentityCard;
                model.InsuranceCode = profile.InsuranceCode;
                model.Occupation = profile.Occupation;
                model.Country = profile.Country ?? "Việt Nam";
                model.Province = profile.Province;
                model.District = profile.District;
                model.Ward = profile.Ward;
                model.StreetAddress = profile.StreetAddress;
            }
        }

        return View(model);
    }

    /// <summary>
    /// AJAX: Lấy danh sách bác sĩ theo chi nhánh và chuyên khoa
    /// </summary>
    [AllowAnonymous]
    public async Task<IActionResult> GetDoctors(string? facility, int? specialtyId)
    {
        var query = _context.Doctors.Where(d => d.IsActive).AsQueryable();

        if (!string.IsNullOrEmpty(facility))
        {
            if (facility == "CS1")
                query = query.Where(d => d.Workplace != null && d.Workplace.Contains("Thủ Đức"));
            else if (facility == "CS2")
                query = query.Where(d => d.Workplace != null && d.Workplace.Contains("Nhơn Trạch"));
        }

        if (specialtyId.HasValue)
            query = query.Where(d => d.SpecialtyId == specialtyId.Value);

        var doctors = await query
            .OrderBy(d => d.FullName)
            .Select(d => new { value = d.Id.ToString(), text = $"{d.FullName} - {d.Specialty}" })
            .ToListAsync();

        return Json(doctors);
    }

    /// <summary>
    /// AJAX: Lấy lịch làm việc của bác sĩ theo ngày
    /// </summary>
    [AllowAnonymous]
    public async Task<IActionResult> GetDoctorSchedule(int doctorId, DateTime date)
    {
        var schedules = await _context.DoctorSchedules
            .Where(s => s.DoctorId == doctorId && s.WorkDate.Date == date.Date)
            .OrderBy(s => s.StartTime)
            .Select(s => new
            {
                shift = s.Shift.ToString(),
                shiftName = s.Shift == ScheduleShift.Morning ? "Ca sáng" : s.Shift == ScheduleShift.Afternoon ? "Ca chiều" : "Ca tối",
                startTime = s.StartTime.ToString(@"hh\:mm"),
                endTime = s.EndTime.ToString(@"hh\:mm"),
                maxAppointments = s.MaxAppointments
            })
            .ToListAsync();

        var bookedSlots = await _context.Appointments
            .Where(a => a.DoctorId == doctorId && a.AppointmentDate.Date == date.Date && a.Status != AppointmentStatus.Cancelled)
            .Select(a => a.StartTime.ToString(@"hh\:mm"))
            .ToListAsync();

        return Json(new { schedules, bookedSlots });
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AppointmentBookingViewModel model)
    {
        await PopulateReferenceDataAsync(model, model.SpecialtyId, model.Facility);

        if (model.EndTime <= model.StartTime)
        {
            ModelState.AddModelError(nameof(model.EndTime), "Giờ kết thúc phải sau giờ bắt đầu.");
        }

        var appointmentDateTime = model.AppointmentDate.Date.Add(model.StartTime);
        if (appointmentDateTime < DateTime.Now)
        {
            ModelState.AddModelError(nameof(model.StartTime), "Thời gian khám chọn đã trôi qua. Vui lòng chọn khung giờ khác.");
        }

        Doctor? doctor = null;

        var isSpecializedService = model.MedicalService == "Khám sức khỏe tổng quát định kỳ" ||
                                   model.MedicalService == "Gói tầm soát sức khỏe Toàn diện (VIP)" ||
                                   model.MedicalService == "Xét nghiệm máu & Kiểm tra sinh hóa tại nhà";

        if (isSpecializedService)
        {
            // For specialized services, try to find any doctor scheduled at that time
            var availableDoctorId = await _context.DoctorSchedules
                .Where(s => s.WorkDate.Date == model.AppointmentDate.Date
                         && s.StartTime <= model.StartTime
                         && s.EndTime > model.StartTime)
                .Select(s => s.DoctorId)
                .FirstOrDefaultAsync();

            if (availableDoctorId != default)
            {
                doctor = await _context.Doctors
                    .Include(d => d.SpecialtyInfo)
                    .FirstOrDefaultAsync(d => d.Id == availableDoctorId);
            }

            // Fallback to first active doctor if no one is scheduled
            if (doctor is null)
            {
                doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.IsActive);
            }
        }
        else if (model.DoctorId.HasValue && model.DoctorId.Value > 0)
        {
            doctor = await _context.Doctors
                .Include(d => d.SpecialtyInfo)
                .FirstOrDefaultAsync(d => d.Id == model.DoctorId.Value && d.IsActive);

            if (doctor != null)
            {
                // Kiểm tra bác sĩ có lịch làm vào ngày được chọn không
                var hasSchedule = await _context.DoctorSchedules.AnyAsync(s =>
                    s.DoctorId == doctor.Id &&
                    s.WorkDate.Date == model.AppointmentDate.Date &&
                    s.StartTime <= model.StartTime &&
                    s.EndTime > model.StartTime);

                if (!hasSchedule)
                {
                    ModelState.AddModelError(nameof(model.StartTime),
                        "Bác sĩ này không có lịch làm việc vào ngày hoặc giờ bạn chọn. Vui lòng kiểm tra lại.");
                }
            }
        }
        else if (model.SpecialtyId.HasValue)
        {
            // Auto assign: tìm bác sĩ có ca làm phù hợp với ngày + giờ được chọn
            var facilityFilter = model.Facility;
            var candidateQuery = _context.Doctors
                .Include(d => d.SpecialtyInfo)
                .Where(d => d.SpecialtyId == model.SpecialtyId.Value && d.IsActive);

            if (facilityFilter == "CS1")
                candidateQuery = candidateQuery.Where(d => d.Workplace != null && d.Workplace.Contains("Thủ Đức"));
            else if (facilityFilter == "CS2")
                candidateQuery = candidateQuery.Where(d => d.Workplace != null && d.Workplace.Contains("Nhơn Trạch"));

            var candidateDoctorIds = await candidateQuery.Select(d => d.Id).ToListAsync();

            // Chọn bác sĩ có ca làm phù hợp + chưa có appointment trùng StartTime
            var availableDoctorId = await _context.DoctorSchedules
                .Where(s => candidateDoctorIds.Contains(s.DoctorId)
                         && s.WorkDate.Date == model.AppointmentDate.Date
                         && s.StartTime <= model.StartTime
                         && s.EndTime > model.StartTime)
                .Select(s => s.DoctorId)
                .Except(_context.Appointments
                    .Where(a => a.AppointmentDate == model.AppointmentDate.Date
                             && a.StartTime == model.StartTime
                             && a.Status != AppointmentStatus.Cancelled)
                    .Select(a => a.DoctorId))
                .OrderBy(_ => Guid.NewGuid())
                .FirstOrDefaultAsync();

            if (availableDoctorId != default)
            {
                doctor = await _context.Doctors
                    .Include(d => d.SpecialtyInfo)
                    .FirstOrDefaultAsync(d => d.Id == availableDoctorId);
            }
        }

        if (doctor is null && !(model.DoctorId.HasValue && model.DoctorId.Value > 0))
        {
            // Fallback rộng hơn: bất kỳ bác sĩ nào có ca làm phù hợp
            var availableDoctorId = await _context.DoctorSchedules
                .Where(s => s.WorkDate.Date == model.AppointmentDate.Date
                         && s.StartTime <= model.StartTime
                         && s.EndTime > model.StartTime)
                .Select(s => s.DoctorId)
                .Except(_context.Appointments
                    .Where(a => a.AppointmentDate == model.AppointmentDate.Date
                             && a.StartTime == model.StartTime
                             && a.Status != AppointmentStatus.Cancelled)
                    .Select(a => a.DoctorId))
                .OrderBy(_ => Guid.NewGuid())
                .FirstOrDefaultAsync();

            if (availableDoctorId != default)
            {
                doctor = await _context.Doctors
                    .Include(d => d.SpecialtyInfo)
                    .FirstOrDefaultAsync(d => d.Id == availableDoctorId);
            }
        }

        if (doctor is null)
        {
            ModelState.AddModelError(nameof(model.DoctorId), "Hệ thống hiện tại không có bác sĩ trực ca phù hợp cho ngày và giờ này. Vui lòng chọn khung giờ hoặc ngày khác.");
        }
        else
        {
            model.DoctorId = doctor.Id;
        }

        // Kiểm tra trùng số điện thoại + ngày + giờ
        var isDuplicate = await _context.Appointments.AnyAsync(a =>
            a.AppointmentDate == model.AppointmentDate.Date &&
            a.StartTime == model.StartTime &&
            a.PatientPhone == model.PhoneNumber &&
            a.Status != AppointmentStatus.Cancelled);

        if (isDuplicate)
        {
            ModelState.AddModelError(nameof(model.PhoneNumber), "Số điện thoại này đã có lịch hẹn ở khung giờ đã chọn.");
        }

        // Kiểm tra số lượng lịch hẹn trong ca không vượt quá MaxAppointments
        if (doctor != null)
        {
            var schedule = await _context.DoctorSchedules
                .FirstOrDefaultAsync(s =>
                    s.DoctorId == doctor.Id &&
                    s.WorkDate.Date == model.AppointmentDate.Date &&
                    s.StartTime <= model.StartTime &&
                    s.EndTime > model.StartTime);

            if (schedule != null)
            {
                var bookedCount = await _context.Appointments.CountAsync(a =>
                    a.DoctorId == doctor.Id &&
                    a.AppointmentDate == model.AppointmentDate.Date &&
                    a.StartTime >= schedule.StartTime &&
                    a.StartTime < schedule.EndTime &&
                    a.Status != AppointmentStatus.Cancelled);

                if (bookedCount >= schedule.MaxAppointments)
                {
                    ModelState.AddModelError(nameof(model.StartTime),
                        "Ca khám này đã đầy chỗ. Vui lòng chọn khung giờ hoặc ngày khác.");
                }
            }
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        PatientProfile? profile = null;
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        var fullAddress = model.Address;
        if (!string.IsNullOrWhiteSpace(model.StreetAddress) && !string.IsNullOrWhiteSpace(model.Province))
        {
            var parts = new List<string> { model.StreetAddress };
            if (!string.IsNullOrWhiteSpace(model.Ward)) parts.Add(model.Ward);
            if (!string.IsNullOrWhiteSpace(model.District)) parts.Add(model.District);
            parts.Add(model.Province);
            fullAddress = string.Join(", ", parts);
        }

        if (!string.IsNullOrWhiteSpace(userId))
        {
            profile = await _context.PatientProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
            if (profile is null)
            {
                profile = new PatientProfile
                {
                    UserId = userId,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    Address = fullAddress,
                    MedicalHistory = model.MedicalHistory,
                    DateOfBirth = model.DateOfBirth,
                    Gender = model.Gender,
                    IdentityCard = model.IdentityCard,
                    InsuranceCode = model.InsuranceCode,
                    Occupation = model.Occupation,
                    Country = model.Country,
                    Province = model.Province,
                    District = model.District,
                    Ward = model.Ward,
                    StreetAddress = model.StreetAddress
                };
                _context.PatientProfiles.Add(profile);
            }
            else
            {
                profile.FullName = model.FullName;
                profile.PhoneNumber = model.PhoneNumber;
                profile.Address = fullAddress;
                profile.MedicalHistory = model.MedicalHistory;
                profile.DateOfBirth = model.DateOfBirth;
                profile.Gender = model.Gender;
                profile.IdentityCard = model.IdentityCard;
                profile.InsuranceCode = model.InsuranceCode;
                profile.Occupation = model.Occupation;
                profile.Country = model.Country;
                profile.Province = model.Province;
                profile.District = model.District;
                profile.Ward = model.Ward;
                profile.StreetAddress = model.StreetAddress;
            }
        }

        var appointment = new Appointment
        {
            DoctorId = doctor!.Id,
            PatientProfile = profile,
            AppointmentCode = await GenerateAppointmentCodeAsync(),
            PatientName = model.FullName,
            PatientPhone = model.PhoneNumber,
            PatientEmail = model.Email,
            PatientDateOfBirth = model.DateOfBirth,
            PatientGender = model.Gender,
            AppointmentDate = model.AppointmentDate.Date,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            ReasonForVisit = model.ReasonForVisit,
            MedicalService = model.MedicalService,
            Notes = string.IsNullOrWhiteSpace(model.Facility) ? fullAddress : $"[{model.Facility}] {fullAddress}",
            Passcode = model.Passcode,
            Status = AppointmentStatus.Pending,
            IdentityCard = model.IdentityCard,
            InsuranceCode = model.InsuranceCode,
            Occupation = model.Occupation,
            Country = model.Country,
            Province = model.Province,
            District = model.District,
            Ward = model.Ward,
            StreetAddress = model.StreetAddress
        };

        _context.Appointments.Add(appointment);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
        {
            ModelState.AddModelError(string.Empty, "Khung giờ này vừa được đặt bởi người khác. Vui lòng chọn giờ hoặc bác sĩ khác.");
            await PopulateReferenceDataAsync(model, model.SpecialtyId, model.Facility);
            return View(model);
        }

        return RedirectToAction(nameof(Confirmation), new { id = appointment.Id });
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> QuickBook(string fullName, string phoneNumber, int? specialtyId, string? facility, DateTime? appointmentDate, string passcode, string confirmPasscode, TimeSpan? startTime, TimeSpan? endTime, string? medicalService)
    {
        if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(phoneNumber) || !appointmentDate.HasValue)
        {
            TempData["ErrorMessage"] = "Vui lòng điền đầy đủ họ tên, số điện thoại và ngày khám.";
            return RedirectToAction("Index", "Home");
        }

        if (string.IsNullOrWhiteSpace(passcode) || passcode.Length != 4 || !System.Text.RegularExpressions.Regex.IsMatch(passcode, @"^\d{4}$"))
        {
            TempData["ErrorMessage"] = "Mã xác nhận phải đúng 4 chữ số.";
            return RedirectToAction("Index", "Home");
        }

        if (passcode != confirmPasscode)
        {
            TempData["ErrorMessage"] = "Mã xác nhận nhập lại không khớp.";
            return RedirectToAction("Index", "Home");
        }

        if (appointmentDate.Value.Date < DateTime.Today)
        {
            TempData["ErrorMessage"] = "Ngày khám không được ở trong quá khứ.";
            return RedirectToAction("Index", "Home");
        }

        // Determine search start time
        var now = DateTime.Now;
        var startSearchTime = TimeSpan.FromHours(8); // Default search starts at 8:00 AM

        if (appointmentDate.Value.Date == DateTime.Today)
        {
            // If booking for today, must be in the future (at least 30 minutes from now)
            var minStartTime = now.TimeOfDay.Add(TimeSpan.FromMinutes(30));
            if (minStartTime > startSearchTime)
            {
                startSearchTime = minStartTime;
            }

            // If past 17:30, clinic is closed for today
            if (startSearchTime > new TimeSpan(17, 30, 0))
            {
                TempData["ErrorMessage"] = "Giờ làm việc hôm nay đã kết thúc. Vui lòng đặt lịch khám vào ngày mai hoặc ngày khác.";
                return RedirectToAction("Index", "Home");
            }
        }

        var candidateQuery = _context.Doctors.Where(d => d.IsActive).AsQueryable();

        if (specialtyId.HasValue)
            candidateQuery = candidateQuery.Where(d => d.SpecialtyId == specialtyId.Value);

        if (facility == "CS1")
            candidateQuery = candidateQuery.Where(d => d.Workplace != null && d.Workplace.Contains("Thủ Đức"));
        else if (facility == "CS2")
            candidateQuery = candidateQuery.Where(d => d.Workplace != null && d.Workplace.Contains("Nhơn Trạch"));

        var candidateIds = await candidateQuery.Select(d => d.Id).ToListAsync();

        // 1. Get schedules for candidates on selected date
        var schedules = await _context.DoctorSchedules
            .Where(s => candidateIds.Contains(s.DoctorId) && s.WorkDate.Date == appointmentDate.Value.Date)
            .OrderBy(s => s.StartTime)
            .ToListAsync();

        var appointments = await _context.Appointments
            .Where(a => candidateIds.Contains(a.DoctorId) 
                      && a.AppointmentDate == appointmentDate.Value.Date 
                      && a.Status != AppointmentStatus.Cancelled)
            .ToListAsync();

        Doctor? selectedDoctor = null;
        TimeSpan? selectedStartTime = null;
        TimeSpan? selectedEndTime = null;

        if (startTime.HasValue && endTime.HasValue)
        {
            // Try to find a doctor of this specialty/facility who has a schedule covering startTime and is not booked
            var availableDoctorId = await _context.DoctorSchedules
                .Where(s => candidateIds.Contains(s.DoctorId)
                         && s.WorkDate.Date == appointmentDate.Value.Date
                         && s.StartTime <= startTime.Value
                         && s.EndTime > startTime.Value)
                .Select(s => s.DoctorId)
                .Except(_context.Appointments
                    .Where(a => a.AppointmentDate == appointmentDate.Value.Date
                             && a.StartTime == startTime.Value
                             && a.Status != AppointmentStatus.Cancelled)
                    .Select(a => a.DoctorId))
                .OrderBy(_ => Guid.NewGuid())
                .FirstOrDefaultAsync();

            if (availableDoctorId != default)
            {
                selectedDoctor = await _context.Doctors
                    .Include(d => d.SpecialtyInfo)
                    .FirstOrDefaultAsync(d => d.Id == availableDoctorId);
                selectedStartTime = startTime;
                selectedEndTime = endTime;
            }

            if (selectedDoctor == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy bác sĩ chuyên khoa trống lịch cho khung giờ bạn chọn. Vui lòng chọn khung giờ khác.";
                return RedirectToAction("Index", "Home");
            }
        }
        else
        {
            // Find the earliest available slot chronologically
            foreach (var sched in schedules)
            {
                var tempStart = sched.StartTime;
                while (tempStart.Add(TimeSpan.FromMinutes(30)) <= sched.EndTime)
                {
                    var slotStart = tempStart;
                    var slotEnd = tempStart.Add(TimeSpan.FromMinutes(30));

                    if (slotStart >= startSearchTime)
                    {
                        var isSlotBooked = appointments.Any(a => 
                            a.DoctorId == sched.DoctorId && 
                            a.StartTime == slotStart);

                        if (!isSlotBooked)
                        {
                            selectedDoctor = await _context.Doctors
                                .Include(d => d.SpecialtyInfo)
                                .FirstOrDefaultAsync(d => d.Id == sched.DoctorId);
                            selectedStartTime = slotStart;
                            selectedEndTime = slotEnd;
                            break;
                        }
                    }
                    tempStart = slotEnd;
                }
                if (selectedDoctor != null) break;
            }

            // 2. Fallback search (across all doctors) if candidate search yielded no slots
            if (selectedDoctor == null)
            {
                var fallbackIds = await _context.Doctors.Where(d => d.IsActive).Select(d => d.Id).ToListAsync();

                var fallbackSchedules = await _context.DoctorSchedules
                    .Where(s => fallbackIds.Contains(s.DoctorId) && s.WorkDate.Date == appointmentDate.Value.Date)
                    .OrderBy(s => s.StartTime)
                    .ToListAsync();

                var fallbackAppointments = await _context.Appointments
                    .Where(a => fallbackIds.Contains(a.DoctorId) 
                              && a.AppointmentDate == appointmentDate.Value.Date 
                              && a.Status != AppointmentStatus.Cancelled)
                    .ToListAsync();

                foreach (var sched in fallbackSchedules)
                {
                    var tempStart = sched.StartTime;
                    while (tempStart.Add(TimeSpan.FromMinutes(30)) <= sched.EndTime)
                    {
                        var slotStart = tempStart;
                        var slotEnd = tempStart.Add(TimeSpan.FromMinutes(30));

                        if (slotStart >= startSearchTime)
                        {
                            var isSlotBooked = fallbackAppointments.Any(a => 
                                a.DoctorId == sched.DoctorId && 
                                a.StartTime == slotStart);

                            if (!isSlotBooked)
                            {
                                selectedDoctor = await _context.Doctors
                                    .Include(d => d.SpecialtyInfo)
                                    .FirstOrDefaultAsync(d => d.Id == sched.DoctorId);
                                selectedStartTime = slotStart;
                                selectedEndTime = slotEnd;
                                break;
                            }
                        }
                        tempStart = slotEnd;
                    }
                    if (selectedDoctor != null) break;
                }
            }
        }

        if (selectedDoctor == null || !selectedStartTime.HasValue || !selectedEndTime.HasValue)
        {
            TempData["ErrorMessage"] = "Không tìm thấy bác sĩ hoặc khung giờ trực ca phù hợp còn trống cho ngày này. Vui lòng đặt lịch chi tiết hoặc chọn ngày khác.";
            return RedirectToAction("Index", "Home");
        }

        var isDuplicate = await _context.Appointments.AnyAsync(a =>
            a.AppointmentDate == appointmentDate.Value.Date &&
            a.PatientPhone == phoneNumber &&
            a.Status != AppointmentStatus.Cancelled);

        if (isDuplicate)
        {
            TempData["ErrorMessage"] = "Số điện thoại này đã có lịch hẹn trong ngày đã chọn.";
            return RedirectToAction("Index", "Home");
        }

        // Kiểm tra ca khám của bác sĩ được chọn còn chỗ trống không
        var selectedSchedule = await _context.DoctorSchedules
            .FirstOrDefaultAsync(s =>
                s.DoctorId == selectedDoctor.Id &&
                s.WorkDate.Date == appointmentDate.Value.Date &&
                s.StartTime <= selectedStartTime.Value &&
                s.EndTime > selectedStartTime.Value);

        if (selectedSchedule != null)
        {
            var bookedInShift = await _context.Appointments.CountAsync(a =>
                a.DoctorId == selectedDoctor.Id &&
                a.AppointmentDate == appointmentDate.Value.Date &&
                a.StartTime >= selectedSchedule.StartTime &&
                a.StartTime < selectedSchedule.EndTime &&
                a.Status != AppointmentStatus.Cancelled);

            if (bookedInShift >= selectedSchedule.MaxAppointments)
            {
                TempData["ErrorMessage"] = "Ca khám này đã đầy chỗ. Vui lòng chọn ngày hoặc khung giờ khác.";
                return RedirectToAction("Index", "Home");
            }
        }

        PatientProfile? profile = null;
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (!string.IsNullOrWhiteSpace(userId))
        {
            profile = await _context.PatientProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
        }

        var appointment = new Appointment
        {
            DoctorId = selectedDoctor.Id,
            PatientProfile = profile,
            AppointmentCode = await GenerateAppointmentCodeAsync(),
            PatientName = fullName,
            PatientPhone = phoneNumber,
            AppointmentDate = appointmentDate.Value.Date,
            StartTime = selectedStartTime.Value,
            EndTime = selectedEndTime.Value,
            ReasonForVisit = string.IsNullOrWhiteSpace(medicalService) ? "Đăng ký khám nhanh (Chưa cung cấp triệu chứng)" : $"Khám nhanh: {medicalService}",
            MedicalService = string.IsNullOrWhiteSpace(medicalService) ? "Khám nhanh" : medicalService,
            Notes = string.IsNullOrWhiteSpace(facility) ? "Khám nhanh" : $"[{facility}] Khám nhanh",
            Passcode = passcode,
            Status = AppointmentStatus.Pending
        };

        _context.Appointments.Add(appointment);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Microsoft.EntityFrameworkCore.DbUpdateException)
        {
            TempData["ErrorMessage"] = "Khung giờ này vừa được đặt bởi người khác. Vui lòng thử lại với giờ khác.";
            return RedirectToAction("Index", "Home");
        }

        return RedirectToAction(nameof(Confirmation), new { id = appointment.Id });
    }

    [AllowAnonymous]
    public async Task<IActionResult> Confirmation(int id)
    {
        var appointment = await _context.Appointments
            .Include(a => a.Doctor)
            .ThenInclude(d => d!.SpecialtyInfo)
            .FirstOrDefaultAsync(a => a.Id == id);

        if (appointment is null)
        {
            return NotFound();
        }

        var facilityName = "Cơ sở 1: TP. Thủ Đức";
        var facilityAddress = "129 Tây Hòa, P. Phước Long A, TP. Thủ Đức, TP. HCM";

        if (!string.IsNullOrEmpty(appointment.Notes) && appointment.Notes.StartsWith("[CS2]"))
        {
            facilityName = "Cơ sở 2: Nhơn Trạch";
            facilityAddress = "Đường Trần Thị Nhật, X. Phú Hội, H. Nhơn Trạch, T. Đồng Nai";
        }

        var model = new AppointmentConfirmationViewModel
        {
            AppointmentCode = appointment.AppointmentCode,
            PatientName = appointment.PatientName,
            PatientPhone = appointment.PatientPhone,
            DoctorName = appointment.Doctor?.FullName ?? string.Empty,
            SpecialtyName = appointment.Doctor?.SpecialtyInfo?.Name ?? appointment.Doctor?.Specialty ?? string.Empty,
            AppointmentDate = appointment.AppointmentDate,
            StartTime = appointment.StartTime,
            EndTime = appointment.EndTime,
            FacilityName = facilityName,
            FacilityAddress = facilityAddress,
            MedicalService = appointment.MedicalService,
            Passcode = appointment.Passcode
        };

        return View(model);
    }

    [AllowAnonymous]
    public IActionResult Lookup()
    {
        return View(new AppointmentLookupViewModel());
    }

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Lookup(AppointmentLookupViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var appointments = await _context.Appointments
            .Include(a => a.Doctor)
            .ThenInclude(d => d!.SpecialtyInfo)
            .Where(a => a.PatientPhone == model.PhoneNumber && a.Passcode == model.Passcode)
            .OrderByDescending(a => a.AppointmentDate)
            .ThenByDescending(a => a.StartTime)
            .ToListAsync();

        if (appointments.Count == 0)
        {
            ModelState.AddModelError(string.Empty, "Không tìm thấy lịch hẹn nào với số điện thoại và mã xác nhận này.");
            return View(model);
        }

        model.Results = appointments;
        return View(model);
    }

    private async Task PopulateReferenceDataAsync(AppointmentBookingViewModel model, int? specialtyId, string? facility = null)
    {
        model.Specialties = await _context.Specialties
            .Where(s => s.IsActive)
            .OrderBy(s => s.Name)
            .Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            })
            .ToListAsync();

        var doctorsQuery = _context.Doctors
            .Where(d => d.IsActive)
            .AsQueryable();

        // Lọc theo chi nhánh
        if (facility == "CS1")
            doctorsQuery = doctorsQuery.Where(d => d.Workplace != null && d.Workplace.Contains("Thủ Đức"));
        else if (facility == "CS2")
            doctorsQuery = doctorsQuery.Where(d => d.Workplace != null && d.Workplace.Contains("Nhơn Trạch"));

        if (specialtyId.HasValue)
            doctorsQuery = doctorsQuery.Where(d => d.SpecialtyId == specialtyId.Value);

        model.Doctors = await doctorsQuery
            .OrderBy(d => d.Specialty)
            .ThenBy(d => d.FullName)
            .Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = $"{d.FullName} - {d.Specialty}"
            })
            .ToListAsync();
    }

    private async Task<string> GenerateAppointmentCodeAsync()
    {
        string code;
        do
        {
            code = $"PK{DateTime.Now:yyyyMMdd}{Random.Shared.Next(1000, 9999)}";
        }
        while (await _context.Appointments.AnyAsync(a => a.AppointmentCode == code));

        return code;
    }
}
