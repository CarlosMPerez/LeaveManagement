using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using AutoMapper;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Web.Configuration;

namespace LeaveManagement.Web.Controllers
{
    [Authorize(Roles = RolesConstants.ADMINISTRATOR)]
    public class LeaveAllocationController : Controller
    {
        private readonly ILeaveAllocationRepository repo;
        private readonly IMapper mapper;

        public LeaveAllocationController(ILeaveAllocationRepository repository, IMapper mapper)
        {
            repo = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AllocateLeave(int id)
        {
            await repo.AllocateLeaveToAllEmployees(id);
            return RedirectToAction(nameof(Index), "LeaveTypes");
        }
    }
}
