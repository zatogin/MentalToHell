using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHell.Data;
using MentalToHell.Models.User;

namespace MentalToHell.Controllers
{
    public class UserPersonalStatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserPersonalStatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserPersonalStates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserPersonalStates.Include(u => u.Gender).Include(u => u.JobSatisfaction).Include(u => u.PersonalLyfeJoy).Include(u => u.Religion).Include(u => u.Sex).Include(u => u.Temperament);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserPersonalStates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPersonalState = await _context.UserPersonalStates
                .Include(u => u.Gender)
                .Include(u => u.JobSatisfaction)
                .Include(u => u.PersonalLyfeJoy)
                .Include(u => u.Religion)
                .Include(u => u.Sex)
                .Include(u => u.Temperament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPersonalState == null)
            {
                return NotFound();
            }

            return View(userPersonalState);
        }

        // GET: UserPersonalStates/Create
        public IActionResult Create()
        {
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderName");
            ViewData["JobSatisfactionId"] = new SelectList(_context.JobSatisfactions, "Id", "JobSatisfactionText");
            ViewData["PersonalLyfeJoyId"] = new SelectList(_context.PersonalLyfeJoys, "Id", "LifeJoyExpl");
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "ReligionType");
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "SexName");
            ViewData["TemperamentId"] = new SelectList(_context.Temperaments, "Id", "TemperamentName");
            return View();
        }

        // POST: UserPersonalStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SexId,GenderId,PersonalLyfeJoyId,JobPosition,JobPlace,JobSatisfactionId,ReligionId,Birthday,AttitudeToLife,Credo,Character,TemperamentId,ApplicationUserId")] UserPersonalState userPersonalState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userPersonalState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderName", userPersonalState.GenderId);
            ViewData["JobSatisfactionId"] = new SelectList(_context.JobSatisfactions, "Id", "JobSatisfactionText", userPersonalState.JobSatisfactionId);
            ViewData["PersonalLyfeJoyId"] = new SelectList(_context.PersonalLyfeJoys, "Id", "LifeJoyExpl", userPersonalState.PersonalLyfeJoyId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "ReligionType", userPersonalState.ReligionId);
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "SexName", userPersonalState.SexId);
            ViewData["TemperamentId"] = new SelectList(_context.Temperaments, "Id", "TemperamentName", userPersonalState.TemperamentId);
            return View(userPersonalState);
        }

        // GET: UserPersonalStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPersonalState = await _context.UserPersonalStates.FindAsync(id);
            if (userPersonalState == null)
            {
                return NotFound();
            }
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderName", userPersonalState.GenderId);
            ViewData["JobSatisfactionId"] = new SelectList(_context.JobSatisfactions, "Id", "JobSatisfactionText", userPersonalState.JobSatisfactionId);
            ViewData["PersonalLyfeJoyId"] = new SelectList(_context.PersonalLyfeJoys, "Id", "LifeJoyExpl", userPersonalState.PersonalLyfeJoyId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "ReligionType", userPersonalState.ReligionId);
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "SexName", userPersonalState.SexId);
            ViewData["TemperamentId"] = new SelectList(_context.Temperaments, "Id", "TemperamentName", userPersonalState.TemperamentId);
            return View(userPersonalState);
        }

        // POST: UserPersonalStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SexId,GenderId,PersonalLyfeJoyId,JobPosition,JobPlace,JobSatisfactionId,ReligionId,Birthday,AttitudeToLife,Credo,Character,TemperamentId,ApplicationUserId")] UserPersonalState userPersonalState)
        {
            if (id != userPersonalState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPersonalState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPersonalStateExists(userPersonalState.Id))
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
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderName", userPersonalState.GenderId);
            ViewData["JobSatisfactionId"] = new SelectList(_context.JobSatisfactions, "Id", "JobSatisfactionText", userPersonalState.JobSatisfactionId);
            ViewData["PersonalLyfeJoyId"] = new SelectList(_context.PersonalLyfeJoys, "Id", "LifeJoyExpl", userPersonalState.PersonalLyfeJoyId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "ReligionType", userPersonalState.ReligionId);
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "SexName", userPersonalState.SexId);
            ViewData["TemperamentId"] = new SelectList(_context.Temperaments, "Id", "TemperamentName", userPersonalState.TemperamentId);
            return View(userPersonalState);
        }

        // GET: UserPersonalStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPersonalState = await _context.UserPersonalStates
                .Include(u => u.Gender)
                .Include(u => u.JobSatisfaction)
                .Include(u => u.PersonalLyfeJoy)
                .Include(u => u.Religion)
                .Include(u => u.Sex)
                .Include(u => u.Temperament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userPersonalState == null)
            {
                return NotFound();
            }

            return View(userPersonalState);
        }

        // POST: UserPersonalStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userPersonalState = await _context.UserPersonalStates.FindAsync(id);
            _context.UserPersonalStates.Remove(userPersonalState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPersonalStateExists(int id)
        {
            return _context.UserPersonalStates.Any(e => e.Id == id);
        }
    }
}
