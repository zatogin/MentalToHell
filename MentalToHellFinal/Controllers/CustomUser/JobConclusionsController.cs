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
    public class JobConclusionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobConclusionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobConclusions
        public async Task<IActionResult> Index(string searchString, SortUser sortOrder = SortUser.NameAsc)
        {
            var applicationDbContext = _context.JobConclusions.Include(j => j.ApplicationUsers);

            var job = from jo in _context.JobConclusions
                       select jo;
            if (!String.IsNullOrEmpty(searchString))
            {
                job = job.Where(s => s.JobSatisfactionText.Contains(searchString));
            }

            ViewData["NameSort"] = sortOrder == SortUser.NameAsc ? SortUser.NameDesc : SortUser.NameAsc;
            ViewData["TitleSort"] = sortOrder == SortUser.TitleAsc ? SortUser.TitleDesc : SortUser.TitleAsc;
            ViewData["DateSort"] = sortOrder == SortUser.DateAsc ? SortUser.DateDesc : SortUser.DateAsc;

            switch (sortOrder)
            {
                case SortUser.NameDesc:
                    job = job.OrderByDescending(s => s.JobSatisfactionText);
                    break;
                case SortUser.DateAsc:
                    job = job.OrderBy(s => s.JobDate);
                    break;
                case SortUser.DateDesc:
                    job = job.OrderByDescending(s => s.JobDate);
                    break;
                case SortUser.TitleAsc:
                    job = job.OrderBy(s => s.JobConclusionHead);
                    break;
                case SortUser.TitleDesc:
                    job = job.OrderByDescending(s => s.JobConclusionHead);
                    break;
                default:
                    job = job.OrderBy(s => s.JobDate);
                    break;
            }
            return View(await job.ToListAsync());
        }

        // GET: JobConclusions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobConclusion = await _context.JobConclusions
                .Include(j => j.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobConclusion == null)
            {
                return NotFound();
            }

            return View(jobConclusion);
        }

        // GET: JobConclusions/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            return View();
        }

        // POST: JobConclusions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,JobConclusionHead,JobSatisfactionText,JobDate")] JobConclusion jobConclusion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobConclusion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", jobConclusion.ApplicationUserId);
            return View(jobConclusion);
        }

        // GET: JobConclusions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobConclusion = await _context.JobConclusions.FindAsync(id);
            if (jobConclusion == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", jobConclusion.ApplicationUserId);
            return View(jobConclusion);
        }

        // POST: JobConclusions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,JobConclusionHead,JobSatisfactionText,JobDate")] JobConclusion jobConclusion)
        {
            if (id != jobConclusion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobConclusion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobConclusionExists(jobConclusion.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", jobConclusion.ApplicationUserId);
            return View(jobConclusion);
        }

        // GET: JobConclusions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobConclusion = await _context.JobConclusions
                .Include(j => j.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobConclusion == null)
            {
                return NotFound();
            }

            return View(jobConclusion);
        }

        // POST: JobConclusions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobConclusion = await _context.JobConclusions.FindAsync(id);
            _context.JobConclusions.Remove(jobConclusion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobConclusionExists(int id)
        {
            return _context.JobConclusions.Any(e => e.Id == id);
        }
    }
}
