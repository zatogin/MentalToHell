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
    public class PersonalRelationWeeksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalRelationWeeksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalRelationWeeks
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalRelationWeeks.ToListAsync());
        }

        // GET: PersonalRelationWeeks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalRelationWeek = await _context.PersonalRelationWeeks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalRelationWeek == null)
            {
                return NotFound();
            }

            return View(personalRelationWeek);
        }

        // GET: PersonalRelationWeeks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalRelationWeeks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Day,Mood,RelationLink,PersonalRelation")] PersonalRelationWeek personalRelationWeek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalRelationWeek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalRelationWeek);
        }

        // GET: PersonalRelationWeeks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalRelationWeek = await _context.PersonalRelationWeeks.FindAsync(id);
            if (personalRelationWeek == null)
            {
                return NotFound();
            }
            return View(personalRelationWeek);
        }

        // POST: PersonalRelationWeeks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Day,Mood,RelationLink,PersonalRelation")] PersonalRelationWeek personalRelationWeek)
        {
            if (id != personalRelationWeek.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalRelationWeek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalRelationWeekExists(personalRelationWeek.Id))
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
            return View(personalRelationWeek);
        }

        // GET: PersonalRelationWeeks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalRelationWeek = await _context.PersonalRelationWeeks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalRelationWeek == null)
            {
                return NotFound();
            }

            return View(personalRelationWeek);
        }

        // POST: PersonalRelationWeeks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalRelationWeek = await _context.PersonalRelationWeeks.FindAsync(id);
            _context.PersonalRelationWeeks.Remove(personalRelationWeek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalRelationWeekExists(int id)
        {
            return _context.PersonalRelationWeeks.Any(e => e.Id == id);
        }
    }
}
