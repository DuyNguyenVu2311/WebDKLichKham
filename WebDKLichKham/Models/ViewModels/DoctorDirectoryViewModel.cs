using Microsoft.AspNetCore.Mvc.Rendering;
using WebDKLichKham.Models;

namespace WebDKLichKham.Models.ViewModels;

public class DoctorDirectoryViewModel
{
    public string? Keyword { get; set; }

    public int? SpecialtyId { get; set; }

    public string? Branch { get; set; }

    public DateTime? Date { get; set; }

    public IEnumerable<Doctor> Doctors { get; set; } = [];

    public IEnumerable<SelectListItem> SpecialtyOptions { get; set; } = [];
}
