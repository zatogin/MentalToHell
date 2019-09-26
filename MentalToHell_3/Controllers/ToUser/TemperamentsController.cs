using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHell_3.Data;
using MentalToHell_3.Models.Users.Misc;

namespace MentalToHell_3.Controllers.ToUser
{
    public class TemperamentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TemperamentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Temperaments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Temperaments.ToListAsync());
        }

        // GET: Temperaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperament = await _context.Temperaments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temperament == null)
            {
                return NotFound();
            }

            return View(temperament);
        }

        // GET: Temperaments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Temperaments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TemperamentName")] Temperament temperament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temperament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(temperament);
        }

        // GET: Temperaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperament = await _context.Temperaments.FindAsync(id);
            if (temperament == null)
            {
                return NotFound();
            }
            return View(temperament);
        }

        // POST: Temperaments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TemperamentName")] Temperament temperament)
        {
            if (id != temperament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temperament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TemperamentExists(temperament.Id))
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
            return View(temperament);
        }

        // GET: Temperaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperament = await _context.Temperaments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (temperament == null)
            {
                return NotFound();
            }

            return View(temperament);
        }

        // POST: Temperaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temperament = await _context.Temperaments.FindAsync(id);
            _context.Temperaments.Remove(temperament);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TemperamentExists(int id)
        {
            return _context.Temperaments.Any(e => e.Id == id);
        }
    }
}
