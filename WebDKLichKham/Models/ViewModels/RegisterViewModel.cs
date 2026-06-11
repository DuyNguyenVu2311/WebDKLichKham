using System.ComponentModel.DataAnnotations;

namespace WebDKLichKham.Models.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
    [Display(Name = "Họ và tên")]
    [StringLength(120, ErrorMessage = "Họ và tên không quá 120 ký tự")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
    [Display(Name = "Số điện thoại")]
    [Phone(ErrorMessage = "Số điện thoại không đúng định dạng")]
    [StringLength(20)]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
    [Display(Name = "Mật khẩu")]
    [DataType(DataType.Password)]
    [MinLength(6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên")]
    public string Password { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu")]
    [Display(Name = "Xác nhận mật khẩu")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng chọn ngày sinh")]
    [Display(Name = "Ngày sinh")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; } = DateTime.Today.AddYears(-30);

    [Required(ErrorMessage = "Vui lòng chọn giới tính")]
    [Display(Name = "Giới tính")]
    [StringLength(20)]
    public string Gender { get; set; } = "Nam";

    [Display(Name = "Số CCCD/CMND")]
    [StringLength(50)]
    public string? IdentityCard { get; set; }

    [Display(Name = "Mã số BHYT")]
    [StringLength(50)]
    public string? InsuranceCode { get; set; }

    [Display(Name = "Nghề nghiệp")]
    [StringLength(100)]
    public string? Occupation { get; set; }

    [Display(Name = "Tỉnh/Thành phố")]
    [StringLength(100)]
    public string? Province { get; set; }

    [Display(Name = "Quận/Huyện")]
    [StringLength(100)]
    public string? District { get; set; }

    [Display(Name = "Phường/Xã")]
    [StringLength(100)]
    public string? Ward { get; set; }

    [Display(Name = "Số nhà, tên đường")]
    [StringLength(255)]
    public string? StreetAddress { get; set; }
}
