using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    private readonly AutoMapper.IConfigurationProvider mapperConfigProvider;

    public LeaveAllocationRepository(ApplicationDbContext context, 
                                    UserManager<Employee> userManager, 
                                    ILeaveTypeRepository leaveTypeRepository, 
                                    IMapper mapper, 
                                    AutoMapper.IConfigurationProvider cfgProvider) : base(context)
    {
        this.context = context;
        this.userManager = userManager;
        this.leaveTypeRepo = leaveTypeRepository;
        this.mapper = mapper;
        mapperConfigProvider = cfgProvider;
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
                    NumberOfDays = leaveType != null ? leaveType.DefaultDays : 0
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
                            .ProjectTo<LeaveAllocationCollectionItemViewModel>(mapperConfigProvider) //(*)
                            .ToListAsync();

        // (*) Using AutoMApper.IConfigurationProvider and AutoMapper.QueryableExtensions, we can use ProjectTo 
        // which "converts" the result of the query from LeaveAllocations entities to LeaveAllocationCollectionItemViewModel
        // IN THE QUERY, instead of mapping it afterwards. Querying as a POCO and mapping it to a VM afterwards (here(**))
        // would work fine, but it would be inefficient: if the table has 50 columns, the base POCO has 50 properties and 
        // the VM has 3 columns we are executing an unnecessary heavy query and then discarding 47 columns of Eru knows
        // how many rows. By projecting the query knows before hand what to query specifically.
        
        var employee = await userManager.FindByIdAsync(employeeId);

        var model = mapper.Map<EmployeeAllocationViewModel>(employee);
        model.LeaveAllocations = allocs; // (**)

        return model;
    }

    public async Task<LeaveAllocationEditViewModel?> GetAllocation(int allocationId)
    {
        var alloc = await context.LeaveAllocations
                            .Include(x => x.LeaveType)
                            .ProjectTo<LeaveAllocationEditViewModel>(mapperConfigProvider)
                            .FirstOrDefaultAsync(x => x.Id == allocationId);

        if (alloc == null) return null;

        var employee = await userManager.FindByIdAsync(alloc.EmployeeId);

        var model = alloc;
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
