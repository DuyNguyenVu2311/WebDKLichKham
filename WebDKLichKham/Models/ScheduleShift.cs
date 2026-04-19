using System.ComponentModel.DataAnnotations;

namespace WebDKLichKham.Models;

public enum ScheduleShift
{
    [Display(Name = "Ca sáng")]
    Morning = 0,
    [Display(Name = "Ca chiều")]
    Afternoon = 1,
    [Display(Name = "Ca tối")]
    Evening = 2
}
