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
    public class VehicleRentalsController : Controller
    {
        private readonly WeRentCar123Context _context;

        public VehicleRentalsController(WeRentCar123Context context)
        {
            _context = context;
        }

        // GET: VehicleRentals
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleRentals.ToListAsync());
        }

        // GET: VehicleRentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRental = await _context.VehicleRentals
                .FirstOrDefaultAsync(m => m.VehicleRentalID == id);
            if (vehicleRental == null)
            {
                return NotFound();
            }

            return View(vehicleRental);
        }

        // GET: VehicleRentals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleRentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleRentalID,VehicleRentalRegistrationDate,RentFromDate,RentToDate,DailyRentalPrice,Notes")] VehicleRental vehicleRental)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleRental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleRental);
        }

        // GET: VehicleRentals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRental = await _context.VehicleRentals.FindAsync(id);
            if (vehicleRental == null)
            {
                return NotFound();
            }
            return View(vehicleRental);
        }

        // POST: VehicleRentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleRentalID,VehicleRentalRegistrationDate,RentFromDate,RentToDate,DailyRentalPrice,Notes")] VehicleRental vehicleRental)
        {
            if (id != vehicleRental.VehicleRentalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleRental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleRentalExists(vehicleRental.VehicleRentalID))
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
            return View(vehicleRental);
        }

        // GET: VehicleRentals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRental = await _context.VehicleRentals
                .FirstOrDefaultAsync(m => m.VehicleRentalID == id);
            if (vehicleRental == null)
            {
                return NotFound();
            }

            return View(vehicleRental);
        }

        // POST: VehicleRentals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleRental = await _context.VehicleRentals.FindAsync(id);
            _context.VehicleRentals.Remove(vehicleRental);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleRentalExists(int id)
        {
            return _context.VehicleRentals.Any(e => e.VehicleRentalID == id);
        }
    }
}
