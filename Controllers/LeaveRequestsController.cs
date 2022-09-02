using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.Contracts;
using Microsoft.AspNetCore.Authorization;
using LeaveManagement.Web.Configuration;
using LeaveManagement.Web.CustomExceptions;

namespace LeaveManagement.Web.Controllers
{
    [Authorize(Roles = RolesConstants.USER)]
    public class LeaveRequestsController : Controller
    {
        private readonly ApplicationDbContext ctx;
        private readonly ILeaveRequestRepository repo;

        public LeaveRequestsController(ApplicationDbContext context, ILeaveRequestRepository repository)
        {
            ctx = context;
            repo = repository;
        }

        // GET: LeaveRequests
        [Authorize(Roles = RolesConstants.ADMINISTRATOR)]
        public async Task<IActionResult> Index()
        {
            var model = await repo.GetAdminLeaveRequestList();
            return View(model);
        }

        // GET: LeaveRequests/Details/5
        [Authorize(Roles = RolesConstants.ADMINISTRATOR)]
        public async Task<IActionResult> Details(int? id)
        {
            var model = await repo.GetLeaveRequestAsync(id);
            if (model == null) return NotFound();
            
            return View(model);
        }

        [Authorize(Roles = RolesConstants.ADMINISTRATOR)]
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
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, "An error has ocurred. Please try again later.");
            }

            model.LeaveTypes = new SelectList(ctx.LeaveTypes, "Id", "Name", model.LeaveTypeId);
            return View(model);
        }

        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || ctx.LeaveRequests == null)
            {
                return NotFound();
            }

            var leaveRequest = await ctx.LeaveRequests.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeId"] = new SelectList(ctx.LeaveTypes, "Id", "Name", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StartDate,EndDate,RequestDate,RequestComments,Approved,Cancelled,LeaveTypeId,EmployeeId,Id,CreationDate,ModificationDate")] LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ctx.Update(leaveRequest);
                    await ctx.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["LeaveTypeId"] = new SelectList(ctx.LeaveTypes, "Id", "Name", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || ctx.LeaveRequests == null)
            {
                return NotFound();
            }

            var leaveRequest = await ctx.LeaveRequests
                .Include(l => l.Employee)
                .Include(l => l.LeaveType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ctx.LeaveRequests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LeaveRequests'  is null.");
            }
            var leaveRequest = await ctx.LeaveRequests.FindAsync(id);
            if (leaveRequest != null)
            {
                ctx.LeaveRequests.Remove(leaveRequest);
            }
            
            await ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveRequestExists(int id)
        {
          return (ctx.LeaveRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
