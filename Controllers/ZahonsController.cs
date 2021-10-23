using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OsevniPlan.Data;

namespace OsevniPlan.Models
{
    public class ZahonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ZahonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Zahons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zahon.ToListAsync());
        }

        // GET: Zahons/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahon = await _context.Zahon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zahon == null)
            {
                return NotFound();
            }

            return View(zahon);
        }

        // GET: Zahons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zahons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Zahon zahon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zahon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zahon);
        }

        // GET: Zahons/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahon = await _context.Zahon.FindAsync(id);
            if (zahon == null)
            {
                return NotFound();
            }
            return View(zahon);
        }

        // POST: Zahons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id")] Zahon zahon)
        {
            if (id != zahon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zahon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZahonExists(zahon.Id))
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
            return View(zahon);
        }

        // GET: Zahons/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zahon = await _context.Zahon
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zahon == null)
            {
                return NotFound();
            }

            return View(zahon);
        }

        // POST: Zahons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var zahon = await _context.Zahon.FindAsync(id);
            _context.Zahon.Remove(zahon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZahonExists(string id)
        {
            return _context.Zahon.Any(e => e.Id == id);
        }
    }
}
