using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;

public class LeaveTypeCreateViewModel
{
    [Display(Name="Leave Type Name")]
    [Required]
    public string Name { get; set; }

    [Display(Name = "Default Number of Leave Days")]
    [Required]
    [Range(1, 25, ErrorMessage ="Valid Leave Days between 1 and 25")]
    public int DefaultDays { get; set; }
}
