using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using AutoMapper;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext ctx;
        private readonly IMapper mapper;

        public LeaveTypesController(ApplicationDbContext context, IMapper mapper)
        {
            ctx = context;
            this.mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var leaveTypes = mapper.Map<List<LeaveTypeCollectionItemViewModel>>(await ctx.LeaveTypes.ToListAsync());
              
            return leaveTypes != null ? 
                          View(leaveTypes) :
                          Problem("Entity set 'LeaveTypes' is null.");
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || ctx.LeaveTypes == null) return NotFound();

            var leaveType = await ctx.LeaveTypes.FindAsync(id);
            if (leaveType == null) return NotFound();
            var leaveTypeVM = mapper.Map<LeaveTypeDetailsViewModel>(leaveType);

            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveTypeCreateViewModel leaveTypeVM)
        {
            if (ModelState.IsValid)
            {
                var leaveType = mapper.Map<LeaveType>(leaveTypeVM);
                leaveType.CreationDate = DateTime.Now;
                leaveType.ModificationDate = DateTime.Now;
                ctx.Add(leaveType);
                await ctx.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || ctx.LeaveTypes == null) return NotFound();

            var leaveType = await ctx.LeaveTypes.FindAsync(id);
            if (leaveType == null) return NotFound();
            var leaveTypeVM = mapper.Map<LeaveTypeEditViewModel>(leaveType);

            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LeaveTypeEditViewModel leaveTypeVM)
        {
            if (id != leaveTypeVM.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = mapper.Map<LeaveType>(leaveTypeVM);
                    leaveType.ModificationDate = DateTime.Now;
                    ctx.Update(leaveType);
                    await ctx.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(leaveTypeVM.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        //// NOT USED REPLACED BY JAVASCRIPT CONFIRMATION DIALOG
        //// GET: LeaveTypes/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || ctx.LeaveTypes == null) return NotFound();

        //    var leaveType = await ctx.LeaveTypes
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (leaveType == null) return NotFound();

        //    return View(leaveType);
        //}

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ctx.LeaveTypes == null) return Problem("Entity set 'LeaveTypes' is null.");

            var leaveType = await ctx.LeaveTypes.FindAsync(id);
            if (leaveType != null) ctx.LeaveTypes.Remove(leaveType);
            
            await ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeExists(int id)
        {
          return (ctx.LeaveTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
