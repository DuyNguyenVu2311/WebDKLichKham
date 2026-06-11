using WebDKLichKham.Models;

namespace WebDKLichKham.Models.ViewModels;

public class HomeDashboardViewModel
{
    public int TotalDoctors { get; set; }

    public int TotalAppointments { get; set; }

    public int UpcomingSchedules { get; set; }

    public IReadOnlyList<Doctor> FeaturedDoctors { get; set; } = [];

    public IReadOnlyList<Specialty> FeaturedSpecialties { get; set; } = [];

    /// <summary>Tất cả chuyên khoa có ít nhất 1 bác sĩ đang hoạt động – dùng cho dropdown form đặt lịch.</summary>
    public IReadOnlyList<Specialty> AllSpecialtiesWithDoctors { get; set; } = [];

    public List<Article> Articles { get; set; } = new();
}
