namespace WebDKLichKham.Models.ViewModels;

public class HomeDashboardViewModel
{
    public int TotalDoctors { get; set; }

    public int TotalAppointments { get; set; }

    public int UpcomingSchedules { get; set; }

    public IReadOnlyList<Doctor> FeaturedDoctors { get; set; } = [];
}
