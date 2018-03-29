using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rh.Models;

namespace rh.Controllers
{
    public class CollaborateursController : Controller
    {
        private readonly RhContext _context;

        public CollaborateursController(RhContext context)
        {
            _context = context;
        }

        // GET: Collaborateurs
        public async Task<IActionResult> Index()
        {
            var rhContext = _context.Collaborateur.Include(c => c.Service);
            return View(await rhContext.ToListAsync());
        }

        // GET: Collaborateurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborateur = await _context.Collaborateur
                .Include(c => c.Service)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (collaborateur == null)
            {
                return NotFound();
            }

            return View(collaborateur);
        }

        // GET: Collaborateurs/Create
        public IActionResult Create()
        {
            ViewData["ServiceId"] = new SelectList(_context.Service, "ID", "ID");
            return View();
        }

        // POST: Collaborateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nom,Prenom,Genre,Nationalite,DateNaissance,DateEmbauche,Addresse,Ville,CodePostal,NumeroFixe,NumeroPortable,Email,NoSecu,ServiceId")] Collaborateur collaborateur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collaborateur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceId"] = new SelectList(_context.Service, "ID", "ID", collaborateur.ServiceId);
            return View(collaborateur);
        }

        // GET: Collaborateurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborateur = await _context.Collaborateur.SingleOrDefaultAsync(m => m.ID == id);
            if (collaborateur == null)
            {
                return NotFound();
            }
            ViewData["ServiceId"] = new SelectList(_context.Service, "ID", "ID", collaborateur.ServiceId);
            return View(collaborateur);
        }

        // POST: Collaborateurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nom,Prenom,Genre,Nationalite,DateNaissance,DateEmbauche,Addresse,Ville,CodePostal,NumeroFixe,NumeroPortable,Email,NoSecu,ServiceId")] Collaborateur collaborateur)
        {
            if (id != collaborateur.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collaborateur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollaborateurExists(collaborateur.ID))
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
            ViewData["ServiceId"] = new SelectList(_context.Service, "ID", "ID", collaborateur.ServiceId);
            return View(collaborateur);
        }

        // GET: Collaborateurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collaborateur = await _context.Collaborateur
                .Include(c => c.Service)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (collaborateur == null)
            {
                return NotFound();
            }

            return View(collaborateur);
        }

        // POST: Collaborateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collaborateur = await _context.Collaborateur.SingleOrDefaultAsync(m => m.ID == id);
            _context.Collaborateur.Remove(collaborateur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollaborateurExists(int id)
        {
            return _context.Collaborateur.Any(e => e.ID == id);
        }
    }
}
