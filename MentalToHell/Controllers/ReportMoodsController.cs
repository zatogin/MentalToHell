using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHell.Data;
using MentalToHell.Models.Reports;

namespace MentalToHell.Controllers
{
    public class ReportMoodsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportMoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReportMoods
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReportMoods.ToListAsync());
        }

        // GET: ReportMoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportMood = await _context.ReportMoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportMood == null)
            {
                return NotFound();
            }

            return View(reportMood);
        }

        // GET: ReportMoods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReportMoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MoodName")] ReportMood reportMood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportMood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reportMood);
        }

        // GET: ReportMoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportMood = await _context.ReportMoods.FindAsync(id);
            if (reportMood == null)
            {
                return NotFound();
            }
            return View(reportMood);
        }

        // POST: ReportMoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MoodName")] ReportMood reportMood)
        {
            if (id != reportMood.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportMood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportMoodExists(reportMood.Id))
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
            return View(reportMood);
        }

        // GET: ReportMoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportMood = await _context.ReportMoods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportMood == null)
            {
                return NotFound();
            }

            return View(reportMood);
        }

        // POST: ReportMoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportMood = await _context.ReportMoods.FindAsync(id);
            _context.ReportMoods.Remove(reportMood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportMoodExists(int id)
        {
            return _context.ReportMoods.Any(e => e.Id == id);
        }
    }
}
