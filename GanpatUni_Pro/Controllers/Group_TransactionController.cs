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
    public class Group_TransactionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Group_TransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Group_Transaction
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Group_Transactions.Include(g => g.Group_Masters).Include(g => g.Students);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Group_Transaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group_Transaction = await _context.Group_Transactions
                .Include(g => g.Group_Masters)
                .Include(g => g.Students)
                .FirstOrDefaultAsync(m => m.GroupTransaction_Id == id);
            if (group_Transaction == null)
            {
                return NotFound();
            }

            return View(group_Transaction);
        }

        // GET: Group_Transaction/Create
        public IActionResult Create()
        {
            ViewData["Group_Id"] = new SelectList(_context.Group_Masters, "Group_Id", "Group_Name");
            ViewData["Student_Id"] = new SelectList(_context.Student, "Student_Id", "Enroll_No");
            return View();
        }

        // POST: Group_Transaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupTransaction_Id,Group_Id,Student_Id")] Group_Transaction group_Transaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(group_Transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Group_Id"] = new SelectList(_context.Group_Masters, "Group_Id", "Group_Name", group_Transaction.Group_Id);
            ViewData["Student_Id"] = new SelectList(_context.Student, "Student_Id", "Enroll_No", group_Transaction.Student_Id);
            return View(group_Transaction);
        }

        // GET: Group_Transaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group_Transaction = await _context.Group_Transactions.FindAsync(id);
            if (group_Transaction == null)
            {
                return NotFound();
            }
            ViewData["Group_Id"] = new SelectList(_context.Group_Masters, "Group_Id", "Group_Name", group_Transaction.Group_Id);
            ViewData["Student_Id"] = new SelectList(_context.Student, "Student_Id", "Enroll_No", group_Transaction.Student_Id);
            return View(group_Transaction);
        }

        // POST: Group_Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupTransaction_Id,Group_Id,Student_Id")] Group_Transaction group_Transaction)
        {
            if (id != group_Transaction.GroupTransaction_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(group_Transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Group_TransactionExists(group_Transaction.GroupTransaction_Id))
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
            ViewData["Group_Id"] = new SelectList(_context.Group_Masters, "Group_Id", "Group_Name", group_Transaction.Group_Id);
            ViewData["Student_Id"] = new SelectList(_context.Student, "Student_Id", "Enroll_No", group_Transaction.Student_Id);
            return View(group_Transaction);
        }

        // GET: Group_Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group_Transaction = await _context.Group_Transactions
                .Include(g => g.Group_Masters)
                .Include(g => g.Students)
                .FirstOrDefaultAsync(m => m.GroupTransaction_Id == id);
            if (group_Transaction == null)
            {
                return NotFound();
            }

            return View(group_Transaction);
        }

        // POST: Group_Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var group_Transaction = await _context.Group_Transactions.FindAsync(id);
            _context.Group_Transactions.Remove(group_Transaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Group_TransactionExists(int id)
        {
            return _context.Group_Transactions.Any(e => e.GroupTransaction_Id == id);
        }
    }
}
