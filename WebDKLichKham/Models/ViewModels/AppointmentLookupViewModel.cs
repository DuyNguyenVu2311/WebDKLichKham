using System.ComponentModel.DataAnnotations;
using WebDKLichKham.Models;

namespace WebDKLichKham.Models.ViewModels;

public class AppointmentLookupViewModel
{
    [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
    [Display(Name = "Số điện thoại")]
    [Phone(ErrorMessage = "Số điện thoại không hợp lệ.")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vui lòng nhập mã xác nhận 4 chữ số.")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "Mã xác nhận phải đúng 4 chữ số.")]
    [Display(Name = "Mã xác nhận (4 chữ số)")]
    public string Passcode { get; set; } = string.Empty;

    public List<Appointment>? Results { get; set; }
}
