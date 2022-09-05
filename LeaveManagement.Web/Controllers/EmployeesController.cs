using AutoMapper;
using LeaveManagement.Common.Constants;
using LeaveManagement.Business.Contracts;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LeaveManagement.Web.Controllers;

public class EmployeesController : Controller
{
    private readonly UserManager<Employee> userManager;
    private readonly IMapper mapper;
    private readonly ILeaveAllocationRepository allocRepo;
    private readonly ILeaveTypeRepository leaveTypeRepo;
    private readonly ILeaveRequestRepository leaveReqRepo;

    public EmployeesController(UserManager<Employee> userManager, 
                                IMapper mapper, 
                                ILeaveAllocationRepository allocRepo, 
                                ILeaveTypeRepository leaveTypeRepo, 
                                ILeaveRequestRepository leaveReqRepo)
    {
        this.userManager = userManager;
        this.mapper = mapper;
        this.allocRepo = allocRepo;
        this.leaveTypeRepo = leaveTypeRepo;
        this.leaveReqRepo = leaveReqRepo;
    }

    // GET: EmployeesController
    [Authorize(Roles = Roles.ADMINISTRATOR)]
    public async Task<IActionResult> Index()
    {
        var employees = await userManager.GetUsersInRoleAsync(Roles.USER);
        var model = mapper.Map<List<EmployeeCollectionItemViewModel>>(employees);
        return View(model);
    }

    // GET: EmployeesController/ListAllocations/"guid"
    [Authorize(Roles = Roles.ADMINISTRATOR)]
    public async Task<ActionResult> ListAllocations(string id)
    {
        var empAlloc = await allocRepo.GetAllocationsForEmployee(id);
        return View(empAlloc);
    }

    // GET: EmployeesController/EditAllocation/5
    [Authorize(Roles = Roles.ADMINISTRATOR)]
    public async Task<IActionResult> EditAllocation(int id)
    {
        var allocVM = await allocRepo.GetAllocation(id);
        if (allocVM == null) return NotFound();

        return View(allocVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = Roles.ADMINISTRATOR)]
    public async Task<IActionResult> EditAllocation(LeaveAllocationEditViewModel model)
    {
        // Stateless, so I have to re-get 
        model.Employee = mapper.Map<EmployeeEditViewModel>(await userManager.FindByIdAsync(model.EmployeeId));
        model.LeaveType = mapper.Map<LeaveTypeEditViewModel>(await leaveTypeRepo.GetAsync(model.LeaveTypeId));

        try
        {
            if (ModelState.IsValid)
            {
                var leaveAlloc = await allocRepo.GetAsync(model.Id);
                if (leaveAlloc == null) return NotFound();

                leaveAlloc.NumberOfDays = model.NumberOfDays;

                await allocRepo.UpdateAsync(leaveAlloc);

                return RedirectToAction(nameof(ListAllocations), new { id = model.Employee.Id });
            }
        }
        catch(Exception ex)
        {
            ModelState.AddModelError(String.Empty, "An error has ocurred. Please try again later.");
        }

        return View(model);
    }

    [Authorize(Roles = Roles.ADMINISTRATOR)]
    public async Task<IActionResult> RemoveAllocation(string employeeId, int id)
    {
        await allocRepo.DeleteAsync(id);
        return RedirectToAction(nameof(ListAllocations), new { id = employeeId });
    }

    [Authorize(Roles = Roles.USER)]
    public async Task<IActionResult> ListRequests()
    {
        var model = await leaveReqRepo.GetCurrentUserLeaveRequestsDetails();
        return View(model);
    }

    [Authorize(Roles = Roles.USER)]
    public async Task<IActionResult> CancelLeaveRequest(int id)
    {
        var model = await leaveReqRepo.GetSimpleLeaveRequestAsync(id);
        model.Cancelled = true;
        await leaveReqRepo.UpdateAsync(model);


        var returnModel = await leaveReqRepo.GetCurrentUserLeaveRequestsDetails();
        return View(nameof(ListRequests), returnModel);
    }

}
