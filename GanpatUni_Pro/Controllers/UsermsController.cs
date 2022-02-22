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
    public class UsermsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsermsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Userms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Userms.ToListAsync());
        }

        // GET: Userms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userm = await _context.Userms
                .FirstOrDefaultAsync(m => m.User_id == id);
            if (userm == null)
            {
                return NotFound();
            }

            return View(userm);
        }

        // GET: Userms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Userms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("User_id,User_type,Email_id,Password,Name,Address,Mobile_no,DateOfBirth,Pincode")] Userm userm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userm);
        }

        // GET: Userms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userm = await _context.Userms.FindAsync(id);
            if (userm == null)
            {
                return NotFound();
            }
            return View(userm);
        }

        // POST: Userms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("User_id,User_type,Email_id,Password,Name,Address,Mobile_no,DateOfBirth,Pincode")] Userm userm)
        {
            if (id != userm.User_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsermExists(userm.User_id))
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
            return View(userm);
        }

        // GET: Userms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userm = await _context.Userms
                .FirstOrDefaultAsync(m => m.User_id == id);
            if (userm == null)
            {
                return NotFound();
            }

            return View(userm);
        }

        // POST: Userms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userm = await _context.Userms.FindAsync(id);
            _context.Userms.Remove(userm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsermExists(int id)
        {
            return _context.Userms.Any(e => e.User_id == id);
        }
    }
}
