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
    public class YolcuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public YolcuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Yolcu
        public async Task<IActionResult> Index()
        {
            return View(await _context.Yolcu.ToListAsync());
        }

        // GET: Yolcu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yolcu = await _context.Yolcu
                .FirstOrDefaultAsync(m => m.YolcuID == id);
            if (yolcu == null)
            {
                return NotFound();
            }

            return View(yolcu);
        }

        // GET: Yolcu/Create
        public IActionResult Create()
        {
            ViewData["Otobus_ID"] = new SelectList(_context.Otobus, "OtobusID", "OtobusID");
            return View();
        }

        // POST: Yolcu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YolcuID,YolcuAd,YolcuTel,Otobus_ID")] Yolcu yolcu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yolcu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(yolcu);
        }

        // GET: Yolcu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yolcu = await _context.Yolcu.FindAsync(id);
            if (yolcu == null)
            {
                return NotFound();
            }
            return View(yolcu);
        }

        // POST: Yolcu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YolcuID,YolcuAd,YolcuTel,Otobus_ID")] Yolcu yolcu)
        {
            if (id != yolcu.YolcuID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yolcu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YolcuExists(yolcu.YolcuID))
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
            return View(yolcu);
        }

        // GET: Yolcu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yolcu = await _context.Yolcu
                .FirstOrDefaultAsync(m => m.YolcuID == id);
            if (yolcu == null)
            {
                return NotFound();
            }

            return View(yolcu);
        }

        // POST: Yolcu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yolcu = await _context.Yolcu.FindAsync(id);
            _context.Yolcu.Remove(yolcu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YolcuExists(int id)
        {
            return _context.Yolcu.Any(e => e.YolcuID == id);
        }
    }
}
