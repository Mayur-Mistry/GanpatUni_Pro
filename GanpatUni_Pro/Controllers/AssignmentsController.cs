using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GanpatUni_Pro.Data;
using GanpatUni_Pro.Models;

namespace GanpatUni_Pro.Controllers
{
    public class AssignmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assignments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Assignments.Include(a => a.Departments).Include(a => a.Group_Masters).Include(a => a.Mentors);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Assignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Departments)
                .Include(a => a.Group_Masters)
                .Include(a => a.Mentors)
                .FirstOrDefaultAsync(m => m.Assignment_Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // GET: Assignments/Create
        public IActionResult Create()
        {
            ViewData["Dept_Id"] = new SelectList(_context.Departments, "Dept_Id", "Dept_Name");
            ViewData["Group_Id"] = new SelectList(_context.Group_Masters, "Group_Id", "Group_Name");
            ViewData["Mentor_Id"] = new SelectList(_context.Mentors, "Mentor_Id", "Mentor_Id");
            return View();
        }

        // POST: Assignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Assignment_Id,Assignment_Title,Assignment_StartingDate,Assignment_EndingDate,Semester,Document,Mentor_Id,Dept_Id,Group_Id")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Dept_Id"] = new SelectList(_context.Departments, "Dept_Id", "Dept_Name", assignment.Dept_Id);
            ViewData["Group_Id"] = new SelectList(_context.Group_Masters, "Group_Id", "Group_Name", assignment.Group_Id);
            ViewData["Mentor_Id"] = new SelectList(_context.Mentors, "Mentor_Id", "Mentor_Id", assignment.Mentor_Id);
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            ViewData["Dept_Id"] = new SelectList(_context.Departments, "Dept_Id", "Dept_Name", assignment.Dept_Id);
            ViewData["Group_Id"] = new SelectList(_context.Group_Masters, "Group_Id", "Group_Name", assignment.Group_Id);
            ViewData["Mentor_Id"] = new SelectList(_context.Mentors, "Mentor_Id", "Mentor_Id", assignment.Mentor_Id);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Assignment_Id,Assignment_Title,Assignment_StartingDate,Assignment_EndingDate,Semester,Document,Mentor_Id,Dept_Id,Group_Id")] Assignment assignment)
        {
            if (id != assignment.Assignment_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignmentExists(assignment.Assignment_Id))
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
            ViewData["Dept_Id"] = new SelectList(_context.Departments, "Dept_Id", "Dept_Name", assignment.Dept_Id);
            ViewData["Group_Id"] = new SelectList(_context.Group_Masters, "Group_Id", "Group_Name", assignment.Group_Id);
            ViewData["Mentor_Id"] = new SelectList(_context.Mentors, "Mentor_Id", "Mentor_Id", assignment.Mentor_Id);
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments
                .Include(a => a.Departments)
                .Include(a => a.Group_Masters)
                .Include(a => a.Mentors)
                .FirstOrDefaultAsync(m => m.Assignment_Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignmentExists(int id)
        {
            return _context.Assignments.Any(e => e.Assignment_Id == id);
        }
    }
}
