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
    public class TypeDepensesController : Controller
    {
        private readonly RhContext _context;

        public TypeDepensesController(RhContext context)
        {
            _context = context;
        }

        // GET: TypeDepenses
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeDepense.ToListAsync());
        }

        // GET: TypeDepenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeDepense = await _context.TypeDepense
                .SingleOrDefaultAsync(m => m.ID == id);
            if (typeDepense == null)
            {
                return NotFound();
            }

            return View(typeDepense);
        }

        // GET: TypeDepenses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeDepenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Label")] TypeDepense typeDepense)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeDepense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeDepense);
        }

        // GET: TypeDepenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeDepense = await _context.TypeDepense.SingleOrDefaultAsync(m => m.ID == id);
            if (typeDepense == null)
            {
                return NotFound();
            }
            return View(typeDepense);
        }

        // POST: TypeDepenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Label")] TypeDepense typeDepense)
        {
            if (id != typeDepense.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeDepense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeDepenseExists(typeDepense.ID))
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
            return View(typeDepense);
        }

        // GET: TypeDepenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeDepense = await _context.TypeDepense
                .SingleOrDefaultAsync(m => m.ID == id);
            if (typeDepense == null)
            {
                return NotFound();
            }

            return View(typeDepense);
        }

        // POST: TypeDepenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeDepense = await _context.TypeDepense.SingleOrDefaultAsync(m => m.ID == id);
            _context.TypeDepense.Remove(typeDepense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeDepenseExists(int id)
        {
            return _context.TypeDepense.Any(e => e.ID == id);
        }
    }
}
