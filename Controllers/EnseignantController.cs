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
    public class EnseignantController : Controller
    {
        private readonly stageContext _context;

        public EnseignantController(stageContext context)
        {
            _context = context;
        }

        // GET: Enseignant
        public async Task<IActionResult> Index()
        {
              return View(await _context.Enseignants.ToListAsync());
        }

        // GET: Enseignant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Enseignants == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignants
                .FirstOrDefaultAsync(m => m.Idfenseignant == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // GET: Enseignant/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enseignant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idfenseignant,Nomenseignant,Prenomenseignant,Datevisite")] Enseignant enseignant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enseignant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enseignant);
        }

        // GET: Enseignant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Enseignants == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignants.FindAsync(id);
            if (enseignant == null)
            {
                return NotFound();
            }
            return View(enseignant);
        }

        // POST: Enseignant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idfenseignant,Nomenseignant,Prenomenseignant,Datevisite")] Enseignant enseignant)
        {
            if (id != enseignant.Idfenseignant)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enseignant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnseignantExists(enseignant.Idfenseignant))
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
            return View(enseignant);
        }

        // GET: Enseignant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Enseignants == null)
            {
                return NotFound();
            }

            var enseignant = await _context.Enseignants
                .FirstOrDefaultAsync(m => m.Idfenseignant == id);
            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }

        // POST: Enseignant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Enseignants == null)
            {
                return Problem("Entity set 'stageContext.Enseignants'  is null.");
            }
            var enseignant = await _context.Enseignants.FindAsync(id);
            if (enseignant != null)
            {
                _context.Enseignants.Remove(enseignant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnseignantExists(int id)
        {
          return _context.Enseignants.Any(e => e.Idfenseignant == id);
        }
    }
}
