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

    public async Task<EmployeeAllocationViewModel> GetAllocationsForEmployee(string employeeId)
    {
        var allocs = await context.LeaveAllocations
                            .Include(x => x.LeaveType)
                            .Where(x => x.EmployeeId == employeeId && x.Period == DateTime.Now.Year)
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

    public async Task<LeaveAllocationEditViewModel?> GetAllocation(string employeeId, int leaveTypeId)
    {
        var alloc = await context.LeaveAllocations
                            .Include(x => x.LeaveType)
                            .FirstOrDefaultAsync(x => x.EmployeeId == employeeId && 
                                                        x.LeaveTypeId == leaveTypeId && 
                                                        x.Period == DateTime.Now.Year);

        if (alloc == null) return null;

        var employee = await userManager.FindByIdAsync(alloc.EmployeeId);

        var model = mapper.Map<LeaveAllocationEditViewModel>(alloc);
        model.Employee = mapper.Map<EmployeeEditViewModel>(employee);

        return model;
    }
}
