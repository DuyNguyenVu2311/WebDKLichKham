using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDKLichKham.Data;

namespace WebDKLichKham.Controllers;

public class DoctorsController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var doctors = await _context.Doctors
            .Where(d => d.IsActive)
            .OrderBy(d => d.Specialty)
            .ThenBy(d => d.FullName)
            .ToListAsync();

        return View(doctors);
    }

    public async Task<IActionResult> Details(int id)
    {
        var doctor = await _context.Doctors
            .Include(d => d.Schedules.OrderBy(s => s.WorkDate))
            .FirstOrDefaultAsync(d => d.Id == id && d.IsActive);

        if (doctor is null)
        {
            return NotFound();
        }

        return View(doctor);
    }
}
