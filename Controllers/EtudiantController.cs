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
    public class EtudiantController : Controller
    {
        private readonly stageContext _context;

        public EtudiantController(stageContext context)
        {
            _context = context;
        }

        // GET: Etudiant
        public async Task<IActionResult> Index()
        {
            var stageContext = _context.Etudiants.Include(e => e.ConNoconventionNavigation).Include(e => e.NoconventionNavigation);
            return View(await stageContext.ToListAsync());
        }

        // GET: Etudiant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Etudiants == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiants
                .Include(e => e.ConNoconventionNavigation)
                .Include(e => e.NoconventionNavigation)
                .FirstOrDefaultAsync(m => m.Idfetudiant == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // GET: Etudiant/Create
        public IActionResult Create()
        {
            ViewData["ConNoconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention");
            ViewData["Noconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention");
            return View();
        }

        // POST: Etudiant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idfetudiant,Noconvention,ConNoconvention,Nometudiant,Prenometudiant")] Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etudiant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConNoconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention", etudiant.ConNoconvention);
            ViewData["Noconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention", etudiant.Noconvention);
            return View(etudiant);
        }

        // GET: Etudiant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Etudiants == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }
            ViewData["ConNoconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention", etudiant.ConNoconvention);
            ViewData["Noconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention", etudiant.Noconvention);
            return View(etudiant);
        }

        // POST: Etudiant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idfetudiant,Noconvention,ConNoconvention,Nometudiant,Prenometudiant")] Etudiant etudiant)
        {
            if (id != etudiant.Idfetudiant)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etudiant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtudiantExists(etudiant.Idfetudiant))
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
            ViewData["ConNoconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention", etudiant.ConNoconvention);
            ViewData["Noconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention", etudiant.Noconvention);
            return View(etudiant);
        }

        // GET: Etudiant/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Etudiants == null)
            {
                return NotFound();
            }

            var etudiant = await _context.Etudiants
                .Include(e => e.ConNoconventionNavigation)
                .Include(e => e.NoconventionNavigation)
                .FirstOrDefaultAsync(m => m.Idfetudiant == id);
            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        // POST: Etudiant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Etudiants == null)
            {
                return Problem("Entity set 'stageContext.Etudiants'  is null.");
            }
            var etudiant = await _context.Etudiants.FindAsync(id);
            if (etudiant != null)
            {
                _context.Etudiants.Remove(etudiant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtudiantExists(int id)
        {
          return _context.Etudiants.Any(e => e.Idfetudiant == id);
        }
    }
}
