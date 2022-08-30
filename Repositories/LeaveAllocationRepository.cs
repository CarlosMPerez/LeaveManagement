using LeaveManagement.Web.Configuration;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly ApplicationDbContext context;
    private readonly UserManager<Employee> userManager;
    private readonly ILeaveTypeRepository leaveTypeRepo;

    public LeaveAllocationRepository(ApplicationDbContext context, 
                                    UserManager<Employee> userManager, 
                                    ILeaveTypeRepository leaveTypeRepository) : base(context)
    {
        this.context = context;
        this.userManager = userManager;
        this.leaveTypeRepo = leaveTypeRepository;
    }

    public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
    {
        return await context.LeaveAllocations.AnyAsync(x => x.EmployeeId == employeeId &&
                                                        x.LeaveTypeId == leaveTypeId &&
                                                        x.Period == period);
    }

    public async Task AllocateLeaveToAllEmployees(int leaveTypeId)
    {
        List<LeaveAllocation> allocs = new List<LeaveAllocation>();
        var employees = await userManager.GetUsersInRoleAsync(RolesConstants.USER);
        var period = DateTime.Now.Year;
        var leaveType = await leaveTypeRepo.GetAsync(leaveTypeId);

        foreach(var employee in employees)
        {
            if(!await AllocationExists(employee.Id, leaveTypeId, period))
            {
                allocs.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leaveType != null ? leaveType.DefaultDays : 0,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                });
            }
        }

        await AddRangeAsync(allocs);
    }

    public async Task<List<LeaveAllocation>> GetEmployeeAllocations(string id)
    {
        return await context.LeaveAllocations
                            .Include(x => x.LeaveType)
                            .Where(x => x.EmployeeId == id)
                            .ToListAsync();
    }
}
