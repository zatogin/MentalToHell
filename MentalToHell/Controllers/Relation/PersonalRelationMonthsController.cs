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
    public class PersonalRelationMonthsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalRelationMonthsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalRelationMonths
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalRelationMonths.ToListAsync());
        }

        // GET: PersonalRelationMonths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalRelationMonth = await _context.PersonalRelationMonths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalRelationMonth == null)
            {
                return NotFound();
            }

            return View(personalRelationMonth);
        }

        // GET: PersonalRelationMonths/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalRelationMonths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Day,Mood,RelationLink,PersonalRelation")] PersonalRelationMonth personalRelationMonth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalRelationMonth);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalRelationMonth);
        }

        // GET: PersonalRelationMonths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalRelationMonth = await _context.PersonalRelationMonths.FindAsync(id);
            if (personalRelationMonth == null)
            {
                return NotFound();
            }
            return View(personalRelationMonth);
        }

        // POST: PersonalRelationMonths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Day,Mood,RelationLink,PersonalRelation")] PersonalRelationMonth personalRelationMonth)
        {
            if (id != personalRelationMonth.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalRelationMonth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalRelationMonthExists(personalRelationMonth.Id))
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
            return View(personalRelationMonth);
        }

        // GET: PersonalRelationMonths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalRelationMonth = await _context.PersonalRelationMonths
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalRelationMonth == null)
            {
                return NotFound();
            }

            return View(personalRelationMonth);
        }

        // POST: PersonalRelationMonths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalRelationMonth = await _context.PersonalRelationMonths.FindAsync(id);
            _context.PersonalRelationMonths.Remove(personalRelationMonth);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalRelationMonthExists(int id)
        {
            return _context.PersonalRelationMonths.Any(e => e.Id == id);
        }
    }
}
