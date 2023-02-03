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
    public class ItemTypesController : Controller
    {
        private readonly AppDbContext _context;

        public ItemTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ItemTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.ItemType.ToListAsync());
        }

        // GET: ItemTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ItemType == null)
            {
                return NotFound();
            }

            var itemType = await _context.ItemType
                .FirstOrDefaultAsync(m => m.ItemTypeId == id);
            if (itemType == null)
            {
                return NotFound();
            }

            return View(itemType);
        }

        // GET: ItemTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemTypeId,ItemTypeName")] ItemType itemType)
        {
            if (ModelState.IsValid)
            {
                itemType.ItemTypeId = Guid.NewGuid();
                _context.Add(itemType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemType);
        }

        // GET: ItemTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ItemType == null)
            {
                return NotFound();
            }

            var itemType = await _context.ItemType.FindAsync(id);
            if (itemType == null)
            {
                return NotFound();
            }
            return View(itemType);
        }

        // POST: ItemTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ItemTypeId,ItemTypeName")] ItemType itemType)
        {
            if (id != itemType.ItemTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemTypeExists(itemType.ItemTypeId))
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
            return View(itemType);
        }

        // GET: ItemTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ItemType == null)
            {
                return NotFound();
            }

            var itemType = await _context.ItemType
                .FirstOrDefaultAsync(m => m.ItemTypeId == id);
            if (itemType == null)
            {
                return NotFound();
            }

            return View(itemType);
        }

        // POST: ItemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ItemType == null)
            {
                return Problem("Entity set 'AppDbContext.ItemType'  is null.");
            }
            var itemType = await _context.ItemType.FindAsync(id);
            if (itemType != null)
            {
                _context.ItemType.Remove(itemType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemTypeExists(Guid id)
        {
          return _context.ItemType.Any(e => e.ItemTypeId == id);
        }
    }
}
