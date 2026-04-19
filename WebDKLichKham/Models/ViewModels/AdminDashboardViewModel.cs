namespace WebDKLichKham.Models.ViewModels;

public class AdminDashboardViewModel
{
    public int TotalDoctors { get; set; }

    public int TotalPatients { get; set; }

    public int PendingAppointments { get; set; }

    public int ConfirmedAppointments { get; set; }

    public IReadOnlyList<Appointment> RecentAppointments { get; set; } = [];
}
