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
    public class WhatToReadsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WhatToReadsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WhatToReads
        public async Task<IActionResult> Index()
        {
            return View(await _context.WhatToRead.ToListAsync());
        }

        // GET: WhatToReads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whatToRead = await _context.WhatToRead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whatToRead == null)
            {
                return NotFound();
            }

            return View(whatToRead);
        }

        // GET: WhatToReads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WhatToReads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ToRead,StatusId")] WhatToRead whatToRead)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whatToRead);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(whatToRead);
        }

        // GET: WhatToReads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whatToRead = await _context.WhatToRead.FindAsync(id);
            if (whatToRead == null)
            {
                return NotFound();
            }
            return View(whatToRead);
        }

        // POST: WhatToReads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ToRead,StatusId")] WhatToRead whatToRead)
        {
            if (id != whatToRead.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whatToRead);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhatToReadExists(whatToRead.Id))
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
            return View(whatToRead);
        }

        // GET: WhatToReads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whatToRead = await _context.WhatToRead
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whatToRead == null)
            {
                return NotFound();
            }

            return View(whatToRead);
        }

        // POST: WhatToReads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whatToRead = await _context.WhatToRead.FindAsync(id);
            _context.WhatToRead.Remove(whatToRead);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhatToReadExists(int id)
        {
            return _context.WhatToRead.Any(e => e.Id == id);
        }
    }
}
