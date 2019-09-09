﻿using System;
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
    public class WhatToStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WhatToStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WhatToStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.WhatToStatus.ToListAsync());
        }

        // GET: WhatToStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whatToStatus = await _context.WhatToStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whatToStatus == null)
            {
                return NotFound();
            }

            return View(whatToStatus);
        }

        // GET: WhatToStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WhatToStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WhatStatus")] WhatToStatus whatToStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whatToStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(whatToStatus);
        }

        // GET: WhatToStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whatToStatus = await _context.WhatToStatus.FindAsync(id);
            if (whatToStatus == null)
            {
                return NotFound();
            }
            return View(whatToStatus);
        }

        // POST: WhatToStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WhatStatus")] WhatToStatus whatToStatus)
        {
            if (id != whatToStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whatToStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhatToStatusExists(whatToStatus.Id))
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
            return View(whatToStatus);
        }

        // GET: WhatToStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whatToStatus = await _context.WhatToStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whatToStatus == null)
            {
                return NotFound();
            }

            return View(whatToStatus);
        }

        // POST: WhatToStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whatToStatus = await _context.WhatToStatus.FindAsync(id);
            _context.WhatToStatus.Remove(whatToStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhatToStatusExists(int id)
        {
            return _context.WhatToStatus.Any(e => e.Id == id);
        }
    }
}