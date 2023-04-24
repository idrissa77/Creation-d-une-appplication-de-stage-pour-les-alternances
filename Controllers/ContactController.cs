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
    public class ContactController : Controller
    {
        private readonly stageContext _context;

        public ContactController(stageContext context)
        {
            _context = context;
        }

        // GET: Contact
        public async Task<IActionResult> Index()
        {
            var stageContext = _context.Contacts.Include(c => c.DatecontactNavigation).Include(c => c.IdfetudiantNavigation).Include(c => c.NopropositionNavigation);
            return View(await stageContext.ToListAsync());
        }

        // GET: Contact/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.DatecontactNavigation)
                .Include(c => c.IdfetudiantNavigation)
                .Include(c => c.NopropositionNavigation)
                .FirstOrDefaultAsync(m => m.Noproposition == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contact/Create
        public IActionResult Create()
        {
            ViewData["Datecontact"] = new SelectList(_context.Dates, "Datecontact", "Datecontact");
            ViewData["Idfetudiant"] = new SelectList(_context.Etudiants, "Idfetudiant", "Idfetudiant");
            ViewData["Noproposition"] = new SelectList(_context.Propositionsstages, "Noproposition", "Noproposition");
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Noproposition,Idfetudiant,Datecontact")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Datecontact"] = new SelectList(_context.Dates, "Datecontact", "Datecontact", contact.Datecontact);
            ViewData["Idfetudiant"] = new SelectList(_context.Etudiants, "Idfetudiant", "Idfetudiant", contact.Idfetudiant);
            ViewData["Noproposition"] = new SelectList(_context.Propositionsstages, "Noproposition", "Noproposition", contact.Noproposition);
            return View(contact);
        }

        // GET: Contact/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            ViewData["Datecontact"] = new SelectList(_context.Dates, "Datecontact", "Datecontact", contact.Datecontact);
            ViewData["Idfetudiant"] = new SelectList(_context.Etudiants, "Idfetudiant", "Idfetudiant", contact.Idfetudiant);
            ViewData["Noproposition"] = new SelectList(_context.Propositionsstages, "Noproposition", "Noproposition", contact.Noproposition);
            return View(contact);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Noproposition,Idfetudiant,Datecontact")] Contact contact)
        {
            if (id != contact.Noproposition)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Noproposition))
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
            ViewData["Datecontact"] = new SelectList(_context.Dates, "Datecontact", "Datecontact", contact.Datecontact);
            ViewData["Idfetudiant"] = new SelectList(_context.Etudiants, "Idfetudiant", "Idfetudiant", contact.Idfetudiant);
            ViewData["Noproposition"] = new SelectList(_context.Propositionsstages, "Noproposition", "Noproposition", contact.Noproposition);
            return View(contact);
        }

        // GET: Contact/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contacts == null)
            {
                return NotFound();
            }

            var contact = await _context.Contacts
                .Include(c => c.DatecontactNavigation)
                .Include(c => c.IdfetudiantNavigation)
                .Include(c => c.NopropositionNavigation)
                .FirstOrDefaultAsync(m => m.Noproposition == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contacts == null)
            {
                return Problem("Entity set 'stageContext.Contacts'  is null.");
            }
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
          return _context.Contacts.Any(e => e.Noproposition == id);
        }
    }
}
