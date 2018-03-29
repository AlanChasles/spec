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
    public class TypeCongesController : Controller
    {
        private readonly RhContext _context;

        public TypeCongesController(RhContext context)
        {
            _context = context;
        }

        // GET: TypeConges
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeConge.ToListAsync());
        }

        // GET: TypeConges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeConge = await _context.TypeConge
                .SingleOrDefaultAsync(m => m.ID == id);
            if (typeConge == null)
            {
                return NotFound();
            }

            return View(typeConge);
        }

        // GET: TypeConges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeConges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Label")] TypeConge typeConge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeConge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeConge);
        }

        // GET: TypeConges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeConge = await _context.TypeConge.SingleOrDefaultAsync(m => m.ID == id);
            if (typeConge == null)
            {
                return NotFound();
            }
            return View(typeConge);
        }

        // POST: TypeConges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Label")] TypeConge typeConge)
        {
            if (id != typeConge.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeConge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeCongeExists(typeConge.ID))
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
            return View(typeConge);
        }

        // GET: TypeConges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeConge = await _context.TypeConge
                .SingleOrDefaultAsync(m => m.ID == id);
            if (typeConge == null)
            {
                return NotFound();
            }

            return View(typeConge);
        }

        // POST: TypeConges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeConge = await _context.TypeConge.SingleOrDefaultAsync(m => m.ID == id);
            _context.TypeConge.Remove(typeConge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeCongeExists(int id)
        {
            return _context.TypeConge.Any(e => e.ID == id);
        }
    }
}
