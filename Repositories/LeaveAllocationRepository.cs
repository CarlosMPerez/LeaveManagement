using AutoMapper;
using LeaveManagement.Web.Configuration;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    private readonly ApplicationDbContext context;
    private readonly UserManager<Employee> userManager;
    private readonly ILeaveTypeRepository leaveTypeRepo;
    private readonly IMapper mapper;

    public LeaveAllocationRepository(ApplicationDbContext context, 
                                    UserManager<Employee> userManager, 
                                    ILeaveTypeRepository leaveTypeRepository, 
                                    IMapper mapper) : base(context)
    {
        this.context = context;
        this.userManager = userManager;
        this.leaveTypeRepo = leaveTypeRepository;
        this.mapper = mapper;
    }

    public async Task<bool> AllocationExists(string employeeId, int leaveTypeId)
    {
        return await context.LeaveAllocations.AnyAsync(x => x.EmployeeId == employeeId &&
                                                        x.LeaveTypeId == leaveTypeId);
    }

    public async Task AllocateLeaveToAllEmployees(int leaveTypeId)
    {
        List<LeaveAllocation> allocs = new List<LeaveAllocation>();
        var employees = await userManager.GetUsersInRoleAsync(RolesConstants.USER);
        var leaveType = await leaveTypeRepo.GetAsync(leaveTypeId);

        foreach(var employee in employees)
        {
            if(!await AllocationExists(employee.Id, leaveTypeId))
            {
                allocs.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    NumberOfDays = leaveType != null ? leaveType.DefaultDays : 0,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now
                });
            }
        }

        await AddRangeAsync(allocs);
    }

    public async Task<EmployeeAllocationViewModel> GetAllocationsForEmployee(string employeeId)
    {
        var allocs = await context.LeaveAllocations
                            .Include(x => x.LeaveType)
                            .Where(x => x.EmployeeId == employeeId)
                            .ToListAsync();
        
        var employee = await userManager.FindByIdAsync(employeeId);

        var model = mapper.Map<EmployeeAllocationViewModel>(employee);
        model.LeaveAllocations = mapper.Map<List<LeaveAllocationCollectionItemViewModel>>(allocs);

        return model;
    }

    public async Task<LeaveAllocationEditViewModel?> GetAllocation(int allocationId)
    {
        var alloc = await context.LeaveAllocations
                            .Include(x => x.LeaveType)
                            .FirstOrDefaultAsync(x => x.Id == allocationId);

        if (alloc == null) return null;

        var employee = await userManager.FindByIdAsync(alloc.EmployeeId);

        var model = mapper.Map<LeaveAllocationEditViewModel>(alloc);
        model.Employee = mapper.Map<EmployeeEditViewModel>(employee);

        return model;
    }

    public async Task<LeaveAllocation?> GetAllocation(string employeeId, int leaveTypeId)
    {
        var alloc = await context.LeaveAllocations
                            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId && 
                                                        x.LeaveTypeId == leaveTypeId);

        if (alloc == null) return null;
        else return alloc;
    }

    public async Task<LeaveAllocation?> GetSingleAllocation(string employeeId, int leaveAllocationId)
    {
        return await context.LeaveAllocations
                            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId && 
                                                x.Id == leaveAllocationId);
    }
}
