using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveManagement.Data;

public class LeaveRequest : BaseEntity
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime RequestDate { get; set; }

    public int TotalLeaveDays { get; set; }

    public string? RequestComments { get; set; }

    public bool? Approved { get; set; }

    public bool Cancelled { get; set; }

    [ForeignKey("LeaveTypeId")]
    public LeaveType LeaveType { get; set; }

    public int LeaveTypeId { get; set; }

    [ForeignKey("EmployeeId")]
    public Employee Employee { get; set; }

    public string EmployeeId { get; set; }

}