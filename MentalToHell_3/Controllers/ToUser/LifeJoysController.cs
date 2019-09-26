﻿using System;
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
    public class LifeJoysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LifeJoysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LifeJoys
        public async Task<IActionResult> Index(string searchString, SortStateUser sortOrder = SortStateUser.NameAsc)
        {
            var applicationDbContext = _context.LifeJoys.Include(l => l.ApplicationUsers);

            var joys = from j in _context.LifeJoys
                       select j;
            if (!String.IsNullOrEmpty(searchString))
            {
                joys = joys.Where(s => s.LifeJoyExpl.Contains(searchString));
            }

            ViewData["NameSort"] = sortOrder == SortStateUser.NameAsc ? SortStateUser.NameDesc : SortStateUser.NameAsc;
            ViewData["DateSort"] = sortOrder == SortStateUser.DateAsc ? SortStateUser.DateDesc : SortStateUser.DateAsc;

            switch(sortOrder)
            {
                case SortStateUser.NameDesc:
                    joys = joys.OrderByDescending(s => s.LifeJoyExpl);
                    break;
                case SortStateUser.DateAsc:
                    joys = joys.OrderBy(s => s.JobDate);
                    break;
                case SortStateUser.DateDesc:
                    joys = joys.OrderByDescending(s => s.JobDate);
                    break;
                default:
                    joys = joys.OrderBy(s => s.LifeJoyExpl);
                    break;
            }

            return View(await joys.ToListAsync());
        }

        // GET: LifeJoys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lifeJoy = await _context.LifeJoys
                .Include(l => l.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lifeJoy == null)
            {
                return NotFound();
            }

            return View(lifeJoy);
        }

        // GET: LifeJoys/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            return View();
        }

        // POST: LifeJoys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,LifeJoyExpl,JobDate")] LifeJoy lifeJoy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lifeJoy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", lifeJoy.ApplicationUserId);
            return View(lifeJoy);
        }

        // GET: LifeJoys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lifeJoy = await _context.LifeJoys.FindAsync(id);
            if (lifeJoy == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", lifeJoy.ApplicationUserId);
            return View(lifeJoy);
        }

        // POST: LifeJoys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,LifeJoyExpl,JobDate")] LifeJoy lifeJoy)
        {
            if (id != lifeJoy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lifeJoy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LifeJoyExists(lifeJoy.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", lifeJoy.ApplicationUserId);
            return View(lifeJoy);
        }

        // GET: LifeJoys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lifeJoy = await _context.LifeJoys
                .Include(l => l.ApplicationUsers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lifeJoy == null)
            {
                return NotFound();
            }

            return View(lifeJoy);
        }

        // POST: LifeJoys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lifeJoy = await _context.LifeJoys.FindAsync(id);
            _context.LifeJoys.Remove(lifeJoy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LifeJoyExists(int id)
        {
            return _context.LifeJoys.Any(e => e.Id == id);
        }
    }
}
