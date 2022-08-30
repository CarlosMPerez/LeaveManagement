using AutoMapper;
using LeaveManagement.Web.Configuration;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.Json;

namespace LeaveManagement.Web.Controllers;

[Authorize(Roles = RolesConstants.ADMINISTRATOR)]
public class EmployeesController : Controller
{
    private readonly UserManager<Employee> userManager;
    private readonly IMapper mapper;
    private readonly ILeaveAllocationRepository allocRepo;
    private readonly ILeaveTypeRepository leaveTypeRepo;

    public EmployeesController(UserManager<Employee> userManager, 
                                IMapper mapper, 
                                ILeaveAllocationRepository allocRepo, 
                                ILeaveTypeRepository leaveTypeRepo)
    {
        this.userManager = userManager;
        this.mapper = mapper;
        this.allocRepo = allocRepo;
        this.leaveTypeRepo = leaveTypeRepo;
    }

    // GET: EmployeesController
    public async Task<IActionResult> Index()
    {
        var employees = await userManager.GetUsersInRoleAsync(RolesConstants.USER);
        var model = mapper.Map<List<EmployeeCollectionItemViewModel>>(employees);
        return View(model);
    }

    // GET: EmployeesController/ViewAllocations/"guid"
    public async Task<ActionResult> ViewAllocations(string id)
    {
        var employee = await userManager.FindByIdAsync(id);
        var empAlloc = mapper.Map<EmployeeAllocationViewModel>(employee);
        empAlloc.LeaveAllocations = mapper.Map<List<LeaveAllocationCollectionItemViewModel>>(await allocRepo.GetEmployeeAllocations(id));

        return View(empAlloc);
    }

    // GET: EmployeesController/EditAllocation/5
    public async Task<IActionResult> EditAllocation(int id)
    {
        var alloc = await allocRepo.GetAsync(id);
        if (alloc == null) return NotFound();
        var allocVM = mapper.Map<LeaveAllocationEditViewModel>(alloc);
        // compose object
        allocVM.Employee = mapper.Map<EmployeeCollectionItemViewModel>(await userManager.FindByIdAsync(alloc.EmployeeId));
        allocVM.LeaveType = mapper.Map<LeaveTypeCollectionItemViewModel>(await leaveTypeRepo.GetAsync(alloc.LeaveTypeId));

        return View(allocVM);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditAllocation(int id, LeaveAllocationEditViewModel model)
    {
        try
        {
            // Instead of simply saving EmployeeId and LeaveTypeId in the hidden fields of the form and 
            // and having to re-query the server for them each server trip, we have saved them in the hidden input
            // as serialized versions of them, and then deserialize them here
            model.Employee = JsonSerializer.Deserialize<EmployeeCollectionItemViewModel>(model.EmployeeSerialized);
            model.LeaveType = JsonSerializer.Deserialize<LeaveTypeCollectionItemViewModel>(model.LeaveTypeSerialized);
            
            ModelState.Remove("Employee");
            ModelState.Remove("LeaveType");

            if (ModelState.IsValid)
            {
                var leaveAlloc = await allocRepo.GetAsync(id);
                if (leaveAlloc == null) return NotFound();

                leaveAlloc.Period = model.Period;
                leaveAlloc.NumberOfDays = model.NumberOfDays;
                leaveAlloc.ModificationDate = DateTime.Now;

                await allocRepo.UpdateAsync(leaveAlloc);

                return RedirectToAction(nameof(ViewAllocations), new { id = model.Employee.Id });
            }
        }
        catch(Exception ex)
        {
            ModelState.AddModelError(String.Empty, "An error has ocurred. Please try again later.");
        }

        return View(model);
    }
}
