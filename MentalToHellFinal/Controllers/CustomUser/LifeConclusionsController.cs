using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHellFinal.Data;
using MentalToHellFinal.Models.CustomUser;
using MentalToHellFinal.Models.CustomUser.MISC;

namespace MentalToHellFinal.Controllers.CustomUser
{
    public class LifeConclusionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LifeConclusionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LifeConclusions
        public async Task<IActionResult> Index(string searchString, SortUser sortOrder = SortUser.NameAsc)
        {
            var applicationDbContext = _context.LifeConclusions.Include(l => l.ApplicationUsers);

            var life = from jo in _context.LifeConclusions
                      select jo;
            if (!String.IsNullOrEmpty(searchString))
            {
                life = life.Where(s => s.LifeConclusionHead.Contains(searchString));
            }

            ViewData["NameSort"] = sortOrder == SortUser.NameAsc ? SortUser.NameDesc : SortUser.NameAsc;
            ViewData["TitleSort"] = sortOrder == SortUser.TitleAsc ? SortUser.TitleDesc : SortUser.TitleAsc;
            ViewData["DateSort"] = sortOrder == SortUser.DateAsc ? SortUser.DateDesc : SortUser.DateAsc;

            switch (sortOrder)
            {
                case SortUser.NameDesc:
                    life = life.OrderByDescending(s => s.LifeConExpl);
                    break;
                case SortUser.DateAsc:
                    life = life.OrderBy(s => s.LifeConDate);
                    break;
                case SortUser.DateDesc:
                    life = life.OrderByDescending(s => s.LifeConDate);
                    break;
                case SortUser.TitleAsc:
                    life = life.OrderBy(s => s.LifeConclusionHead);
                    break;
                case SortUser.TitleDesc:
                    life = life.OrderByDescending(s => s.LifeConclusionHead);
                    break;
                default:
                    life = life.OrderBy(s => s.LifeConDate);
                    break;
            }
            return View(await life.ToListAsync());
        }

        // GET: LifeConclusions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lifeConclusion = await _context.LifeConclusions
                .Include(l => l.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lifeConclusion == null)
            {
                return NotFound();
            }

            return View(lifeConclusion);
        }

        // GET: LifeConclusions/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: LifeConclusions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,LifeConclusionHead,LifeConExpl,LifeJoyExpl,LifeConDate")] LifeConclusion lifeConclusion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lifeConclusion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", lifeConclusion.ApplicationUserId);
            return View(lifeConclusion);
        }

        // GET: LifeConclusions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lifeConclusion = await _context.LifeConclusions.FindAsync(id);
            if (lifeConclusion == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", lifeConclusion.ApplicationUserId);
            return View(lifeConclusion);
        }

        // POST: LifeConclusions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,LifeConclusionHead,LifeConExpl,LifeConDate")] LifeConclusion lifeConclusion)
        {
            if (id != lifeConclusion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lifeConclusion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LifeConclusionExists(lifeConclusion.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", lifeConclusion.ApplicationUserId);
            return View(lifeConclusion);
        }

        // GET: LifeConclusions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lifeConclusion = await _context.LifeConclusions
                .Include(l => l.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lifeConclusion == null)
            {
                return NotFound();
            }

            return View(lifeConclusion);
        }

        // POST: LifeConclusions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lifeConclusion = await _context.LifeConclusions.FindAsync(id);
            _context.LifeConclusions.Remove(lifeConclusion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LifeConclusionExists(int id)
        {
            return _context.LifeConclusions.Any(e => e.Id == id);
        }
    }
}
