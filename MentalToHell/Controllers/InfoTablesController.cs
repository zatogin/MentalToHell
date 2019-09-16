using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHell.Data;
using MentalToHell.Models.WhatTo;

namespace MentalToHell.Controllers
{
    public class InfoTablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InfoTablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InfoTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.InfoTables.ToListAsync());
        }

        // GET: InfoTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoTable = await _context.InfoTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infoTable == null)
            {
                return NotFound();
            }

            return View(infoTable);
        }

        // GET: InfoTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InfoTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IfoItem,IfoName")] InfoTable infoTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infoTable);
        }

        // GET: InfoTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoTable = await _context.InfoTables.FindAsync(id);
            if (infoTable == null)
            {
                return NotFound();
            }
            return View(infoTable);
        }

        // POST: InfoTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IfoItem,IfoName")] InfoTable infoTable)
        {
            if (id != infoTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoTableExists(infoTable.Id))
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
            return View(infoTable);
        }

        // GET: InfoTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoTable = await _context.InfoTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (infoTable == null)
            {
                return NotFound();
            }

            return View(infoTable);
        }

        // POST: InfoTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoTable = await _context.InfoTables.FindAsync(id);
            _context.InfoTables.Remove(infoTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoTableExists(int id)
        {
            return _context.InfoTables.Any(e => e.Id == id);
        }
    }
}
