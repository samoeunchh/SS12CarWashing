using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SS12CarWashing.Models;

namespace SS12CarWashing.Controllers;

public class BrandsController : Controller
{
    private readonly AppDbContext _context;

    public BrandsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: Brands
    public async Task<IActionResult> Index()
    {
          return View(await _context.Brand.ToListAsync());
    }

    // GET: Brands/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null || _context.Brand == null)
        {
            return NotFound();
        }

        var brand = await _context.Brand
            .FirstOrDefaultAsync(m => m.BrandId == id);
        if (brand == null)
        {
            return NotFound();
        }

        return View(brand);
    }

    // GET: Brands/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Brands/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BrandId,BrandName")] Brand brand)
    {
        if (ModelState.IsValid)
        {
            brand.BrandId = Guid.NewGuid();
            _context.Add(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(brand);
    }

    // GET: Brands/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null || _context.Brand == null)
        {
            return NotFound();
        }

        var brand = await _context.Brand.FindAsync(id);
        if (brand == null)
        {
            return NotFound();
        }
        return View(brand);
    }

    // POST: Brands/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("BrandId,BrandName")] Brand brand)
    {
        if (id != brand.BrandId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(brand);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(brand.BrandId))
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
        return View(brand);
    }

    // GET: Brands/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null || _context.Brand == null)
        {
            return NotFound();
        }

        var brand = await _context.Brand
            .FirstOrDefaultAsync(m => m.BrandId == id);
        if (brand == null)
        {
            return NotFound();
        }

        return View(brand);
    }

    // POST: Brands/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        if (_context.Brand == null)
        {
            return Problem("Entity set 'AppDbContext.Brand'  is null.");
        }
        var brand = await _context.Brand.FindAsync(id);
        if (brand != null)
        {
            _context.Brand.Remove(brand);
        }
        
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BrandExists(Guid id)
    {
      return _context.Brand.Any(e => e.BrandId == id);
    }
}
