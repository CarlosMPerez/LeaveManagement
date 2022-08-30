namespace LeaveManagement.Web.Models;

public class LeaveAllocationCollectionItemViewModel
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }

    public int Period { get; set; }

    public LeaveTypeCollectionItemViewModel LeaveType { get; set; }
}
