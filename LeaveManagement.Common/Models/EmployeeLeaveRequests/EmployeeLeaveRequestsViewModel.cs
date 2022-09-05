namespace LeaveManagement.Common.Models;

public class EmployeeLeaveRequestsViewModel
{
    public EmployeeLeaveRequestsViewModel(List<LeaveRequestCollectionItemViewModel> leaveRequests, List<LeaveAllocationCollectionItemViewModel> leaveAllocations)
    {
        LeaveRequests = leaveRequests;
        LeaveAllocations = leaveAllocations;
    }

    public List<LeaveRequestCollectionItemViewModel> LeaveRequests { get; set; }
    public List<LeaveAllocationCollectionItemViewModel> LeaveAllocations { get; set; }
}
