using System.ComponentModel.DataAnnotations;

namespace WebDKLichKham.Models;

public class Appointment
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public int? PatientProfileId { get; set; }

    [Required, StringLength(30)]
    public string AppointmentCode { get; set; } = string.Empty;

    [Required, StringLength(120)]
    public string PatientName { get; set; } = string.Empty;

    [Required, Phone, StringLength(20)]
    public string PatientPhone { get; set; } = string.Empty;

    [EmailAddress, StringLength(150)]
    public string? PatientEmail { get; set; }

    public DateTime? PatientDateOfBirth { get; set; }

    [StringLength(20)]
    public string? PatientGender { get; set; }

    [DataType(DataType.Date)]
    public DateTime AppointmentDate { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

    [StringLength(500)]
    public string? ReasonForVisit { get; set; }

    [StringLength(150)]
    public string? MedicalService { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    [Required, StringLength(4)]
    public string Passcode { get; set; } = "0000";

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

    [StringLength(50)]
    public string? FollowUpSymptoms { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Doctor? Doctor { get; set; }

    public PatientProfile? PatientProfile { get; set; }
}
