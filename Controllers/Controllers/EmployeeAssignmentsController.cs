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
    public class EmployeeAssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeeAssignments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeeAssignments.Include(e => e.Division).Include(e => e.Employee).Include(e => e.Group);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeeAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAssignment = await _context.EmployeeAssignments
                .Include(e => e.Division)
                .Include(e => e.Employee)
                .Include(e => e.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeAssignment == null)
            {
                return NotFound();
            }

            return View(employeeAssignment);
        }

        // GET: EmployeeAssignments/Create
        public IActionResult Create()
        {
            ViewData["DivisionID"] = new SelectList(_context.Divisions, "ID", "ID");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID");
            return View();
        }

        // POST: EmployeeAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,DivisionID,GroupID,ID")] EmployeeAssignment employeeAssignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeAssignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DivisionID"] = new SelectList(_context.Divisions, "ID", "ID", employeeAssignment.DivisionID);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", employeeAssignment.EmployeeId);
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID", employeeAssignment.GroupID);
            return View(employeeAssignment);
        }

        // GET: EmployeeAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAssignment = await _context.EmployeeAssignments.FindAsync(id);
            if (employeeAssignment == null)
            {
                return NotFound();
            }
            ViewData["DivisionID"] = new SelectList(_context.Divisions, "ID", "ID", employeeAssignment.DivisionID);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", employeeAssignment.EmployeeId);
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID", employeeAssignment.GroupID);
            return View(employeeAssignment);
        }

        // POST: EmployeeAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,DivisionID,GroupID,ID")] EmployeeAssignment employeeAssignment)
        {
            if (id != employeeAssignment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeAssignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeAssignmentExists(employeeAssignment.Id))
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
            ViewData["DivisionID"] = new SelectList(_context.Divisions, "ID", "ID", employeeAssignment.DivisionID);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", employeeAssignment.EmployeeId);
            ViewData["GroupID"] = new SelectList(_context.Groups, "ID", "ID", employeeAssignment.GroupID);
            return View(employeeAssignment);
        }

        // GET: EmployeeAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeAssignment = await _context.EmployeeAssignments
                .Include(e => e.Division)
                .Include(e => e.Employee)
                .Include(e => e.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeAssignment == null)
            {
                return NotFound();
            }

            return View(employeeAssignment);
        }

        // POST: EmployeeAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeAssignment = await _context.EmployeeAssignments.FindAsync(id);
            _context.EmployeeAssignments.Remove(employeeAssignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeAssignmentExists(int id)
        {
            return _context.EmployeeAssignments.Any(e => e.Id == id);
        }
    }
}
