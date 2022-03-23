using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class GarajController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GarajController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Garaj
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Garaj.Include(g => g.Firma);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Garaj/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garaj = await _context.Garaj
                .Include(g => g.Firma)
                .FirstOrDefaultAsync(m => m.GarajID == id);
            if (garaj == null)
            {
                return NotFound();
            }

            return View(garaj);
        }

        // GET: Garaj/Create
        public IActionResult Create()
        {
            ViewData["Firma_ID"] = new SelectList(_context.Firma, "FirmaID", "FirmaID");
            return View();
        }

        // POST: Garaj/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GarajID,GarajAdres,GarajKapasite,Firma_ID")] Garaj garaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Firma_ID"] = new SelectList(_context.Firma, "FirmaID", "FirmaID", garaj.Firma_ID);
            return View(garaj);
        }

        // GET: Garaj/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garaj = await _context.Garaj.FindAsync(id);
            if (garaj == null)
            {
                return NotFound();
            }
            ViewData["Firma_ID"] = new SelectList(_context.Firma, "FirmaID", "FirmaID", garaj.Firma_ID);
            return View(garaj);
        }

        // POST: Garaj/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GarajID,GarajAdres,GarajKapasite,Firma_ID")] Garaj garaj)
        {
            if (id != garaj.GarajID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarajExists(garaj.GarajID))
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
            ViewData["Firma_ID"] = new SelectList(_context.Firma, "FirmaID", "FirmaID", garaj.Firma_ID);
            return View(garaj);
        }

        // GET: Garaj/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garaj = await _context.Garaj
                .Include(g => g.Firma)
                .FirstOrDefaultAsync(m => m.GarajID == id);
            if (garaj == null)
            {
                return NotFound();
            }

            return View(garaj);
        }

        // POST: Garaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var garaj = await _context.Garaj.FindAsync(id);
            _context.Garaj.Remove(garaj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GarajExists(int id)
        {
            return _context.Garaj.Any(e => e.GarajID == id);
        }
    }
}
