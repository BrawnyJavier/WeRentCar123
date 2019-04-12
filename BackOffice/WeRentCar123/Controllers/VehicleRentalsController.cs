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
            var weRentCar123Context = _context.VehicleRentals.Include(v => v.Vehicle).Include(v=>v.Vehicle.VehicleModel).Include(v => v.VehicleRentalClient);
            return View(await weRentCar123Context.ToListAsync());
        }

        // GET: VehicleRentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRental = await _context.VehicleRentals
                .Include(v => v.Vehicle)
                .Include(v => v.VehicleRentalClient)
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
            ViewData["VehicleID"] = new SelectList(_context.Vehicles.Select(v => new
            {
                v.VehicleID,
                FullName = $"{v.VehicleModel.VehicleModelName} {v.VehicleModel.VehicleModelYear} {v.Color} ({v.VehicleID})"
            }), "VehicleID", "FullName");

            ViewData["VehicleRentalClientId"] = new SelectList(_context.VehicleRentalClients.Select(c => new
            {
                c.VehicleRentalClientId,
                FullName = $"{c.Name} {c.LastName} ({c.ID})"

            }), "VehicleRentalClientId", "FullName");
            return View();
        }

        // POST: VehicleRentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleRentalID,VehicleRentalRegistrationDate,VehicleRentalClientId,VehicleID,RentFromDate,RentToDate,DailyRentalPrice,Notes")] VehicleRental vehicleRental)
        {
            if (ModelState.IsValid)
            {
                vehicleRental.VehicleRentalRegistrationDate = DateTime.Now;
                _context.Add(vehicleRental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "VehicleID", "VehicleID", vehicleRental.VehicleID);
            ViewData["VehicleRentalClientId"] = new SelectList(_context.VehicleRentalClients, "VehicleRentalClientId", "VehicleRentalClientId", vehicleRental.VehicleRentalClientId);
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
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "VehicleID", "VehicleID", vehicleRental.VehicleID);
            ViewData["VehicleRentalClientId"] = new SelectList(_context.VehicleRentalClients, "VehicleRentalClientId", "VehicleRentalClientId", vehicleRental.VehicleRentalClientId);
            return View(vehicleRental);
        }

        // POST: VehicleRentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleRentalID,VehicleRentalRegistrationDate,VehicleRentalClientId,VehicleID,RentFromDate,RentToDate,DailyRentalPrice,Notes")] VehicleRental vehicleRental)
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
            ViewData["VehicleID"] = new SelectList(_context.Vehicles, "VehicleID", "VehicleID", vehicleRental.VehicleID);
            ViewData["VehicleRentalClientId"] = new SelectList(_context.VehicleRentalClients, "VehicleRentalClientId", "VehicleRentalClientId", vehicleRental.VehicleRentalClientId);
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
                .Include(v => v.Vehicle)
                .Include(v => v.VehicleRentalClient)
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
