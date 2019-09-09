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
    public class ToThinkAboutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToThinkAboutsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ToThinkAbouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToThinkAbout.ToListAsync());
        }

        // GET: ToThinkAbouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toThinkAbout = await _context.ToThinkAbout
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toThinkAbout == null)
            {
                return NotFound();
            }

            return View(toThinkAbout);
        }

        // GET: ToThinkAbouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToThinkAbouts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ToThinkKey,WhatText,StatusId")] ToThinkAbout toThinkAbout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(toThinkAbout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(toThinkAbout);
        }

        // GET: ToThinkAbouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toThinkAbout = await _context.ToThinkAbout.FindAsync(id);
            if (toThinkAbout == null)
            {
                return NotFound();
            }
            return View(toThinkAbout);
        }

        // POST: ToThinkAbouts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ToThinkKey,WhatText,StatusId")] ToThinkAbout toThinkAbout)
        {
            if (id != toThinkAbout.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toThinkAbout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToThinkAboutExists(toThinkAbout.Id))
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
            return View(toThinkAbout);
        }

        // GET: ToThinkAbouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toThinkAbout = await _context.ToThinkAbout
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toThinkAbout == null)
            {
                return NotFound();
            }

            return View(toThinkAbout);
        }

        // POST: ToThinkAbouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toThinkAbout = await _context.ToThinkAbout.FindAsync(id);
            _context.ToThinkAbout.Remove(toThinkAbout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToThinkAboutExists(int id)
        {
            return _context.ToThinkAbout.Any(e => e.Id == id);
        }
    }
}
