using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHell.Data;
using MentalToHell.Models.RelationAndAchive;

namespace MentalToHell.Controllers.Relation
{
    public class PersonalRelationDaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalRelationDaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalRelationDays
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalRelationDays.ToListAsync());
        }

        // GET: PersonalRelationDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalRelationDay = await _context.PersonalRelationDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalRelationDay == null)
            {
                return NotFound();
            }

            return View(personalRelationDay);
        }

        // GET: PersonalRelationDays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalRelationDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Day,Mood,RelationLink,PersonalRelation")] PersonalRelationDay personalRelationDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalRelationDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalRelationDay);
        }

        // GET: PersonalRelationDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalRelationDay = await _context.PersonalRelationDays.FindAsync(id);
            if (personalRelationDay == null)
            {
                return NotFound();
            }
            return View(personalRelationDay);
        }

        // POST: PersonalRelationDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Day,Mood,RelationLink,PersonalRelation")] PersonalRelationDay personalRelationDay)
        {
            if (id != personalRelationDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalRelationDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalRelationDayExists(personalRelationDay.Id))
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
            return View(personalRelationDay);
        }

        // GET: PersonalRelationDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalRelationDay = await _context.PersonalRelationDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalRelationDay == null)
            {
                return NotFound();
            }

            return View(personalRelationDay);
        }

        // POST: PersonalRelationDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalRelationDay = await _context.PersonalRelationDays.FindAsync(id);
            _context.PersonalRelationDays.Remove(personalRelationDay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalRelationDayExists(int id)
        {
            return _context.PersonalRelationDays.Any(e => e.Id == id);
        }
    }
}
