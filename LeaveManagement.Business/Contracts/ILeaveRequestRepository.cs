using LeaveManagement.Data;
using LeaveManagement.Common.Models;

namespace LeaveManagement.Business.Contracts;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task CreateLeaveRequest(LeaveRequestCreateViewModel model);

    Task<EmployeeLeaveRequestsViewModel> GetCurrentUserLeaveRequestsDetails();

    Task<List<LeaveRequest>> GetAllAsync(string employeeId);

    Task ChangeApprovalStatus(int leaveRequestId, bool approved);

    Task<LeaveRequestViewModel?> GetLeaveRequestAsync(int? id);

    Task<LeaveRequest> GetSimpleLeaveRequestAsync(int? id);

    Task<LeaveRequestsAdminViewModel> GetAdminLeaveRequestList();
}
