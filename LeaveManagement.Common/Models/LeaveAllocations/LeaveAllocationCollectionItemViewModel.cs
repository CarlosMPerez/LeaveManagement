namespace LeaveManagement.Common.Models;

public class LeaveAllocationCollectionItemViewModel
{
    public int Id { get; set; }
    public int NumberOfDays { get; set; }

    public LeaveTypeCollectionItemViewModel LeaveType { get; set; }
}
