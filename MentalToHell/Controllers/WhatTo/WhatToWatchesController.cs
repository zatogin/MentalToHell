using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHell.Data;
using MentalToHell.Models.WhatTo;

namespace MentalToHell.Controllers.WhatTo
{
    public class WhatToWatchesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WhatToWatchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WhatToWatches
        public async Task<IActionResult> Index()
        {
            return View(await _context.WhatToWatch.ToListAsync());
        }

        // GET: WhatToWatches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whatToWatch = await _context.WhatToWatch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whatToWatch == null)
            {
                return NotFound();
            }

            return View(whatToWatch);
        }

        // GET: WhatToWatches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WhatToWatches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ToBe,StatusId")] WhatToWatch whatToWatch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whatToWatch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(whatToWatch);
        }

        // GET: WhatToWatches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whatToWatch = await _context.WhatToWatch.FindAsync(id);
            if (whatToWatch == null)
            {
                return NotFound();
            }
            return View(whatToWatch);
        }

        // POST: WhatToWatches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ToBe,StatusId")] WhatToWatch whatToWatch)
        {
            if (id != whatToWatch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whatToWatch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhatToWatchExists(whatToWatch.Id))
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
            return View(whatToWatch);
        }

        // GET: WhatToWatches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whatToWatch = await _context.WhatToWatch
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whatToWatch == null)
            {
                return NotFound();
            }

            return View(whatToWatch);
        }

        // POST: WhatToWatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whatToWatch = await _context.WhatToWatch.FindAsync(id);
            _context.WhatToWatch.Remove(whatToWatch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhatToWatchExists(int id)
        {
            return _context.WhatToWatch.Any(e => e.Id == id);
        }
    }
}
