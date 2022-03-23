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
    public class OtobusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OtobusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Otobus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Otobus.Include(o => o.Firma);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Otobus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otobus = await _context.Otobus
                .Include(o => o.Firma)
                .FirstOrDefaultAsync(m => m.OtobusID == id);
            if (otobus == null)
            {
                return NotFound();
            }

            return View(otobus);
        }

        // GET: Otobus/Create
        public IActionResult Create()
        {
            ViewData["Firma_ID"] = new SelectList(_context.Firma, "FirmaID", "FirmaID");
            return View();
        }

        // POST: Otobus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OtobusID,Plaka,rota,OtobusKapasite,Firma_ID")] Otobus otobus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otobus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Firma_ID"] = new SelectList(_context.Firma, "FirmaID", "FirmaID", otobus.Firma_ID);
            return View(otobus);
        }

        // GET: Otobus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otobus = await _context.Otobus.FindAsync(id);
            if (otobus == null)
            {
                return NotFound();
            }
            ViewData["Firma_ID"] = new SelectList(_context.Firma, "FirmaID", "FirmaID", otobus.Firma_ID);
            return View(otobus);
        }

        // POST: Otobus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OtobusID,Plaka,rota,OtobusKapasite,Firma_ID")] Otobus otobus)
        {
            if (id != otobus.OtobusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otobus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtobusExists(otobus.OtobusID))
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
            ViewData["Firma_ID"] = new SelectList(_context.Firma, "FirmaID", "FirmaID", otobus.Firma_ID);
            return View(otobus);
        }

        // GET: Otobus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var otobus = await _context.Otobus
                .Include(o => o.Firma)
                .FirstOrDefaultAsync(m => m.OtobusID == id);
            if (otobus == null)
            {
                return NotFound();
            }

            return View(otobus);
        }

        // POST: Otobus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var otobus = await _context.Otobus.FindAsync(id);
            _context.Otobus.Remove(otobus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtobusExists(int id)
        {
            return _context.Otobus.Any(e => e.OtobusID == id);
        }
    }
}
