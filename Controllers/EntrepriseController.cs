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
    public class EntrepriseController : Controller
    {
        private readonly stageContext _context;

        public EntrepriseController(stageContext context)
        {
            _context = context;
        }

        // GET: Entreprise
        public async Task<IActionResult> Index()
        {
            var stageContext = _context.Entreprises.Include(e => e.IdfenseignantNavigation);
            return View(await stageContext.ToListAsync());
        }

        // GET: Entreprise/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Entreprises == null)
            {
                return NotFound();
            }

            var entreprise = await _context.Entreprises
                .Include(e => e.IdfenseignantNavigation)
                .FirstOrDefaultAsync(m => m.Noentreprise == id);
            if (entreprise == null)
            {
                return NotFound();
            }

            return View(entreprise);
        }

        // GET: Entreprise/Create
        public IActionResult Create()
        {
            ViewData["Idfenseignant"] = new SelectList(_context.Enseignants, "Idfenseignant", "Idfenseignant");
            return View();
        }

        // POST: Entreprise/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Noentreprise,Idfenseignant,Nomentreprise,Addresse")] Entreprise entreprise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entreprise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idfenseignant"] = new SelectList(_context.Enseignants, "Idfenseignant", "Idfenseignant", entreprise.Idfenseignant);
            return View(entreprise);
        }

        // GET: Entreprise/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Entreprises == null)
            {
                return NotFound();
            }

            var entreprise = await _context.Entreprises.FindAsync(id);
            if (entreprise == null)
            {
                return NotFound();
            }
            ViewData["Idfenseignant"] = new SelectList(_context.Enseignants, "Idfenseignant", "Idfenseignant", entreprise.Idfenseignant);
            return View(entreprise);
        }

        // POST: Entreprise/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Noentreprise,Idfenseignant,Nomentreprise,Addresse")] Entreprise entreprise)
        {
            if (id != entreprise.Noentreprise)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entreprise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrepriseExists(entreprise.Noentreprise))
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
            ViewData["Idfenseignant"] = new SelectList(_context.Enseignants, "Idfenseignant", "Idfenseignant", entreprise.Idfenseignant);
            return View(entreprise);
        }

        // GET: Entreprise/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Entreprises == null)
            {
                return NotFound();
            }

            var entreprise = await _context.Entreprises
                .Include(e => e.IdfenseignantNavigation)
                .FirstOrDefaultAsync(m => m.Noentreprise == id);
            if (entreprise == null)
            {
                return NotFound();
            }

            return View(entreprise);
        }

        // POST: Entreprise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Entreprises == null)
            {
                return Problem("Entity set 'stageContext.Entreprises'  is null.");
            }
            var entreprise = await _context.Entreprises.FindAsync(id);
            if (entreprise != null)
            {
                _context.Entreprises.Remove(entreprise);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrepriseExists(int id)
        {
          return _context.Entreprises.Any(e => e.Noentreprise == id);
        }
    }
}
