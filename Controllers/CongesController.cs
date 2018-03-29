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
    public class CongesController : Controller
    {
        private readonly RhContext _context;

        public CongesController(RhContext context)
        {
            _context = context;
        }

        // GET: Conges
        public async Task<IActionResult> Index()
        {
            var rhContext = _context.Conge.Include(c => c.Collaborateur).Include(c => c.TypeConge);
            return View(await rhContext.ToListAsync());
        }

        // GET: Conges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conge = await _context.Conge
                .Include(c => c.Collaborateur)
                .Include(c => c.TypeConge)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (conge == null)
            {
                return NotFound();
            }

            return View(conge);
        }

        // GET: Conges/Create
        public IActionResult Create()
        {
            ViewData["CollaborateurId"] = new SelectList(_context.Collaborateur, "ID", "ID");
            ViewData["TypeCongeId"] = new SelectList(_context.TypeConge, "ID", "ID");
            return View();
        }

        // POST: Conges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DateDebut,DateFin,PeriodeDebut,PeriodeFin,Commentaire,DateDemande,NomResponsable,PrenomResponsable,Decision,TypeCongeId,CollaborateurId")] Conge conge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(conge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CollaborateurId"] = new SelectList(_context.Collaborateur, "ID", "ID", conge.CollaborateurId);
            ViewData["TypeCongeId"] = new SelectList(_context.TypeConge, "ID", "ID", conge.TypeCongeId);
            return View(conge);
        }

        // GET: Conges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conge = await _context.Conge.SingleOrDefaultAsync(m => m.ID == id);
            if (conge == null)
            {
                return NotFound();
            }
            ViewData["CollaborateurId"] = new SelectList(_context.Collaborateur, "ID", "ID", conge.CollaborateurId);
            ViewData["TypeCongeId"] = new SelectList(_context.TypeConge, "ID", "ID", conge.TypeCongeId);
            return View(conge);
        }

        // POST: Conges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateDebut,DateFin,PeriodeDebut,PeriodeFin,Commentaire,DateDemande,NomResponsable,PrenomResponsable,Decision,TypeCongeId,CollaborateurId")] Conge conge)
        {
            if (id != conge.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(conge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CongeExists(conge.ID))
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
            ViewData["CollaborateurId"] = new SelectList(_context.Collaborateur, "ID", "ID", conge.CollaborateurId);
            ViewData["TypeCongeId"] = new SelectList(_context.TypeConge, "ID", "ID", conge.TypeCongeId);
            return View(conge);
        }

        // GET: Conges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var conge = await _context.Conge
                .Include(c => c.Collaborateur)
                .Include(c => c.TypeConge)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (conge == null)
            {
                return NotFound();
            }

            return View(conge);
        }

        // POST: Conges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var conge = await _context.Conge.SingleOrDefaultAsync(m => m.ID == id);
            _context.Conge.Remove(conge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CongeExists(int id)
        {
            return _context.Conge.Any(e => e.ID == id);
        }
    }
}
