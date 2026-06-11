using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebDKLichKham.Data;
using WebDKLichKham.Models.ViewModels;

namespace WebDKLichKham.Controllers;

public class DoctorsController(ApplicationDbContext context) : Controller
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IActionResult> Index(int? specialtyId, string? branch, DateTime? date, string? keyword)
    {
        var query = _context.Doctors
            .Include(d => d.SpecialtyInfo)
            .Include(d => d.Schedules)
            .Where(d => d.IsActive)
            .AsQueryable();

        if (specialtyId.HasValue)
        {
            query = query.Where(d => d.SpecialtyId == specialtyId.Value);
        }

        if (!string.IsNullOrWhiteSpace(branch))
        {
            query = query.Where(d => d.Workplace != null && d.Workplace.Contains(branch));
        }

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            query = query.Where(d =>
                d.FullName.Contains(keyword) ||
                d.Specialty.Contains(keyword));
        }

        if (date.HasValue)
        {
            var targetDate = date.Value.Date;
            query = query.Where(d => d.Schedules.Any(s => s.WorkDate.Date == targetDate));
        }

        var doctors = await query
            .OrderBy(d => d.Specialty)
            .ThenBy(d => d.Workplace)
            .ThenBy(d => d.FullName)
            .ToListAsync();

        var model = new DoctorDirectoryViewModel
        {
            Doctors = doctors,
            Keyword = keyword,
            SpecialtyId = specialtyId,
            Branch = branch,
            Date = date,
            SpecialtyOptions = await _context.Specialties
                .Where(s => s.IsActive)
                .OrderBy(s => s.Name)
                .Select(s => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
                .ToListAsync()
        };

        return View(model);
    }

    public async Task<IActionResult> Details(int id)
    {
        var doctor = await _context.Doctors
            .Include(d => d.SpecialtyInfo)
            .Include(d => d.Schedules.OrderBy(s => s.WorkDate))
            .Include(d => d.Appointments)
            .FirstOrDefaultAsync(d => d.Id == id && d.IsActive);

        if (doctor is null)
        {
            return NotFound();
        }

        return View(doctor);
    }
}
