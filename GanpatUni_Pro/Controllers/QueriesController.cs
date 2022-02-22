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
    public class QueriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QueriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Queries
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Queries.Include(q => q.Mentors).Include(q => q.Users);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Queries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = await _context.Queries
                .Include(q => q.Mentors)
                .Include(q => q.Users)
                .FirstOrDefaultAsync(m => m.Query_Id == id);
            if (query == null)
            {
                return NotFound();
            }

            return View(query);
        }

        // GET: Queries/Create
        public IActionResult Create()
        {
            ViewData["Mentor_id"] = new SelectList(_context.Mentors, "Mentor_Id", "Mentor_Id");
            ViewData["User_Id"] = new SelectList(_context.Userms, "User_id", "Address");
            return View();
        }

        // POST: Queries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Query_Id,User_Type,Query_Desc,Query_Date,Response,User_Id,Mentor_id")] Query query)
        {
            if (ModelState.IsValid)
            {
                _context.Add(query);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Mentor_id"] = new SelectList(_context.Mentors, "Mentor_Id", "Mentor_Id", query.Mentor_id);
            ViewData["User_Id"] = new SelectList(_context.Userms, "User_id", "Address", query.User_Id);
            return View(query);
        }

        // GET: Queries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = await _context.Queries.FindAsync(id);
            if (query == null)
            {
                return NotFound();
            }
            ViewData["Mentor_id"] = new SelectList(_context.Mentors, "Mentor_Id", "Mentor_Id", query.Mentor_id);
            ViewData["User_Id"] = new SelectList(_context.Userms, "User_id", "Address", query.User_Id);
            return View(query);
        }

        // POST: Queries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Query_Id,User_Type,Query_Desc,Query_Date,Response,User_Id,Mentor_id")] Query query)
        {
            if (id != query.Query_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(query);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QueryExists(query.Query_Id))
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
            ViewData["Mentor_id"] = new SelectList(_context.Mentors, "Mentor_Id", "Mentor_Id", query.Mentor_id);
            ViewData["User_Id"] = new SelectList(_context.Userms, "User_id", "Address", query.User_Id);
            return View(query);
        }

        // GET: Queries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var query = await _context.Queries
                .Include(q => q.Mentors)
                .Include(q => q.Users)
                .FirstOrDefaultAsync(m => m.Query_Id == id);
            if (query == null)
            {
                return NotFound();
            }

            return View(query);
        }

        // POST: Queries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var query = await _context.Queries.FindAsync(id);
            _context.Queries.Remove(query);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QueryExists(int id)
        {
            return _context.Queries.Any(e => e.Query_Id == id);
        }
    }
}
