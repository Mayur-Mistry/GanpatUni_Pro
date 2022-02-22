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
    public class MentorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MentorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mentors
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Mentors.Include(m => m.Departments).Include(m => m.Users);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Mentors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentors
                .Include(m => m.Departments)
                .Include(m => m.Users)
                .FirstOrDefaultAsync(m => m.Mentor_Id == id);
            if (mentor == null)
            {
                return NotFound();
            }

            return View(mentor);
        }

        // GET: Mentors/Create
        public IActionResult Create()
        {
            ViewData["Dept_Id"] = new SelectList(_context.Departments, "Dept_Id", "Dept_Name");
            ViewData["User_Id"] = new SelectList(_context.Userms, "User_id", "Address");
            return View();
        }

        // POST: Mentors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mentor_Id,Dept_Id,User_Id")] Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mentor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Dept_Id"] = new SelectList(_context.Departments, "Dept_Id", "Dept_Name", mentor.Dept_Id);
            ViewData["User_Id"] = new SelectList(_context.Userms, "User_id", "Address", mentor.User_Id);
            return View(mentor);
        }

        // GET: Mentors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentors.FindAsync(id);
            if (mentor == null)
            {
                return NotFound();
            }
            ViewData["Dept_Id"] = new SelectList(_context.Departments, "Dept_Id", "Dept_Name", mentor.Dept_Id);
            ViewData["User_Id"] = new SelectList(_context.Userms, "User_id", "Address", mentor.User_Id);
            return View(mentor);
        }

        // POST: Mentors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mentor_Id,Dept_Id,User_Id")] Mentor mentor)
        {
            if (id != mentor.Mentor_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mentor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorExists(mentor.Mentor_Id))
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
            ViewData["Dept_Id"] = new SelectList(_context.Departments, "Dept_Id", "Dept_Name", mentor.Dept_Id);
            ViewData["User_Id"] = new SelectList(_context.Userms, "User_id", "Address", mentor.User_Id);
            return View(mentor);
        }

        // GET: Mentors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentors
                .Include(m => m.Departments)
                .Include(m => m.Users)
                .FirstOrDefaultAsync(m => m.Mentor_Id == id);
            if (mentor == null)
            {
                return NotFound();
            }

            return View(mentor);
        }

        // POST: Mentors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mentor = await _context.Mentors.FindAsync(id);
            _context.Mentors.Remove(mentor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MentorExists(int id)
        {
            return _context.Mentors.Any(e => e.Mentor_Id == id);
        }
    }
}
