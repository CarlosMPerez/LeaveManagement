using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using LeaveManagement.Data;
using LeaveManagement.Common.Models;
using LeaveManagement.Business.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Common.Constants;
using LeaveManagement.Web.CustomExceptions;

namespace LeaveManagement.Web.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private readonly ILogger<LeaveRequestsController> logger;
        private readonly ApplicationDbContext ctx;
        private readonly ILeaveRequestRepository repo;

        public LeaveRequestsController(ILogger<LeaveRequestsController> logger, ApplicationDbContext context, ILeaveRequestRepository repository)
        {
            this.logger = logger;
            ctx = context;
            repo = repository;
        }

        // GET: LeaveRequests

        [Authorize(Roles = Roles.ADMINISTRATOR)]
        public async Task<IActionResult> Index()
        {
            var model = await repo.GetAdminLeaveRequestList();
            return View(model);
        }

        // GET: LeaveRequests/Details/5
        [Authorize(Roles = Roles.ADMINISTRATOR)]
        public async Task<IActionResult> Details(int? id)
        {
            var model = await repo.GetLeaveRequestAsync(id);
            if (model == null) return NotFound();
            
            return View(model);
        }

        [Authorize(Roles = Roles.ADMINISTRATOR)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveRequest(int id, bool approved)
        {
            try
            {
                await repo.ChangeApprovalStatus(id, approved);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Approving Request");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            var model = new LeaveRequestCreateViewModel
            {
                LeaveTypes = new SelectList(ctx.LeaveTypes, "Id", "Name"),
            };
            return View(model);
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequestCreateViewModel model)
        {
            try 
            {
                if (ModelState.IsValid)
                {
                    await repo.CreateLeaveRequest(model);
                    return RedirectToAction("ListRequests", "Employees");
                }
            }
            catch (LeaveRequestExcessDaysException ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            catch (NoLeaveAllocationForUserException ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            catch (TotalLeaveRequestTimeExceedsAllocationException ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error Creating Request");
                ModelState.AddModelError(String.Empty, "An error has ocurred. Please try again later.");
            }

            model.LeaveTypes = new SelectList(ctx.LeaveTypes, "Id", "Name", model.LeaveTypeId);
            return View(model);
        }

        private bool LeaveRequestExists(int id)
        {
          return (ctx.LeaveRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
