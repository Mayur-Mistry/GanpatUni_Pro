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
    public class Group_MasterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Group_MasterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Group_Master
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Group_Masters.Include(g => g.Mentors);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Group_Master/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group_Master = await _context.Group_Masters
                .Include(g => g.Mentors)
                .FirstOrDefaultAsync(m => m.Group_Id == id);
            if (group_Master == null)
            {
                return NotFound();
            }

            return View(group_Master);
        }

        // GET: Group_Master/Create
        public IActionResult Create()
        {
            ViewData["Mentor_Id"] = new SelectList(_context.Mentors, "Mentor_Id", "Mentor_Id");
            return View();
        }

        // POST: Group_Master/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Group_Id,Group_Name,Group_Image,Group_desc,Mentor_Id")] Group_Master group_Master)
        {
            if (ModelState.IsValid)
            {
                _context.Add(group_Master);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mentor_Id"] = new SelectList(_context.Mentors, "Mentor_Id", "Mentor_Id", group_Master.Mentor_Id);
            return View(group_Master);
        }

        // GET: Group_Master/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group_Master = await _context.Group_Masters.FindAsync(id);
            if (group_Master == null)
            {
                return NotFound();
            }
            ViewData["Mentor_Id"] = new SelectList(_context.Mentors, "Mentor_Id", "Mentor_Id", group_Master.Mentor_Id);
            return View(group_Master);
        }

        // POST: Group_Master/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Group_Id,Group_Name,Group_Image,Group_desc,Mentor_Id")] Group_Master group_Master)
        {
            if (id != group_Master.Group_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(group_Master);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Group_MasterExists(group_Master.Group_Id))
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
            ViewData["Mentor_Id"] = new SelectList(_context.Mentors, "Mentor_Id", "Mentor_Id", group_Master.Mentor_Id);
            return View(group_Master);
        }

        // GET: Group_Master/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group_Master = await _context.Group_Masters
                .Include(g => g.Mentors)
                .FirstOrDefaultAsync(m => m.Group_Id == id);
            if (group_Master == null)
            {
                return NotFound();
            }

            return View(group_Master);
        }

        // POST: Group_Master/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var group_Master = await _context.Group_Masters.FindAsync(id);
            _context.Group_Masters.Remove(group_Master);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Group_MasterExists(int id)
        {
            return _context.Group_Masters.Any(e => e.Group_Id == id);
        }
    }
}
