namespace WebDKLichKham.Models.ViewModels;

public class AppointmentListItemViewModel
{
    public int Id { get; set; }

    public string DoctorName { get; set; } = string.Empty;

    public string Specialty { get; set; } = string.Empty;

    public DateTime AppointmentDate { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public AppointmentStatus Status { get; set; }

    public string? ReasonForVisit { get; set; }
}
