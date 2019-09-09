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
    public class WhereToBesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WhereToBesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WhereToBes
        public async Task<IActionResult> Index()
        {
            return View(await _context.WhereToBe.ToListAsync());
        }

        // GET: WhereToBes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whereToBe = await _context.WhereToBe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whereToBe == null)
            {
                return NotFound();
            }

            return View(whereToBe);
        }

        // GET: WhereToBes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WhereToBes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ToBe,StatusId")] WhereToBe whereToBe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(whereToBe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(whereToBe);
        }

        // GET: WhereToBes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whereToBe = await _context.WhereToBe.FindAsync(id);
            if (whereToBe == null)
            {
                return NotFound();
            }
            return View(whereToBe);
        }

        // POST: WhereToBes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ToBe,StatusId")] WhereToBe whereToBe)
        {
            if (id != whereToBe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(whereToBe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WhereToBeExists(whereToBe.Id))
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
            return View(whereToBe);
        }

        // GET: WhereToBes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var whereToBe = await _context.WhereToBe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (whereToBe == null)
            {
                return NotFound();
            }

            return View(whereToBe);
        }

        // POST: WhereToBes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var whereToBe = await _context.WhereToBe.FindAsync(id);
            _context.WhereToBe.Remove(whereToBe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WhereToBeExists(int id)
        {
            return _context.WhereToBe.Any(e => e.Id == id);
        }
    }
}
