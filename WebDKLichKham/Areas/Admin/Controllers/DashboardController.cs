using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDKLichKham.Data;
using WebDKLichKham.Models;
using WebDKLichKham.Models.ViewModels;

namespace WebDKLichKham.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class DashboardController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var model = new AdminDashboardViewModel
        {
            TotalDoctors = await _context.Doctors.CountAsync(),
            TotalPatients = await _context.PatientProfiles.CountAsync(),
            PendingAppointments = await _context.Appointments.CountAsync(a => a.Status == AppointmentStatus.Pending),
            ConfirmedAppointments = await _context.Appointments.CountAsync(a => a.Status == AppointmentStatus.Confirmed),
            RecentAppointments = await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.PatientProfile)
                .OrderByDescending(a => a.CreatedAt)
                .Take(8)
                .ToListAsync()
        };

        return View(model);
    }
}
