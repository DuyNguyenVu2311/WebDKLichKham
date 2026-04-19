using System.ComponentModel.DataAnnotations;

namespace WebDKLichKham.Models;

public class DoctorSchedule
{
    public int Id { get; set; }

    public int DoctorId { get; set; }

    [DataType(DataType.Date)]
    public DateTime WorkDate { get; set; }

    public ScheduleShift Shift { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    [Range(1, 100)]
    public int MaxAppointments { get; set; } = 10;

    [StringLength(255)]
    public string? Notes { get; set; }

    public Doctor? Doctor { get; set; }
}
