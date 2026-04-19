using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebDKLichKham.Models.ViewModels;

public class AppointmentBookingViewModel
{
    [Required]
    [Display(Name = "Bác sĩ")]
    public int DoctorId { get; set; }

    [Required]
    [Display(Name = "Ngày khám")]
    [DataType(DataType.Date)]
    public DateTime AppointmentDate { get; set; } = DateTime.Today.AddDays(1);

    [Required]
    [Display(Name = "Giờ bắt đầu")]
    public TimeSpan StartTime { get; set; } = new(8, 0, 0);

    [Required]
    [Display(Name = "Giờ kết thúc")]
    public TimeSpan EndTime { get; set; } = new(8, 30, 0);

    [Required]
    [Display(Name = "Họ và tên")]
    [StringLength(120)]
    public string FullName { get; set; } = string.Empty;

    [Display(Name = "Số điện thoại")]
    [Phone]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Địa chỉ")]
    [StringLength(255)]
    public string? Address { get; set; }

    [Display(Name = "Lý do khám")]
    [StringLength(500)]
    public string? ReasonForVisit { get; set; }

    [Display(Name = "Tiền sử bệnh")]
    [StringLength(1000)]
    public string? MedicalHistory { get; set; }

    public IEnumerable<SelectListItem> Doctors { get; set; } = [];
}
