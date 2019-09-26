using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHell_3.Data;
using MentalToHell_3.Models.Users;
using MentalToHell_3.Models.Users.Misc;

namespace MentalToHell_3.Controllers.ToUser
{
    public class JobSatisfactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobSatisfactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobSatisfactions
        public async Task<IActionResult> Index(string searchString, SortStateUser sortOrder = SortStateUser.NameAsc)
        {
            var applicationDbContext = _context.JobSatisfactions.Include(l => l.ApplicationUsers);

            var job = from jo in _context.JobSatisfactions
                       select jo;
            if (!String.IsNullOrEmpty(searchString))
            {
                job = job.Where(s => s.JobSatisfactionText.Contains(searchString));
            }

            ViewData["NameSort"] = sortOrder == SortStateUser.NameAsc ? SortStateUser.NameDesc : SortStateUser.NameAsc;
            ViewData["DateSort"] = sortOrder == SortStateUser.DateAsc ? SortStateUser.DateDesc : SortStateUser.DateAsc;

            switch (sortOrder)
            {
                case SortStateUser.NameDesc:
                    job = job.OrderByDescending(s => s.JobSatisfactionText);
                    break;
                case SortStateUser.DateAsc:
                    job = job.OrderBy(s => s.JobDate);
                    break;
                case SortStateUser.DateDesc:
                    job = job.OrderByDescending(s => s.JobDate);
                    break;
                default:
                    job = job.OrderBy(s => s.JobSatisfactionText);
                    break;
            }

            return View(await job.ToListAsync());
        }

        // GET: JobSatisfactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobSatisfaction = await _context.JobSatisfactions
                .Include(j => j.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobSatisfaction == null)
            {
                return NotFound();
            }

            return View(jobSatisfaction);
        }

        // GET: JobSatisfactions/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: JobSatisfactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,JobSatisfactionText,JobDate")] JobSatisfaction jobSatisfaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobSatisfaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", jobSatisfaction.ApplicationUserId);
            return View(jobSatisfaction);
        }

        // GET: JobSatisfactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobSatisfaction = await _context.JobSatisfactions.FindAsync(id);
            if (jobSatisfaction == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", jobSatisfaction.ApplicationUserId);
            return View(jobSatisfaction);
        }

        // POST: JobSatisfactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,JobSatisfactionText,JobDate")] JobSatisfaction jobSatisfaction)
        {
            if (id != jobSatisfaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobSatisfaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobSatisfactionExists(jobSatisfaction.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", jobSatisfaction.ApplicationUserId);
            return View(jobSatisfaction);
        }

        // GET: JobSatisfactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobSatisfaction = await _context.JobSatisfactions
                .Include(j => j.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobSatisfaction == null)
            {
                return NotFound();
            }

            return View(jobSatisfaction);
        }

        // POST: JobSatisfactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobSatisfaction = await _context.JobSatisfactions.FindAsync(id);
            _context.JobSatisfactions.Remove(jobSatisfaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobSatisfactionExists(int id)
        {
            return _context.JobSatisfactions.Any(e => e.Id == id);
        }
    }
}
