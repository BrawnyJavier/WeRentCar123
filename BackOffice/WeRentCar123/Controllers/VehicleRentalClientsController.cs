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
    public class VehicleRentalClientsController : Controller
    {
        private readonly WeRentCar123Context _context;

        public VehicleRentalClientsController(WeRentCar123Context context)
        {
            _context = context;
        }

        // GET: VehicleRentalClients
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleRentalClients.ToListAsync());
        }

        // GET: VehicleRentalClients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRentalClient = await _context.VehicleRentalClients
                .FirstOrDefaultAsync(m => m.VehicleRentalClientId == id);
            if (vehicleRentalClient == null)
            {
                return NotFound();
            }

            return View(vehicleRentalClient);
        }

        // GET: VehicleRentalClients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleRentalClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleRentalClientId,Name,PhoneNumber,LastName,Email,BirthDate,ID,Address")] VehicleRentalClient vehicleRentalClient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleRentalClient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleRentalClient);
        }

        // GET: VehicleRentalClients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRentalClient = await _context.VehicleRentalClients.FindAsync(id);
            if (vehicleRentalClient == null)
            {
                return NotFound();
            }
            return View(vehicleRentalClient);
        }

        // POST: VehicleRentalClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleRentalClientId,Name,PhoneNumber,LastName,Email,BirthDate,ID,Address")] VehicleRentalClient vehicleRentalClient)
        {
            if (id != vehicleRentalClient.VehicleRentalClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleRentalClient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleRentalClientExists(vehicleRentalClient.VehicleRentalClientId))
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
            return View(vehicleRentalClient);
        }

        // GET: VehicleRentalClients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleRentalClient = await _context.VehicleRentalClients
                .FirstOrDefaultAsync(m => m.VehicleRentalClientId == id);
            if (vehicleRentalClient == null)
            {
                return NotFound();
            }

            return View(vehicleRentalClient);
        }

        // POST: VehicleRentalClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleRentalClient = await _context.VehicleRentalClients.FindAsync(id);
            _context.VehicleRentalClients.Remove(vehicleRentalClient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleRentalClientExists(int id)
        {
            return _context.VehicleRentalClients.Any(e => e.VehicleRentalClientId == id);
        }
    }
}
