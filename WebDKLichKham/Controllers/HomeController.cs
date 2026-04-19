using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDKLichKham.Data;
using WebDKLichKham.Models;
using WebDKLichKham.Models.ViewModels;

namespace WebDKLichKham.Controllers;

public class HomeController(ILogger<HomeController> logger, ApplicationDbContext context) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly ApplicationDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var model = new HomeDashboardViewModel
        {
            TotalDoctors = await _context.Doctors.CountAsync(d => d.IsActive),
            TotalAppointments = await _context.Appointments.CountAsync(),
            UpcomingSchedules = await _context.DoctorSchedules.CountAsync(s => s.WorkDate >= DateTime.Today),
            FeaturedDoctors = await _context.Doctors
                .Where(d => d.IsActive)
                .OrderBy(d => d.Specialty)
                .Take(3)
                .ToListAsync()
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
