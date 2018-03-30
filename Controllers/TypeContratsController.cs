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
    public class TypeContratsController : Controller
    {
        private readonly RhContext _context;

        public TypeContratsController(RhContext context)
        {
            _context = context;
        }

        // GET: TypeContrats
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeContrat.ToListAsync());
        }

        // GET: TypeContrats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeContrat = await _context.TypeContrat
                .SingleOrDefaultAsync(m => m.ID == id);
            if (typeContrat == null)
            {
                return NotFound();
            }

            return View(typeContrat);
        }

        // GET: TypeContrats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeContrats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Label")] TypeContrat typeContrat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeContrat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeContrat);
        }

        // GET: TypeContrats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeContrat = await _context.TypeContrat.SingleOrDefaultAsync(m => m.ID == id);
            if (typeContrat == null)
            {
                return NotFound();
            }
            return View(typeContrat);
        }

        // POST: TypeContrats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Label")] TypeContrat typeContrat)
        {
            if (id != typeContrat.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeContrat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeContratExists(typeContrat.ID))
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
            return View(typeContrat);
        }

        // GET: TypeContrats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeContrat = await _context.TypeContrat
                .SingleOrDefaultAsync(m => m.ID == id);
            if (typeContrat == null)
            {
                return NotFound();
            }

            return View(typeContrat);
        }

        // POST: TypeContrats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeContrat = await _context.TypeContrat.SingleOrDefaultAsync(m => m.ID == id);
            _context.TypeContrat.Remove(typeContrat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeContratExists(int id)
        {
            return _context.TypeContrat.Any(e => e.ID == id);
        }
    }
}
