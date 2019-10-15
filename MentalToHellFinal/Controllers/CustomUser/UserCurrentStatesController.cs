using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHellFinal.Data;
using MentalToHellFinal.Models.CustomUser;

namespace MentalToHellFinal.Controllers.CustomUser
{
    public class UserCurrentStatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserCurrentStatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserCurrentStates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserCurrentStates.Include(u => u.ApplicationUsers).Include(u => u.Gender).Include(u => u.Religion).Include(u => u.Sex).Include(u => u.Temperament);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserCurrentStates/Details/5
        public async Task<IActionResult> Details()
        {
            

            return View();
        }

        // GET: UserCurrentStates/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderName");
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "ReligionType");
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "SexName");
            ViewData["TemperamentId"] = new SelectList(_context.Temperaments, "Id", "TemperamentName");
            return View();
        }

        // POST: UserCurrentStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,SexId,GenderId,TemperamentId,Credo,Character,ReligionId,Birthday")] UserCurrentState userCurrentState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userCurrentState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userCurrentState.ApplicationUserId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderName", userCurrentState.GenderId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "ReligionType", userCurrentState.ReligionId);
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "SexName", userCurrentState.SexId);
            ViewData["TemperamentId"] = new SelectList(_context.Temperaments, "Id", "TemperamentName", userCurrentState.TemperamentId);
            return View(userCurrentState);
        }

        // GET: UserCurrentStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCurrentState = await _context.UserCurrentStates.FindAsync(id);
            if (userCurrentState == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userCurrentState.ApplicationUserId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderName", userCurrentState.GenderId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "ReligionType", userCurrentState.ReligionId);
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "SexName", userCurrentState.SexId);
            ViewData["TemperamentId"] = new SelectList(_context.Temperaments, "Id", "TemperamentName", userCurrentState.TemperamentId);
            return View(userCurrentState);
        }

        // POST: UserCurrentStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,SexId,GenderId,TemperamentId,Credo,Character,ReligionId,Birthday")] UserCurrentState userCurrentState)
        {
            if (id != userCurrentState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userCurrentState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserCurrentStateExists(userCurrentState.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", userCurrentState.ApplicationUserId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderName", userCurrentState.GenderId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "ReligionType", userCurrentState.ReligionId);
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "SexName", userCurrentState.SexId);
            ViewData["TemperamentId"] = new SelectList(_context.Temperaments, "Id", "TemperamentName", userCurrentState.TemperamentId);
            return View(userCurrentState);
        }

        // GET: UserCurrentStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userCurrentState = await _context.UserCurrentStates
                .Include(u => u.ApplicationUsers)
                .Include(u => u.Gender)
                .Include(u => u.Religion)
                .Include(u => u.Sex)
                .Include(u => u.Temperament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userCurrentState == null)
            {
                return NotFound();
            }

            return View(userCurrentState);
        }

        // POST: UserCurrentStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userCurrentState = await _context.UserCurrentStates.FindAsync(id);
            _context.UserCurrentStates.Remove(userCurrentState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserCurrentStateExists(int id)
        {
            return _context.UserCurrentStates.Any(e => e.Id == id);
        }
    }
}
