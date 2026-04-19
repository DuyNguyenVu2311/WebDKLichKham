using System.ComponentModel.DataAnnotations;

namespace WebDKLichKham.Models;

public enum AppointmentStatus
{
    [Display(Name = "Chờ xác nhận")]
    Pending = 0,
    [Display(Name = "Đã xác nhận")]
    Confirmed = 1,
    [Display(Name = "Đã hoàn thành")]
    Completed = 2,
    [Display(Name = "Đã hủy")]
    Cancelled = 3
}
