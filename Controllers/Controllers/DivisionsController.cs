using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductionsProductionCompany.Data;
using ProductionsProductionCompany.Data.DAL;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Controllers
{
    public class DivisionsController : Controller
    {
        private IDivisionRepo divisionRepo;

        public DivisionsController()
        {
            this.divisionRepo = new DivisionRepo(new ApplicationDbContext());
        }

        public DivisionsController(IDivisionRepo divisionRepo)
        {
            this.divisionRepo = divisionRepo;
        }

        // GET: Divisions
        public async Task<IActionResult> Index()
        {
            //NOT SURE HOW TO GET THE LIST OF DIVISIONS AND HAVE IT INCLUDE THE DIVISIONMANAGER FIELD
            var applicationDbContext = divisionRepo.GetDivisions().Include(d => d.DivisionManager);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Divisions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var division = await _context.Divisions
                .Include(d => d.DivisionManager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (division == null)
            {
                return NotFound();
            }

            return View(division);
        }

        // GET: Divisions/Create
        public IActionResult Create()
        {
            ViewData["DivisionManagerId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: Divisions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DivisionManagerId,Title,Budget,ID")] Division division)
        {
            if (ModelState.IsValid)
            {
                _context.Add(division);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DivisionManagerId"] = new SelectList(_context.Employees, "Id", "Id", division.DivisionManagerId);
            return View(division);
        }

        // GET: Divisions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var division = await _context.Divisions.FindAsync(id);
            if (division == null)
            {
                return NotFound();
            }
            ViewData["DivisionManagerId"] = new SelectList(_context.Employees, "Id", "Id", division.DivisionManagerId);
            return View(division);
        }

        // POST: Divisions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DivisionManagerId,Title,Budget,ID")] Division division)
        {
            if (id != division.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(division);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DivisionExists(division.Id))
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
            ViewData["DivisionManagerId"] = new SelectList(_context.Employees, "Id", "Id", division.DivisionManagerId);
            return View(division);
        }

        // GET: Divisions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var division = await _context.Divisions
                .Include(d => d.DivisionManager)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (division == null)
            {
                return NotFound();
            }

            return View(division);
        }

        // POST: Divisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var division = await _context.Divisions.FindAsync(id);
            _context.Divisions.Remove(division);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DivisionExists(int id)
        {
            return _context.Divisions.Any(e => e.Id == id);
        }
    }
}
