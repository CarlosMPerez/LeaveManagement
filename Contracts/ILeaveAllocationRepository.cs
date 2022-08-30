using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Contracts;

public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
{
    Task AllocateLeaveToAllEmployees(int leaveTypeId);

    Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period);

    Task<List<LeaveAllocation>> GetEmployeeAllocations(string id);
}
