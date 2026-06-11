namespace WebDKLichKham.Models.ViewModels;

public class AppointmentConfirmationViewModel
{
    public string AppointmentCode { get; set; } = string.Empty;

    public string PatientName { get; set; } = string.Empty;

    public string PatientPhone { get; set; } = string.Empty;

    public string DoctorName { get; set; } = string.Empty;

    public string SpecialtyName { get; set; } = string.Empty;

    public DateTime AppointmentDate { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public string FacilityName { get; set; } = string.Empty;

    public string FacilityAddress { get; set; } = string.Empty;

    public string? MedicalService { get; set; }

    public string Passcode { get; set; } = string.Empty;
}
