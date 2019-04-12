using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeRentCar123.Context;
using WeRentCar123.Models;

namespace WeRentCar123.Controllers
{
    public class VehicleBrandsController : Controller
    {
        private readonly WeRentCar123Context _context;

        public VehicleBrandsController(WeRentCar123Context context)
        {
            _context = context;
        }

        // GET: VehicleBrands
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleBrands.ToListAsync());
        }

        // GET: VehicleBrands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleBrand = await _context.VehicleBrands
                .FirstOrDefaultAsync(m => m.VehicleBrandID == id);
            if (vehicleBrand == null)
            {
                return NotFound();
            }

            return View(vehicleBrand);
        }

        // GET: VehicleBrands/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleBrands/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleBrandID,VehicleBrandName,VehicleBrandDescription,VehicleBrandIntroductionDate")] VehicleBrand vehicleBrand)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleBrand);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleBrand);
        }

        // GET: VehicleBrands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleBrand = await _context.VehicleBrands.FindAsync(id);
            if (vehicleBrand == null)
            {
                return NotFound();
            }
            return View(vehicleBrand);
        }

        // POST: VehicleBrands/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleBrandID,VehicleBrandName,VehicleBrandDescription,VehicleBrandIntroductionDate")] VehicleBrand vehicleBrand)
        {
            if (id != vehicleBrand.VehicleBrandID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleBrand);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleBrandExists(vehicleBrand.VehicleBrandID))
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
            return View(vehicleBrand);
        }

        // GET: VehicleBrands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleBrand = await _context.VehicleBrands
                .FirstOrDefaultAsync(m => m.VehicleBrandID == id);
            if (vehicleBrand == null)
            {
                return NotFound();
            }

            return View(vehicleBrand);
        }

        // POST: VehicleBrands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleBrand = await _context.VehicleBrands.FindAsync(id);
            _context.VehicleBrands.Remove(vehicleBrand);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleBrandExists(int id)
        {
            return _context.VehicleBrands.Any(e => e.VehicleBrandID == id);
        }
    }
}
