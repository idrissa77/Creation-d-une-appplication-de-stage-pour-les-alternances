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
    public class ConventionController : Controller
    {
        private readonly stageContext _context;

        public ConventionController(stageContext context)
        {
            _context = context;
        }

        // GET: Convention
        public async Task<IActionResult> Index()
        {
            var stageContext = _context.Conventions.Include(c => c.EtuIdfetudiantNavigation).Include(c => c.IdfenseignantNavigation).Include(c => c.IdfetudiantNavigation).Include(c => c.NopropositionNavigation).Include(c => c.ProNopropositionNavigation);
            return View(await stageContext.ToListAsync());
        }

        // GET: Convention/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Conventions == null)
            {
                return NotFound();
            }

            var convention = await _context.Conventions
                .Include(c => c.EtuIdfetudiantNavigation)
                .Include(c => c.IdfenseignantNavigation)
                .Include(c => c.IdfetudiantNavigation)
                .Include(c => c.NopropositionNavigation)
                .Include(c => c.ProNopropositionNavigation)
                .FirstOrDefaultAsync(m => m.Noconvention == id);
            if (convention == null)
            {
                return NotFound();
            }

            return View(convention);
        }

        // GET: Convention/Create
        public IActionResult Create()
        {
            ViewData["EtuIdfetudiant"] = new SelectList(_context.Etudiants, "Idfetudiant", "Idfetudiant");
            ViewData["Idfenseignant"] = new SelectList(_context.Enseignants, "Idfenseignant", "Idfenseignant");
            ViewData["Idfetudiant"] = new SelectList(_context.Etudiants, "Idfetudiant", "Idfetudiant");
            ViewData["Noproposition"] = new SelectList(_context.Propositionsstages, "Noproposition", "Noproposition");
            ViewData["ProNoproposition"] = new SelectList(_context.Propositionsstages, "Noproposition", "Noproposition");
            return View();
        }

        // POST: Convention/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Noconvention,Idfenseignant,Idfetudiant,EtuIdfetudiant,Noproposition,ProNoproposition,Sujetmemoire,Datedebut,Salaire,Datesignature")] Convention convention)
        {
            if (ModelState.IsValid)
            {
                _context.Add(convention);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EtuIdfetudiant"] = new SelectList(_context.Etudiants, "Idfetudiant", "Idfetudiant", convention.EtuIdfetudiant);
            ViewData["Idfenseignant"] = new SelectList(_context.Enseignants, "Idfenseignant", "Idfenseignant", convention.Idfenseignant);
            ViewData["Idfetudiant"] = new SelectList(_context.Etudiants, "Idfetudiant", "Idfetudiant", convention.Idfetudiant);
            ViewData["Noproposition"] = new SelectList(_context.Propositionsstages, "Noproposition", "Noproposition", convention.Noproposition);
            ViewData["ProNoproposition"] = new SelectList(_context.Propositionsstages, "Noproposition", "Noproposition", convention.ProNoproposition);
            return View(convention);
        }

        // GET: Convention/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Conventions == null)
            {
                return NotFound();
            }

            var convention = await _context.Conventions.FindAsync(id);
            if (convention == null)
            {
                return NotFound();
            }
            ViewData["EtuIdfetudiant"] = new SelectList(_context.Etudiants, "Idfetudiant", "Idfetudiant", convention.EtuIdfetudiant);
            ViewData["Idfenseignant"] = new SelectList(_context.Enseignants, "Idfenseignant", "Idfenseignant", convention.Idfenseignant);
            ViewData["Idfetudiant"] = new SelectList(_context.Etudiants, "Idfetudiant", "Idfetudiant", convention.Idfetudiant);
            ViewData["Noproposition"] = new SelectList(_context.Propositionsstages, "Noproposition", "Noproposition", convention.Noproposition);
            ViewData["ProNoproposition"] = new SelectList(_context.Propositionsstages, "Noproposition", "Noproposition", convention.ProNoproposition);
            return View(convention);
        }

        // POST: Convention/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Noconvention,Idfenseignant,Idfetudiant,EtuIdfetudiant,Noproposition,ProNoproposition,Sujetmemoire,Datedebut,Salaire,Datesignature")] Convention convention)
        {
            if (id != convention.Noconvention)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(convention);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConventionExists(convention.Noconvention))
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
            ViewData["EtuIdfetudiant"] = new SelectList(_context.Etudiants, "Idfetudiant", "Idfetudiant", convention.EtuIdfetudiant);
            ViewData["Idfenseignant"] = new SelectList(_context.Enseignants, "Idfenseignant", "Idfenseignant", convention.Idfenseignant);
            ViewData["Idfetudiant"] = new SelectList(_context.Etudiants, "Idfetudiant", "Idfetudiant", convention.Idfetudiant);
            ViewData["Noproposition"] = new SelectList(_context.Propositionsstages, "Noproposition", "Noproposition", convention.Noproposition);
            ViewData["ProNoproposition"] = new SelectList(_context.Propositionsstages, "Noproposition", "Noproposition", convention.ProNoproposition);
            return View(convention);
        }

        // GET: Convention/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Conventions == null)
            {
                return NotFound();
            }

            var convention = await _context.Conventions
                .Include(c => c.EtuIdfetudiantNavigation)
                .Include(c => c.IdfenseignantNavigation)
                .Include(c => c.IdfetudiantNavigation)
                .Include(c => c.NopropositionNavigation)
                .Include(c => c.ProNopropositionNavigation)
                .FirstOrDefaultAsync(m => m.Noconvention == id);
            if (convention == null)
            {
                return NotFound();
            }

            return View(convention);
        }

        // POST: Convention/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Conventions == null)
            {
                return Problem("Entity set 'stageContext.Conventions'  is null.");
            }
            var convention = await _context.Conventions.FindAsync(id);
            if (convention != null)
            {
                _context.Conventions.Remove(convention);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConventionExists(int id)
        {
          return _context.Conventions.Any(e => e.Noconvention == id);
        }
    }
}
