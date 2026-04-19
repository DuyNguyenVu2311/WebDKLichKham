using System.ComponentModel.DataAnnotations;

namespace WebDKLichKham.Models;

public class Appointment
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    public int PatientProfileId { get; set; }

    [DataType(DataType.Date)]
    public DateTime AppointmentDate { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

    [StringLength(500)]
    public string? ReasonForVisit { get; set; }

    [StringLength(500)]
    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Doctor? Doctor { get; set; }

    public PatientProfile? PatientProfile { get; set; }
}
