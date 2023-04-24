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
    public class PropositionsstageController : Controller
    {
        private readonly stageContext _context;

        public PropositionsstageController(stageContext context)
        {
            _context = context;
        }

        // GET: Propositionsstage
        public async Task<IActionResult> Index()
        {
            var stageContext = _context.Propositionsstages.Include(p => p.ConNoconventionNavigation).Include(p => p.NoconventionNavigation).Include(p => p.NoentrepriseNavigation);
            return View(await stageContext.ToListAsync());
        }

        // GET: Propositionsstage/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Propositionsstages == null)
            {
                return NotFound();
            }

            var propositionsstage = await _context.Propositionsstages
                .Include(p => p.ConNoconventionNavigation)
                .Include(p => p.NoconventionNavigation)
                .Include(p => p.NoentrepriseNavigation)
                .FirstOrDefaultAsync(m => m.Noproposition == id);
            if (propositionsstage == null)
            {
                return NotFound();
            }

            return View(propositionsstage);
        }

        // GET: Propositionsstage/Create
        public IActionResult Create()
        {
            ViewData["ConNoconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention");
            ViewData["Noconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention");
            ViewData["Noentreprise"] = new SelectList(_context.Entreprises, "Noentreprise", "Noentreprise");
            return View();
        }

        // POST: Propositionsstage/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Noproposition,Noentreprise,Noconvention,ConNoconvention,Sujetpropose,Dateproposition,Duree,Remuneration")] Propositionsstage propositionsstage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propositionsstage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConNoconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention", propositionsstage.ConNoconvention);
            ViewData["Noconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention", propositionsstage.Noconvention);
            ViewData["Noentreprise"] = new SelectList(_context.Entreprises, "Noentreprise", "Noentreprise", propositionsstage.Noentreprise);
            return View(propositionsstage);
        }

        // GET: Propositionsstage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Propositionsstages == null)
            {
                return NotFound();
            }

            var propositionsstage = await _context.Propositionsstages.FindAsync(id);
            if (propositionsstage == null)
            {
                return NotFound();
            }
            ViewData["ConNoconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention", propositionsstage.ConNoconvention);
            ViewData["Noconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention", propositionsstage.Noconvention);
            ViewData["Noentreprise"] = new SelectList(_context.Entreprises, "Noentreprise", "Noentreprise", propositionsstage.Noentreprise);
            return View(propositionsstage);
        }

        // POST: Propositionsstage/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Noproposition,Noentreprise,Noconvention,ConNoconvention,Sujetpropose,Dateproposition,Duree,Remuneration")] Propositionsstage propositionsstage)
        {
            if (id != propositionsstage.Noproposition)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propositionsstage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropositionsstageExists(propositionsstage.Noproposition))
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
            ViewData["ConNoconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention", propositionsstage.ConNoconvention);
            ViewData["Noconvention"] = new SelectList(_context.Conventions, "Noconvention", "Noconvention", propositionsstage.Noconvention);
            ViewData["Noentreprise"] = new SelectList(_context.Entreprises, "Noentreprise", "Noentreprise", propositionsstage.Noentreprise);
            return View(propositionsstage);
        }

        // GET: Propositionsstage/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Propositionsstages == null)
            {
                return NotFound();
            }

            var propositionsstage = await _context.Propositionsstages
                .Include(p => p.ConNoconventionNavigation)
                .Include(p => p.NoconventionNavigation)
                .Include(p => p.NoentrepriseNavigation)
                .FirstOrDefaultAsync(m => m.Noproposition == id);
            if (propositionsstage == null)
            {
                return NotFound();
            }

            return View(propositionsstage);
        }

        // POST: Propositionsstage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Propositionsstages == null)
            {
                return Problem("Entity set 'stageContext.Propositionsstages'  is null.");
            }
            var propositionsstage = await _context.Propositionsstages.FindAsync(id);
            if (propositionsstage != null)
            {
                _context.Propositionsstages.Remove(propositionsstage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropositionsstageExists(int id)
        {
          return _context.Propositionsstages.Any(e => e.Noproposition == id);
        }
    }
}
