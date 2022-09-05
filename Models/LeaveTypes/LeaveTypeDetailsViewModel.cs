using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;

public class LeaveTypeDetailsViewModel
{
    public int Id { get; set; }

    [Display(Name = "Leave Type Name")]
    public string Name { get; set; }

    [Display(Name = "Default Number of Leave Days")]
    public int DefaultDays { get; set; }

}
