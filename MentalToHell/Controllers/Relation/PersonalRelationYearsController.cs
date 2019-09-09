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
    public class PersonalRelationYearsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalRelationYearsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalRelationYears
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonalRelationYears.ToListAsync());
        }

        // GET: PersonalRelationYears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalRelationYear = await _context.PersonalRelationYears
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalRelationYear == null)
            {
                return NotFound();
            }

            return View(personalRelationYear);
        }

        // GET: PersonalRelationYears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonalRelationYears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Day,Mood,RelationLink,PersonalRelation")] PersonalRelationYear personalRelationYear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalRelationYear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalRelationYear);
        }

        // GET: PersonalRelationYears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalRelationYear = await _context.PersonalRelationYears.FindAsync(id);
            if (personalRelationYear == null)
            {
                return NotFound();
            }
            return View(personalRelationYear);
        }

        // POST: PersonalRelationYears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Day,Mood,RelationLink,PersonalRelation")] PersonalRelationYear personalRelationYear)
        {
            if (id != personalRelationYear.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalRelationYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalRelationYearExists(personalRelationYear.Id))
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
            return View(personalRelationYear);
        }

        // GET: PersonalRelationYears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalRelationYear = await _context.PersonalRelationYears
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalRelationYear == null)
            {
                return NotFound();
            }

            return View(personalRelationYear);
        }

        // POST: PersonalRelationYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalRelationYear = await _context.PersonalRelationYears.FindAsync(id);
            _context.PersonalRelationYears.Remove(personalRelationYear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalRelationYearExists(int id)
        {
            return _context.PersonalRelationYears.Any(e => e.Id == id);
        }
    }
}
