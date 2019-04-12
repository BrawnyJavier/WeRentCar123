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
    public class VehicleModelsController : Controller
    {
        private readonly WeRentCar123Context _context;

        public VehicleModelsController(WeRentCar123Context context)
        {
            _context = context;
        }

        // GET: VehicleModels
        public async Task<IActionResult> Index()
        {
            var weRentCar123Context = _context.VehicleModels.Include(v => v.VehicleBrand);
            return View(await weRentCar123Context.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetByBrandID([FromQuery]int brandID)
        {
            var list = await _context.VehicleModels.Where(m => m.VehicleBrandID == brandID).ToListAsync();
            return Ok(list);
        }

        // GET: VehicleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels
                .Include(v => v.VehicleBrand)
                .FirstOrDefaultAsync(m => m.VehicleModelID == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // GET: VehicleModels/Create
        public IActionResult Create()
        {
            ViewData["VehicleBrandID"] = new SelectList(_context.VehicleBrands, "VehicleBrandID", "VehicleBrandName");
            return View();
        }

        // POST: VehicleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleModelID,VehicleModelName,VehicleModelDescription,VehicleBrandID,VehicleModelYear,RecommendedRentalDailyPrice")] VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleBrandID"] = new SelectList(_context.VehicleBrands, "VehicleBrandID", "VehicleBrandName", vehicleModel.VehicleBrandID);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels.FindAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }
            ViewData["VehicleBrandID"] = new SelectList(_context.VehicleBrands, "VehicleBrandID", "VehicleBrandName", vehicleModel.VehicleBrandID);
            return View(vehicleModel);
        }

        // POST: VehicleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleModelID,VehicleModelName,VehicleModelDescription,VehicleBrandID,VehicleModelYear,RecommendedRentalDailyPrice")] VehicleModel vehicleModel)
        {
            if (id != vehicleModel.VehicleModelID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModelExists(vehicleModel.VehicleModelID))
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
            ViewData["VehicleBrandID"] = new SelectList(_context.VehicleBrands, "VehicleBrandID", "VehicleBrandID", vehicleModel.VehicleBrandID);
            return View(vehicleModel);
        }

        // GET: VehicleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleModel = await _context.VehicleModels
                .Include(v => v.VehicleBrand)
                .FirstOrDefaultAsync(m => m.VehicleModelID == id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return View(vehicleModel);
        }

        // POST: VehicleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleModel = await _context.VehicleModels.FindAsync(id);
            _context.VehicleModels.Remove(vehicleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModelExists(int id)
        {
            return _context.VehicleModels.Any(e => e.VehicleModelID == id);
        }
    }
}
