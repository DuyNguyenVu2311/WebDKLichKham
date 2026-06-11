using System.ComponentModel.DataAnnotations;

namespace WebDKLichKham.Models;

public class PatientProfile
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string FullName { get; set; } = string.Empty;

    [Phone, StringLength(20)]
    public string? PhoneNumber { get; set; }

    [StringLength(255)]
    public string? Address { get; set; }

    [StringLength(1000)]
    public string? MedicalHistory { get; set; }

    public DateTime? DateOfBirth { get; set; }

    [StringLength(20)]
    public string? Gender { get; set; }

    [StringLength(50)]
    public string? IdentityCard { get; set; }

    [StringLength(50)]
    public string? InsuranceCode { get; set; }

    [StringLength(100)]
    public string? Occupation { get; set; }

    [StringLength(100)]
    public string? Country { get; set; }

    [StringLength(100)]
    public string? Province { get; set; }

    [StringLength(100)]
    public string? District { get; set; }

    [StringLength(100)]
    public string? Ward { get; set; }

    [StringLength(255)]
    public string? StreetAddress { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
