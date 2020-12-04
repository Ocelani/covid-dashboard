using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using covid_dashboard.Data;
using covid_dashboard.Models;
using Microsoft.AspNetCore.Authorization;

namespace covid_dashboard.Controllers
{
    public class CountryStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CountryStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CountryStatus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Statuses.Include(c => c.Country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CountryStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryStatus = await _context.Statuses
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (countryStatus == null)
            {
                return NotFound();
            }

            return View(countryStatus);
        }

        [Authorize]
        // GET: CountryStatus/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Name");
            return View();
        }

        [Authorize]
        // POST: CountryStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CountryId,CasosConfirmados,Mortes,Recuperados")] CountryStatus countryStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(countryStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", countryStatus.CountryId);
            return View(countryStatus);
        }

        [Authorize]
        // GET: CountryStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryStatus = await _context.Statuses.FindAsync(id);
            if (countryStatus == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", countryStatus.CountryId);
            return View(countryStatus);
        }

        [Authorize]
        // POST: CountryStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CountryId,CasosConfirmados,Mortes,Recuperados")] CountryStatus countryStatus)
        {
            if (id != countryStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(countryStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CountryStatusExists(countryStatus.Id))
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
            ViewData["CountryId"] = new SelectList(_context.Countries, "Id", "Id", countryStatus.CountryId);
            return View(countryStatus);
        }

        [Authorize]
        // GET: CountryStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var countryStatus = await _context.Statuses
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (countryStatus == null)
            {
                return NotFound();
            }

            return View(countryStatus);
        }

        [Authorize]
        // POST: CountryStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var countryStatus = await _context.Statuses.FindAsync(id);
            _context.Statuses.Remove(countryStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CountryStatusExists(int id)
        {
            return _context.Statuses.Any(e => e.Id == id);
        }
    }
}
