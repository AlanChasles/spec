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
    public class DepensesController : Controller
    {
        private readonly RhContext _context;

        public DepensesController(RhContext context)
        {
            _context = context;
        }

        // GET: Depenses
        public async Task<IActionResult> Index()
        {
            var rhContext = _context.Depense.Include(d => d.TypeDepense);
            return View(await rhContext.ToListAsync());
        }

        // GET: Depenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depense = await _context.Depense
                .Include(d => d.TypeDepense)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (depense == null)
            {
                return NotFound();
            }

            return View(depense);
        }

        // GET: Depenses/Create
        public IActionResult Create()
        {
            ViewData["TypeDepenseId"] = new SelectList(_context.TypeDepense, "ID", "ID");
            return View();
        }

        // POST: Depenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DateDepense,NomClient,VilleClient,MotifDepense,NombreKms,LocationVoiture,TaxiBus,AvionTrain,ParkingPeage,Restaurant,Hotel,Divers,TauxDevise,Commentaire,CommentaireRefus,TypeDepenseId")] Depense depense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(depense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TypeDepenseId"] = new SelectList(_context.TypeDepense, "ID", "ID", depense.TypeDepenseId);
            return View(depense);
        }

        // GET: Depenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depense = await _context.Depense.SingleOrDefaultAsync(m => m.ID == id);
            if (depense == null)
            {
                return NotFound();
            }
            ViewData["TypeDepenseId"] = new SelectList(_context.TypeDepense, "ID", "ID", depense.TypeDepenseId);
            return View(depense);
        }

        // POST: Depenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DateDepense,NomClient,VilleClient,MotifDepense,NombreKms,LocationVoiture,TaxiBus,AvionTrain,ParkingPeage,Restaurant,Hotel,Divers,TauxDevise,Commentaire,CommentaireRefus,TypeDepenseId")] Depense depense)
        {
            if (id != depense.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(depense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepenseExists(depense.ID))
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
            ViewData["TypeDepenseId"] = new SelectList(_context.TypeDepense, "ID", "ID", depense.TypeDepenseId);
            return View(depense);
        }

        // GET: Depenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depense = await _context.Depense
                .Include(d => d.TypeDepense)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (depense == null)
            {
                return NotFound();
            }

            return View(depense);
        }

        // POST: Depenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var depense = await _context.Depense.SingleOrDefaultAsync(m => m.ID == id);
            _context.Depense.Remove(depense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepenseExists(int id)
        {
            return _context.Depense.Any(e => e.ID == id);
        }
    }
}
