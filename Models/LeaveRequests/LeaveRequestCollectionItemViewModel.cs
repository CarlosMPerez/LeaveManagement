using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models;

public class LeaveRequestCollectionItemViewModel
{
    public int Id { get; set; }

    [Display(Name = "Start")]
    public string? StartDate { get; set; }

    [Display(Name = "End")]
    public string? EndDate { get; set; }

    [Display(Name = "Requested")]
    public string? RequestDate { get; set; }

    [Display(Name = "Status")]
    public string? Approved { get; set; }

    public string Cancelled { get; set; }

    [Display(Name = "Leave Type")]
    public string LeaveTypeName { get; set; }

    [Display(Name = "Employee")]
    public string Employee { get; set; }

    [Display(Name = "Days")]
    public int TotalLeaveDays { get; set; }

}
