using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductionsProductionCompany.Data;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Controllers
{
    public class TimeClocksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TimeClocksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TimeClocks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TimeClocks.Include(t => t.Employee);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TimeClocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClock = await _context.TimeClocks
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (timeClock == null)
            {
                return NotFound();
            }

            return View(timeClock);
        }

        // GET: TimeClocks/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: TimeClocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClockInTime,ClockOutTime,Date,EmployeeId,ID")] TimeClock timeClock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeClock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", timeClock.EmployeeId);
            return View(timeClock);
        }

        // GET: TimeClocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClock = await _context.TimeClocks.FindAsync(id);
            if (timeClock == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", timeClock.EmployeeId);
            return View(timeClock);
        }

        // POST: TimeClocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClockInTime,ClockOutTime,Date,EmployeeId,ID")] TimeClock timeClock)
        {
            if (id != timeClock.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeClock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeClockExists(timeClock.ID))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", timeClock.EmployeeId);
            return View(timeClock);
        }

        // GET: TimeClocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeClock = await _context.TimeClocks
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (timeClock == null)
            {
                return NotFound();
            }

            return View(timeClock);
        }

        // POST: TimeClocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeClock = await _context.TimeClocks.FindAsync(id);
            _context.TimeClocks.Remove(timeClock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeClockExists(int id)
        {
            return _context.TimeClocks.Any(e => e.ID == id);
        }
    }
}
