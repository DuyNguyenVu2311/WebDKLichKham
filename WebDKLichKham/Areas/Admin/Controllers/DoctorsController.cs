using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDKLichKham.Data;

namespace WebDKLichKham.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class DoctorsController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IActionResult> Index()
    {
        var doctors = await _context.Doctors
            .OrderBy(d => d.Specialty)
            .ThenBy(d => d.FullName)
            .ToListAsync();

        return View(doctors);
    }
}
