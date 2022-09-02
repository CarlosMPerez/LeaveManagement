using AutoMapper;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.CustomExceptions;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
{
    private readonly ApplicationDbContext ctx;
    private readonly IMapper mapper;
    private readonly IHttpContextAccessor accessor;
    private readonly UserManager<Employee> userManager;
    private readonly ILeaveAllocationRepository allocRepo;
    private readonly ILeaveTypeRepository leaveTypeRepo;

    public LeaveRequestRepository(ApplicationDbContext context, 
                                    IMapper mapper, 
                                    IHttpContextAccessor accessor, 
                                    UserManager<Employee> userManager, 
                                    ILeaveAllocationRepository allocRepo, 
                                    ILeaveTypeRepository leaveTypeRepo) : base(context)
    {
        ctx = context;
        this.mapper = mapper;
        this.accessor = accessor;
        this.userManager = userManager;
        this.allocRepo = allocRepo;
        this.leaveTypeRepo = leaveTypeRepo;
    }

    public async Task CreateLeaveRequest(LeaveRequestCreateViewModel model)
    {
        var user = await userManager.GetUserAsync(accessor.HttpContext?.User);
        var leaveType = await leaveTypeRepo.GetAsync(model.LeaveTypeId);

        // TO-DO Check there's a leave allocation created for leave type, period and user
        // (NoLeaveAllocationForPeriodOrUserException)

        // Check this single requested leave total days do not exceed the leave type default days
        int totalDays = (int)(model.EndDate - model.StartDate).Value.TotalDays;
        if (leaveType.DefaultDays < totalDays) throw new LeaveRequestExcessDaysException("Requested leave has allocated more days than the Leave Type allows");

        // TO-DO Check if the sum of the total leave requests for the leave type and user does not exceed the allocation days
        // (TotalLeaveRequestTimeExceedsAllocationException)

        var leaveRequest = mapper.Map<LeaveRequest>(model);
        leaveRequest.CreationDate = DateTime.Now;
        leaveRequest.ModificationDate = DateTime.Now;
        leaveRequest.RequestDate = DateTime.Now;
        leaveRequest.EmployeeId = user.Id;
        leaveRequest.TotalLeaveDays = totalDays;

        await AddAsync(leaveRequest);
    }

    public async Task<List<LeaveRequest>> GetAllAsync(string employeeId)
    {
        return await ctx.LeaveRequests
                            .Where(x => x.EmployeeId == employeeId)
                            .ToListAsync();
    }

    public async Task<List<LeaveRequest>> GetAllActiveAsync(string employeeId)
    {
        var list = await ctx.LeaveRequests
                            .Include(x => x.LeaveType)
                            .Where(x => x.EmployeeId == employeeId && !x.Cancelled)
                            .ToListAsync();
        return list;
    }

    public async Task<LeaveRequestViewModel?> GetLeaveRequestAsync(int? id)
    {
        var leaveRequest = await ctx.LeaveRequests
            .Include(x => x.LeaveType)
            .Include(x => x.Employee)
            .FirstOrDefaultAsync(x => x.Id == id);
        return mapper.Map<LeaveRequestViewModel>(leaveRequest);
    }

    public async Task<LeaveRequest> GetSimpleLeaveRequestAsync(int? id)
    {
        var leaveRequest = await ctx.LeaveRequests
            .FirstOrDefaultAsync(x => x.Id == id);
        return leaveRequest;
    }

    public async Task<EmployeeLeaveRequestsViewModel> GetCurrentUserLeaveRequestsDetails()
    {
        // get current user
        var user = await userManager.GetUserAsync(accessor.HttpContext?.User);
        var allocations = (await allocRepo.GetAllocationsForEmployee(user.Id)).LeaveAllocations;
        var requests = mapper.Map<List<LeaveRequestCollectionItemViewModel>>(await GetAllActiveAsync(user.Id));

        return new EmployeeLeaveRequestsViewModel(requests, allocations);
    }

    public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
    {
        try
        {
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;
            leaveRequest.ModificationDate = DateTime.Now;
            if (approved)
            {
                var allocVM = await allocRepo.GetAllocation(leaveRequest.EmployeeId, leaveRequest.LeaveTypeId);
                allocVM.NumberOfDays -= (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                var alloc = mapper.Map<LeaveAllocation>(allocVM);
                await allocRepo.UpdateAsync(alloc);
            }

            await UpdateAsync(leaveRequest);

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task<LeaveRequestsAdminViewModel> GetAdminLeaveRequestList()
    {
        var leaveRequests = ctx.LeaveRequests
                                .Include(x => x.Employee)
                                .Include(x => x.LeaveType)
                                .ToList();

        var model = new LeaveRequestsAdminViewModel
        {
            TotalRequests = leaveRequests.Count,
            ApprovedRequests = leaveRequests.Count(x => x.Approved == true),
            PendingRequests = leaveRequests.Count(x => x.Approved == null),
            RejectedRequests = leaveRequests.Count(x => x.Approved == false),
            LeaveRequests = mapper.Map<List<LeaveRequestCollectionItemViewModel>>(leaveRequests)
        };

        return model;
    }
}
