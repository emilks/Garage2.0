using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Data;
using Garage2._0.Models;
using Garage2._0.Models.ViewModels;

namespace Garage2._0.Controllers
{
    public class MembersController : Controller
    {
        private readonly Garage2_0Context _context;

        public MembersController(Garage2_0Context context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
              return _context.Member != null ? 
                          View(await _context.Member.ToListAsync()) :
                          Problem("Entity set 'Garage2_0Context.Member'  is null.");
        }
        public async Task<IActionResult> Index1()
        {

            var model = _context.Member
                .Include(m => m.Vehicles)
                .Select(m => new MembersViewModel
                {
                    Id = m.Id,
                    MemberFullName = m.FullName,
                    MemberPerNr = m.PerNr,
                    VehiclesCount = m.Vehicles.Count()
                });

            return View(await model.ToListAsync());
        }
        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }
        public async Task<IActionResult> IndexDetails(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                   .Include(m => m.Vehicles)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        public IActionResult RegisterCar()
        {
            return View();
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PerNr")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PerNr")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Member == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Member == null)
            {
                return Problem("Entity set 'Garage2_0Context.Member'  is null.");
            }
            var member = await _context.Member.FindAsync(id);
            if (member != null)
            {
                _context.Member.Remove(member);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
          return (_context.Member?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //Remote validation to check that firstName abd LastName are different
        [AcceptVerbs("GET", "POST")]
        public IActionResult FirstLastDiff(string LastName, string FirstName)
        {
            if (LastName.Equals(FirstName))
            {
                return Json(false);
            }

            else
            {
                return Json(true);
            }
        }

        //Remote validation to check if perNr is already used
        [AcceptVerbs("GET", "POST")]
        public IActionResult IsPerNrUsed(string PerNr, int Id)
        {
            var perNr = _context.Member!.FirstOrDefault(m => m.PerNr.Equals(PerNr));
            if (perNr == null)
            {
                return Json(true);
            }

            else
            {
                return Json(false);
            }
        }

        //Remote validation to check if regNr is already used
        [AcceptVerbs("GET", "POST")]
        public IActionResult PerNrFormat(string PerNr, int Id)
        {
            //TODO
            return Json(true);
        }
    }
}
