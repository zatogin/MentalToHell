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
    public class WhatToTastesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WhatToTastesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WhatToTastes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WhatToTaste.ToListAsync());
        }

        // GET: WhatToTastes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whatToTaste = await _context.WhatToTaste
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whatToTaste == null)
            {
                return NotFound();
            }

            return View(whatToTaste);
        }

        // GET: WhatToTastes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WhatToTastes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ToEat,WhereToEat,StatusId")] WhatToTaste whatToTaste)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whatToTaste);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(whatToTaste);
        }

        // GET: WhatToTastes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whatToTaste = await _context.WhatToTaste.FindAsync(id);
            if (whatToTaste == null)
            {
                return NotFound();
            }
            return View(whatToTaste);
        }

        // POST: WhatToTastes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ToEat,WhereToEat,StatusId")] WhatToTaste whatToTaste)
        {
            if (id != whatToTaste.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whatToTaste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhatToTasteExists(whatToTaste.Id))
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
            return View(whatToTaste);
        }

        // GET: WhatToTastes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whatToTaste = await _context.WhatToTaste
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whatToTaste == null)
            {
                return NotFound();
            }

            return View(whatToTaste);
        }

        // POST: WhatToTastes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whatToTaste = await _context.WhatToTaste.FindAsync(id);
            _context.WhatToTaste.Remove(whatToTaste);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhatToTasteExists(int id)
        {
            return _context.WhatToTaste.Any(e => e.Id == id);
        }
    }
}
