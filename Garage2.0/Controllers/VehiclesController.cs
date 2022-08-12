using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Data;
using Garage2._0.Models;
using AutoMapper;
using Garage2._0.Models.ViewModels;
using Bogus;

namespace Garage2._0.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Garage2_0Context _context;
        private readonly IMapper mapper;
        

        public VehiclesController(Garage2_0Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;

        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var viewModel = await mapper.ProjectTo<VehicleIndexViewModel>(_context.Vehicle)
                  .OrderByDescending(s => s.Id)
                  .ToListAsync();

            return View(viewModel);
        }
        
        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await mapper.ProjectTo<VehicleDetailsViewModel>(_context.Vehicle)
                                        .FirstOrDefaultAsync(s => s.Id == id);
            //var vehicle = await _context.Vehicle
            //    .Include(v => v.Member)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CreateVehicleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               // var vehicleTypeEntity = _context.VehicleType.FirstOrDefault(vehicleType => vehicleType.Id == viewModel.VehicleType.Id);
                //var memberEntity = _context.Member.FirstOrDefault(member => member.Id == viewModel.Member.Id);

                var vehicleEntity = mapper.Map<Vehicle>(viewModel);
               // vehicleEntity.VehicleTypeEntity = vehicleTypeEntity;
               // vehicleEntity.Member = memberEntity;

                _context.Add(vehicleEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }
            var vehicle = await mapper.ProjectTo<VehicleEditViewModel>(_context.Vehicle)
                                      .FirstOrDefaultAsync(s => s.Id == id);
          //  var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
          //  ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Id", vehicle.MemberId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var vehicle = await _context.Vehicle.Include(s => s.VehicleTypeEntity)
                       .FirstOrDefaultAsync(s => s.Id == id);

                    mapper.Map(viewModel, vehicle);
                    _context.Update(viewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(viewModel.Id))
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
           // ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Id", vehicle.MemberId);
            return View(viewModel);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicle
                .Include(v => v.Member)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehicle == null)
            {
                return Problem("Entity set 'Garage2_0Context.Vehicle'  is null.");
            }
            var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicle.Remove(vehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Search(string term)
        {

            return Json(
                await _context.Member
                .Where(member => member.FirstName.Contains(term) || member.PerNr.Contains(term))
                //.Select(member => new { member.Id, Label = member.Name, member.PersonNr, member.Email })
                .ToListAsync());
        }
        public IActionResult Park()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs("GET", "POST")]
        public IActionResult GetVehicle(string RegNr)
        {
            var regNr = _context.Vehicle.FirstOrDefault(m => m.RegNr == RegNr);
            if (regNr == null)
            {
                return NotFound();
            }

            else
            {
                var park = new Park();
                park.ArrivalTime = DateTime.Now;
                park.VehicleId = regNr.Id;
                //park.Vehicle = regNr;
                //park.Spaces.

                regNr.Park = park;

                _context.Add(park);
                _context.SaveChanges();

                return RedirectToAction(nameof(Details), new { id = regNr.Id }); //Vehicles/delete?id=123
            }
        }

        private bool VehicleExists(int id)
        {
          return (_context.Vehicle?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
