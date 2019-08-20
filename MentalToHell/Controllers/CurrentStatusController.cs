using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHell.Data;
using MentalToHell.Models.misc;

namespace MentalToHell.Controllers
{
    public class CurrentStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurrentStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CurrentStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.CurrentStatuses.ToListAsync());
        }

        // GET: CurrentStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentStatus = await _context.CurrentStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currentStatus == null)
            {
                return NotFound();
            }

            return View(currentStatus);
        }

        // GET: CurrentStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CurrentStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusName")] CurrentStatus currentStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(currentStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(currentStatus);
        }

        // GET: CurrentStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentStatus = await _context.CurrentStatuses.FindAsync(id);
            if (currentStatus == null)
            {
                return NotFound();
            }
            return View(currentStatus);
        }

        // POST: CurrentStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusName")] CurrentStatus currentStatus)
        {
            if (id != currentStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(currentStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrentStatusExists(currentStatus.Id))
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
            return View(currentStatus);
        }

        // GET: CurrentStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currentStatus = await _context.CurrentStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (currentStatus == null)
            {
                return NotFound();
            }

            return View(currentStatus);
        }

        // POST: CurrentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currentStatus = await _context.CurrentStatuses.FindAsync(id);
            _context.CurrentStatuses.Remove(currentStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurrentStatusExists(int id)
        {
            return _context.CurrentStatuses.Any(e => e.Id == id);
        }
    }
}
