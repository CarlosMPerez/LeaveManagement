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

        // TO-DO Check there's a leave allocation created for leave type and user
        var empAllocVM = await allocRepo.GetAllocationsForEmployee(user.Id);
        bool allocExists = empAllocVM.LeaveAllocations.Count(x => x.LeaveType.Id == model.LeaveTypeId) > 0;
        if (!allocExists) throw new NoLeaveAllocationForUserException("You have no allocation for the selected Leave Type. Please contact an Admin.");

        // Check this single requested leave total days do not exceed the leave type default days
        var leaveType = await leaveTypeRepo.GetAsync(model.LeaveTypeId);
        int currentReqDays = (int)(model.EndDate - model.StartDate).Value.TotalDays;
        if (leaveType.DefaultDays < currentReqDays) throw new LeaveRequestExcessDaysException("Requested leave has allocated more days than the Leave Type allows.");

        // TO-DO Check if the sum of the total leave requests for the leave type and user does not exceed the allocation days
        // (TotalLeaveRequestTimeExceedsAllocationException)
        var totalApprovedDays = (await GetAllAsync(user.Id))
                                    .Where(x => x.LeaveTypeId == model.LeaveTypeId && x.Approved == true)
                                    .Sum(x => x.TotalLeaveDays);
        if (currentReqDays + totalApprovedDays > leaveType.DefaultDays) 
            throw new TotalLeaveRequestTimeExceedsAllocationException(String.Format(@"You have already approved {0} days for this type of leave. 
                                                Your request of {1} additional days exceeds the total days alloted for the type of leave.", 
                                                totalApprovedDays, currentReqDays));

        // If everything's alright
        var leaveRequest = mapper.Map<LeaveRequest>(model);
        leaveRequest.CreationDate = DateTime.Now;
        leaveRequest.ModificationDate = DateTime.Now;
        leaveRequest.RequestDate = DateTime.Now;
        leaveRequest.EmployeeId = user.Id;
        leaveRequest.TotalLeaveDays = (int)(model.EndDate - model.StartDate).Value.TotalDays;

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
                var alloc = await allocRepo.GetAllocation(leaveRequest.EmployeeId, leaveRequest.LeaveTypeId);
                alloc.NumberOfDays -= (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                alloc.ModificationDate = DateTime.Now;
                await allocRepo.UpdateAsync(alloc);
            }

            await UpdateAsync(leaveRequest);

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public async Task<LeaveRequestsAdminViewModel> GetAdminLeaveRequestList()
    {
        var leaveRequests = ctx.LeaveRequests
                                .Include(x => x.Employee)
                                .Include(x => x.LeaveType)
                                .Where(x => !x.Cancelled)
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
