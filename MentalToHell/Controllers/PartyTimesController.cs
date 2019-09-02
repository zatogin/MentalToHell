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
    public class PartyTimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartyTimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PartyTimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PartyTimes.ToListAsync());
        }

        // GET: PartyTimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyTime = await _context.PartyTimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partyTime == null)
            {
                return NotFound();
            }

            return View(partyTime);
        }

        // GET: PartyTimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PartyTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DateTime,Name,ApplicationUserId")] PartyTime partyTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partyTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partyTime);
        }

        // GET: PartyTimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyTime = await _context.PartyTimes.FindAsync(id);
            if (partyTime == null)
            {
                return NotFound();
            }
            return View(partyTime);
        }

        // POST: PartyTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DateTime,Name,ApplicationUserId")] PartyTime partyTime)
        {
            if (id != partyTime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partyTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartyTimeExists(partyTime.Id))
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
            return View(partyTime);
        }

        // GET: PartyTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partyTime = await _context.PartyTimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partyTime == null)
            {
                return NotFound();
            }

            return View(partyTime);
        }

        // POST: PartyTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partyTime = await _context.PartyTimes.FindAsync(id);
            _context.PartyTimes.Remove(partyTime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartyTimeExists(int id)
        {
            return _context.PartyTimes.Any(e => e.Id == id);
        }
    }
}
