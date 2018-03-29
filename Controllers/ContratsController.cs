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
    public class ContratsController : Controller
    {
        private readonly RhContext _context;

        public ContratsController(RhContext context)
        {
            _context = context;
        }

        // GET: Contrats
        public async Task<IActionResult> Index()
        {
            var rhContext = _context.Contrat.Include(c => c.Collaborateur).Include(c => c.TypeContrat);
            return View(await rhContext.ToListAsync());
        }

        // GET: Contrats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrat
                .Include(c => c.Collaborateur)
                .Include(c => c.TypeContrat)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (contrat == null)
            {
                return NotFound();
            }

            return View(contrat);
        }

        // GET: Contrats/Create
        public IActionResult Create()
        {
            ViewData["CollaborateurId"] = new SelectList(_context.Collaborateur, "ID", "ID");
            ViewData["TypeContratId"] = new SelectList(_context.TypeContrat, "ID", "ID");
            return View();
        }

        // POST: Contrats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DateDebut,DateFin,TypeContratId,CollaborateurId")] Contrat contrat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contrat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollaborateurId"] = new SelectList(_context.Collaborateur, "ID", "ID", contrat.CollaborateurId);
            ViewData["TypeContratId"] = new SelectList(_context.TypeContrat, "ID", "ID", contrat.TypeContratId);
            return View(contrat);
        }

        // GET: Contrats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrat.SingleOrDefaultAsync(m => m.ID == id);
            if (contrat == null)
            {
                return NotFound();
            }
            ViewData["CollaborateurId"] = new SelectList(_context.Collaborateur, "ID", "ID", contrat.CollaborateurId);
            ViewData["TypeContratId"] = new SelectList(_context.TypeContrat, "ID", "ID", contrat.TypeContratId);
            return View(contrat);
        }

        // POST: Contrats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateDebut,DateFin,TypeContratId,CollaborateurId")] Contrat contrat)
        {
            if (id != contrat.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratExists(contrat.ID))
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
            ViewData["CollaborateurId"] = new SelectList(_context.Collaborateur, "ID", "ID", contrat.CollaborateurId);
            ViewData["TypeContratId"] = new SelectList(_context.TypeContrat, "ID", "ID", contrat.TypeContratId);
            return View(contrat);
        }

        // GET: Contrats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrat = await _context.Contrat
                .Include(c => c.Collaborateur)
                .Include(c => c.TypeContrat)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (contrat == null)
            {
                return NotFound();
            }

            return View(contrat);
        }

        // POST: Contrats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contrat = await _context.Contrat.SingleOrDefaultAsync(m => m.ID == id);
            _context.Contrat.Remove(contrat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratExists(int id)
        {
            return _context.Contrat.Any(e => e.ID == id);
        }
    }
}
