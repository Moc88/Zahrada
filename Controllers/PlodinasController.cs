using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OsevniPlan.Data;
using OsevniPlan.Models;

namespace OsevniPlan.Controllers
{
    public class PlodinasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlodinasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plodinas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Plodina.ToListAsync());
        }

        // GET: Plodinas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plodina = await _context.Plodina
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plodina == null)
            {
                return NotFound();
            }

            return View(plodina);
        }

        // GET: Plodinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plodinas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Odruda,Vyrobce,Oseto")] Plodina plodina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plodina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plodina);
        }

        // GET: Plodinas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plodina = await _context.Plodina.FindAsync(id);
            if (plodina == null)
            {
                return NotFound();
            }
            return View(plodina);
        }

        // POST: Plodinas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Odruda,Vyrobce,Oseto")] Plodina plodina)
        {
            if (id != plodina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plodina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlodinaExists(plodina.Id))
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
            return View(plodina);
        }

        // GET: Plodinas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plodina = await _context.Plodina
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plodina == null)
            {
                return NotFound();
            }

            return View(plodina);
        }

        // POST: Plodinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var plodina = await _context.Plodina.FindAsync(id);
            _context.Plodina.Remove(plodina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlodinaExists(string id)
        {
            return _context.Plodina.Any(e => e.Id == id);
        }
    }
}
