using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;
public class LeaveTypeEditViewModel
{
    public int Id { get; set; }

    [Display(Name = "Leave Type Name")]
    [Required]
    public string Name { get; set; }

    [Display(Name = "Default Number of Leave Days")]
    [Required]
    public int DefaultDays { get; set; }

    public DateTime CreationDate { get; set; } // I need it so I don't lose it?
}
