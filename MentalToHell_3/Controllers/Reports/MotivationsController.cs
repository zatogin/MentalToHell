using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHell_3.Data;
using MentalToHell_3.Models.Reports;

namespace MentalToHell_3.Controllers.Reports
{
    public class MotivationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MotivationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Motivations
        public async Task<IActionResult> Index(string searchString, SortStateReport sortOrder = SortStateReport.NameAsc)
        {
            var applicationDbContext = _context.Motivations.Include(m => m.ApplicationUsers);

            var mot = from jo in _context.Motivations
                      select jo;
            if (!String.IsNullOrEmpty(searchString))
            {
                mot = mot.Where(s => s.MotivationText.Contains(searchString));
            }

            ViewData["NameSort"] = sortOrder == SortStateReport.NameAsc ? SortStateReport.NameDesc : SortStateReport.NameAsc;
            ViewData["DateSort"] = sortOrder == SortStateReport.DateAsc ? SortStateReport.DateDesc : SortStateReport.DateAsc;

            switch (sortOrder)
            {
                case SortStateReport.NameDesc:
                    mot = mot.OrderByDescending(s => s.MotivationText);
                    break;
                case SortStateReport.DateAsc:
                    mot = mot.OrderBy(s => s.MotivationText);
                    break;
                case SortStateReport.DateDesc:
                    mot = mot.OrderByDescending(s => s.MotivationText);
                    break;
                default:
                    mot = mot.OrderBy(s => s.MotivationText);
                    break;
            }

            return View(await mot.ToListAsync());
        }

        // GET: Motivations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motivation = await _context.Motivations
                .Include(m => m.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motivation == null)
            {
                return NotFound();
            }

            return View(motivation);
        }

        // GET: Motivations/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: Motivations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,DateTime,MotivationText")] Motivation motivation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(motivation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", motivation.ApplicationUserId);
            return View(motivation);
        }

        // GET: Motivations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motivation = await _context.Motivations.FindAsync(id);
            if (motivation == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", motivation.ApplicationUserId);
            return View(motivation);
        }

        // POST: Motivations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,DateTime,MotivationText")] Motivation motivation)
        {
            if (id != motivation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(motivation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotivationExists(motivation.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", motivation.ApplicationUserId);
            return View(motivation);
        }

        // GET: Motivations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var motivation = await _context.Motivations
                .Include(m => m.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (motivation == null)
            {
                return NotFound();
            }

            return View(motivation);
        }

        // POST: Motivations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var motivation = await _context.Motivations.FindAsync(id);
            _context.Motivations.Remove(motivation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotivationExists(int id)
        {
            return _context.Motivations.Any(e => e.Id == id);
        }
    }
}
