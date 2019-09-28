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
    public class HobbiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HobbiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hobbies
        public async Task<IActionResult> Index(string searchString, SortStateReport sortOrder = SortStateReport.NameAsc)
        {
            var applicationDbContext = _context.Hobbies.Include(h => h.ApplicationUsers);

            var hob = from jo in _context.Hobbies
                      select jo;
            if (!String.IsNullOrEmpty(searchString))
            {
                hob = hob.Where(s => s.HobbyName.Contains(searchString));
            }

            ViewData["NameSort"] = sortOrder == SortStateReport.NameAsc ? SortStateReport.NameDesc : SortStateReport.NameAsc;
            ViewData["DateSort"] = sortOrder == SortStateReport.DateAsc ? SortStateReport.DateDesc : SortStateReport.DateAsc;

            switch (sortOrder)
            {
                case SortStateReport.NameDesc:
                    hob = hob.OrderByDescending(s => s.HobbyName);
                    break;
                default:
                    hob = hob.OrderBy(s => s.HobbyName);
                    break;
            }

            return View(await hob.ToListAsync());
        }

        // GET: Hobbies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobbies
                .Include(h => h.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hobby == null)
            {
                return NotFound();
            }

            return View(hobby);
        }

        // GET: Hobbies/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: Hobbies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,HobbyName")] Hobby hobby)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hobby);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", hobby.ApplicationUserId);
            return View(hobby);
        }

        // GET: Hobbies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobbies.FindAsync(id);
            if (hobby == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", hobby.ApplicationUserId);
            return View(hobby);
        }

        // POST: Hobbies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,HobbyName")] Hobby hobby)
        {
            if (id != hobby.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hobby);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HobbyExists(hobby.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", hobby.ApplicationUserId);
            return View(hobby);
        }

        // GET: Hobbies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hobby = await _context.Hobbies
                .Include(h => h.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hobby == null)
            {
                return NotFound();
            }

            return View(hobby);
        }

        // POST: Hobbies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hobby = await _context.Hobbies.FindAsync(id);
            _context.Hobbies.Remove(hobby);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HobbyExists(int id)
        {
            return _context.Hobbies.Any(e => e.Id == id);
        }
    }
}
