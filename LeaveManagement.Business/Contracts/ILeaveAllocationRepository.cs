using LeaveManagement.Data;
using LeaveManagement.Common.Models;

namespace LeaveManagement.Business.Contracts;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task AllocateLeaveToAllEmployees(int leaveTypeId);

    Task<bool> AllocationExists(string employeeId, int leaveTypeId);

    Task<EmployeeAllocationViewModel> GetAllocationsForEmployee(string employeeId);

    Task<LeaveAllocationEditViewModel?> GetAllocation(int allocationId);

    Task<LeaveAllocation?> GetAllocation(string employeeId, int leaveTypeId);

    Task<LeaveAllocation?> GetSingleAllocation(string employeeId, int leaveAllocationId);
}
