using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using stages.Models;

namespace stages.Controllers
{
    public class DateController : Controller
    {
        private readonly stageContext _context;

        public DateController(stageContext context)
        {
            _context = context;
        }

        // GET: Date
        public async Task<IActionResult> Index()
        {
              return View(await _context.Dates.ToListAsync());
        }

        // GET: Date/Details/5
        public async Task<IActionResult> Details(DateOnly? id)
        {
            if (id == null || _context.Dates == null)
            {
                return NotFound();
            }

            var date = await _context.Dates
                .FirstOrDefaultAsync(m => m.Datecontact == id);
            if (date == null)
            {
                return NotFound();
            }

            return View(date);
        }

        // GET: Date/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Date/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Datecontact")] Date date)
        {
            if (ModelState.IsValid)
            {
                _context.Add(date);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(date);
        }

        // GET: Date/Edit/5
        public async Task<IActionResult> Edit(DateOnly? id)
        {
            if (id == null || _context.Dates == null)
            {
                return NotFound();
            }

            var date = await _context.Dates.FindAsync(id);
            if (date == null)
            {
                return NotFound();
            }
            return View(date);
        }

        // POST: Date/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DateOnly id, [Bind("Datecontact")] Date date)
        {
            if (id != date.Datecontact)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(date);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DateExists(date.Datecontact))
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
            return View(date);
        }

        // GET: Date/Delete/5
        public async Task<IActionResult> Delete(DateOnly? id)
        {
            if (id == null || _context.Dates == null)
            {
                return NotFound();
            }

            var date = await _context.Dates
                .FirstOrDefaultAsync(m => m.Datecontact == id);
            if (date == null)
            {
                return NotFound();
            }

            return View(date);
        }

        // POST: Date/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateOnly id)
        {
            if (_context.Dates == null)
            {
                return Problem("Entity set 'stageContext.Dates'  is null.");
            }
            var date = await _context.Dates.FindAsync(id);
            if (date != null)
            {
                _context.Dates.Remove(date);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DateExists(DateOnly id)
        {
          return _context.Dates.Any(e => e.Datecontact == id);
        }
    }
}
