using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using LeaveManagement.Business.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Common.Constants;

namespace LeaveManagement.Web.Controllers
{
    [Authorize(Roles = Roles.ADMINISTRATOR)]
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
