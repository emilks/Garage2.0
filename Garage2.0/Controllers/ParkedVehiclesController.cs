﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Data;
using Garage2._0.Models;
using Garage2._0.Models.ViewModel;
using Garage2._0.Models.ViewModels;

namespace Garage2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly Garage2_0Context _context;

        public ParkedVehiclesController(Garage2_0Context context)
        {
            _context = context;
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index()
        {

            var model = _context.ParkedVehicle.Select(v => new IndexViewModel
            {
                ArrivalTime = v.ArrivalTime,
                Type = v.Type,
                RegNr = v.RegNr,
                Id = v.Id,
                Color = v.Color,
                Brand = v.Brand,
                Model = v.Model,
                NrOfWheels= v.NrOfWheels


            });
            return View(await model.ToListAsync());
            Problem("Entity set 'Garage2_0Context.ParkedVehicle'  is null.");
        }
        public async Task<IActionResult> Overview()
        {

            var model = _context.ParkedVehicle.Select(v => new OverviewViewModel
            {
                ArrivalTime = v.ArrivalTime,
                Type = v.Type,
                RegNr = v.RegNr,
                Id = v.Id
            });

            return View(await model.ToListAsync());
        
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,RegNr,Color,Brand,Model,NrOfWheels,ArrivalTime")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {

                parkedVehicle.ArrivalTime = DateTime.Now;//automatic time
                _context.Add(parkedVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
                
            }
            
            return View(parkedVehicle);

        }
        
 
       

        public async Task<IActionResult> Filter(string title)
        {
            var model = string.IsNullOrWhiteSpace(title) ?
                                    _context.ParkedVehicle :
                                    _context.ParkedVehicle!.Where(m => m.RegNr!.StartsWith(title));



            return View(nameof(Index), await model!.ToListAsync());

        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        //Remote validation to check if regNr is already used
        [AcceptVerbs("GET", "POST")]
        public IActionResult IsRegNrUsed(string RegNr, int Id)
        {
            var regNr = _context.ParkedVehicle.FirstOrDefault(m => m.RegNr == RegNr);
            if(regNr == null || regNr.Id == Id)
            {
                return Json(true);
            }

            return Json(false);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,RegNr,Color,Brand,Model,NrOfWheels,ArrivalTime")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkedVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.Id))
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
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParkedVehicle == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParkedVehicle == null)
            {
                return Problem("Entity set 'Garage2_0Context.ParkedVehicle'  is null.");
            }
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle != null)
            {
                _context.ParkedVehicle.Remove(parkedVehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkedVehicleExists(int id)
        {
          return (_context.ParkedVehicle?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}