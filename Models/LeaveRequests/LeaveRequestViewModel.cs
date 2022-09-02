
namespace LeaveManagement.Web.Models;

public class LeaveRequestViewModel
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime RequestDate { get; set; }

    public string? RequestComments { get; set; }

    public bool? Approved { get; set; }

    public bool Cancelled { get; set; }

    public LeaveTypeCollectionItemViewModel LeaveType { get; set; }

    public EmployeeCollectionItemViewModel Employee { get; set; }

}
