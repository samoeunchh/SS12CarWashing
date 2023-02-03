using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SS12CarWashing.Models;

namespace SS12CarWashing.Controllers
{
    public class OilTypesController : Controller
    {
        private readonly AppDbContext _context;

        public OilTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: OilTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.OilType.ToListAsync());
        }

        // GET: OilTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.OilType == null)
            {
                return NotFound();
            }

            var oilType = await _context.OilType
                .FirstOrDefaultAsync(m => m.OilTypeId == id);
            if (oilType == null)
            {
                return NotFound();
            }

            return View(oilType);
        }

        // GET: OilTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OilTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OilTypeId,OilTypeName")] OilType oilType)
        {
            if (ModelState.IsValid)
            {
                oilType.OilTypeId = Guid.NewGuid();
                _context.Add(oilType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oilType);
        }

        // GET: OilTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.OilType == null)
            {
                return NotFound();
            }

            var oilType = await _context.OilType.FindAsync(id);
            if (oilType == null)
            {
                return NotFound();
            }
            return View(oilType);
        }

        // POST: OilTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OilTypeId,OilTypeName")] OilType oilType)
        {
            if (id != oilType.OilTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oilType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OilTypeExists(oilType.OilTypeId))
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
            return View(oilType);
        }

        // GET: OilTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.OilType == null)
            {
                return NotFound();
            }

            var oilType = await _context.OilType
                .FirstOrDefaultAsync(m => m.OilTypeId == id);
            if (oilType == null)
            {
                return NotFound();
            }

            return View(oilType);
        }

        // POST: OilTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.OilType == null)
            {
                return Problem("Entity set 'AppDbContext.OilType'  is null.");
            }
            var oilType = await _context.OilType.FindAsync(id);
            if (oilType != null)
            {
                _context.OilType.Remove(oilType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OilTypeExists(Guid id)
        {
          return _context.OilType.Any(e => e.OilTypeId == id);
        }
    }
}
