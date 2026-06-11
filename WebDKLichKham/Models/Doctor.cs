using System.ComponentModel.DataAnnotations;

namespace WebDKLichKham.Models;

public class Doctor
{
    public int Id { get; set; }

    public int? SpecialtyId { get; set; }

    [Required, StringLength(120)]
    public string FullName { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Specialty { get; set; } = string.Empty;

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    [EmailAddress, StringLength(150)]
    public string? Email { get; set; }

    [StringLength(150)]
    public string? Qualification { get; set; }

    [Range(0, 60)]
    public int ExperienceYears { get; set; }

    [Range(0, 100000000)]
    public decimal Fee { get; set; }

    [StringLength(1000)]
    public string? Biography { get; set; }

    [StringLength(255)]
    public string? Workplace { get; set; }

    [StringLength(255)]
    public string? AvatarUrl { get; set; }

    public bool IsFeatured { get; set; }

    public bool IsActive { get; set; } = true;

    public Specialty? SpecialtyInfo { get; set; }

    public ICollection<DoctorSchedule> Schedules { get; set; } = new List<DoctorSchedule>();

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
