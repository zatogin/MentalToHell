using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHell.Data;
using MentalToHell.Models.User;

namespace MentalToHell.Controllers
{
    public class JobSatisfactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobSatisfactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobSatisfactions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobSatisfactions.Include(j => j.CurrentStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobSatisfactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobSatisfaction = await _context.JobSatisfactions
                .Include(j => j.CurrentStatus)
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
            ViewData["CurrentStatusId"] = new SelectList(_context.CurrentStatuses, "Id", "StatusName");
            return View();
        }

        // POST: JobSatisfactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobSatisfactionText,CurrentStatusId")] JobSatisfaction jobSatisfaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobSatisfaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrentStatusId"] = new SelectList(_context.CurrentStatuses, "Id", "StatusName", jobSatisfaction.CurrentStatusId);
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
            ViewData["CurrentStatusId"] = new SelectList(_context.CurrentStatuses, "Id", "StatusName", jobSatisfaction.CurrentStatusId);
            return View(jobSatisfaction);
        }

        // POST: JobSatisfactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobSatisfactionText,CurrentStatusId")] JobSatisfaction jobSatisfaction)
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
            ViewData["CurrentStatusId"] = new SelectList(_context.CurrentStatuses, "Id", "StatusName", jobSatisfaction.CurrentStatusId);
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
                .Include(j => j.CurrentStatus)
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
