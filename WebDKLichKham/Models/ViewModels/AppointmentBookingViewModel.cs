using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebDKLichKham.Models.ViewModels;

public class AppointmentBookingViewModel
{
    [Display(Name = "Chuyên khoa")]
    public int? SpecialtyId { get; set; }

    [Display(Name = "Bác sĩ")]
    public int? DoctorId { get; set; }

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

    [Required]
    [Display(Name = "Số điện thoại")]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Display(Name = "Email")]
    [EmailAddress]
    [StringLength(150)]
    public string? Email { get; set; }

    [Display(Name = "Ngày sinh")]
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    [Display(Name = "Giới tính")]
    [StringLength(20)]
    public string? Gender { get; set; }

    [Display(Name = "Địa chỉ")]
    [StringLength(255)]
    public string? Address { get; set; }

    [Display(Name = "Số CCCD/Mã định danh")]
    [StringLength(50)]
    public string? IdentityCard { get; set; }

    [Display(Name = "Mã bảo hiểm y tế")]
    [StringLength(50)]
    public string? InsuranceCode { get; set; }

    [Display(Name = "Nghề nghiệp")]
    [StringLength(100)]
    public string? Occupation { get; set; }

    [Display(Name = "Quốc gia")]
    [StringLength(100)]
    public string? Country { get; set; } = "Việt Nam";

    [Display(Name = "Tỉnh/Thành phố")]
    [StringLength(100)]
    public string? Province { get; set; }

    [Display(Name = "Quận/Huyện")]
    [StringLength(100)]
    public string? District { get; set; }

    [Display(Name = "Phường/Xã")]
    [StringLength(100)]
    public string? Ward { get; set; }

    [Display(Name = "Số nhà, tên đường, ấp thôn xóm")]
    [StringLength(255)]
    public string? StreetAddress { get; set; }

    [Display(Name = "Lý do khám")]
    [StringLength(500)]
    public string? ReasonForVisit { get; set; }

    [Display(Name = "Dịch vụ khám")]
    [StringLength(150)]
    public string? MedicalService { get; set; }

    [Display(Name = "Tiền sử bệnh")]
    [StringLength(1000)]
    public string? MedicalHistory { get; set; }

    [Display(Name = "Cơ sở khám")]
    public string? Facility { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập mã xác nhận 4 chữ số.")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "Mã xác nhận phải đúng 4 chữ số.")]
    [Display(Name = "Mã xác nhận (4 chữ số)")]
    public string Passcode { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập lại mã xác nhận.")]
    [Compare("Passcode", ErrorMessage = "Mã xác nhận nhập lại không khớp.")]
    [Display(Name = "Nhập lại mã xác nhận")]
    public string ConfirmPasscode { get; set; } = string.Empty;

    public IEnumerable<SelectListItem> Doctors { get; set; } = [];

    public IEnumerable<SelectListItem> Specialties { get; set; } = [];
}
