namespace WebDKLichKham.Models.ViewModels;

public class MyAppointmentsViewModel
{
    public string PatientName { get; set; } = string.Empty;

    public IReadOnlyList<AppointmentListItemViewModel> UpcomingAppointments { get; set; } = [];

    public IReadOnlyList<AppointmentListItemViewModel> HistoryAppointments { get; set; } = [];
}
