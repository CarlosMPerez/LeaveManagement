using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Data;
using AutoMapper;
using LeaveManagement.Web.Models;
using LeaveManagement.Web.Contracts;

namespace LeaveManagement.Web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository repo;
        private readonly IMapper mapper;

        public LeaveTypesController(ILeaveTypeRepository repository, IMapper mapper)
        {
            repo = repository;
            this.mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var leaveTypes = mapper.Map<List<LeaveTypeCollectionItemViewModel>>(await repo.GetAllAsync());
              
            return leaveTypes != null ? 
                          View(leaveTypes) :
                          Problem("Entity set 'LeaveTypes' is null.");
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var leaveType = await repo.GetAsync(id);
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
                await repo.AddAsync(leaveType);
                return RedirectToAction(nameof(Index));
            }
            
            return View(leaveTypeVM);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var leaveType = await repo.GetAsync(id);
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
                    await repo.UpdateAsync(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await repo.Exists(leaveTypeVM.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeVM);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
