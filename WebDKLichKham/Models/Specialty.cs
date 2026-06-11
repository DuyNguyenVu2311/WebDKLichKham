using System.ComponentModel.DataAnnotations;

namespace WebDKLichKham.Models;

public class Specialty
{
    public int Id { get; set; }

    [Required, StringLength(120)]
    public string Name { get; set; } = string.Empty;

    [StringLength(1000)]
    public string? Description { get; set; }

    [StringLength(255)]
    public string? IconClass { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
