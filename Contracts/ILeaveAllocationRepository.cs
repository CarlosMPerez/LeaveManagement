using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task AllocateLeaveToAllEmployees(int leaveTypeId);

    Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);

    Task<EmployeeAllocationViewModel> GetAllocationsForEmployee(string employeeId);

    Task<LeaveAllocationEditViewModel?> GetAllocation(int allocationId);

    Task<LeaveAllocationEditViewModel?> GetAllocation(string employeeId, int leaveTypeId);
}
