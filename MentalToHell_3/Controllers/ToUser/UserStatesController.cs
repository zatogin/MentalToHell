using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHell_3.Data;
using MentalToHell_3.Models.Users;

namespace MentalToHell_3.Controllers.ToUser
{
    public class UserStatesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserStatesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserStates
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserStates.Include(u => u.ApplicationUsers).Include(u => u.Gender).Include(u => u.Religion).Include(u => u.Sex).Include(u => u.Temperament);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserStates/Details/5
        public async Task<IActionResult> Details()
        {
            return View();
        }

        // GET: UserStates/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderName");
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "ReligionType");
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "SexName");
            ViewData["TemperamentId"] = new SelectList(_context.Temperaments, "Id", "TemperamentName");
            return View();
        }

        // POST: UserStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,SexId,GenderId,TemperamentId,Credo,Character,ReligionId,Birthday")] UserState userState)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userState);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", userState.ApplicationUserId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderName", userState.GenderId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "ReligionType", userState.ReligionId);
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "SexName", userState.SexId);
            ViewData["TemperamentId"] = new SelectList(_context.Temperaments, "Id", "TemperamentName", userState.TemperamentId);
            return View(userState);
        }

        // GET: UserStates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userState = await _context.UserStates.FindAsync(id);
            if (userState == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", userState.ApplicationUserId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderName", userState.GenderId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "ReligionType", userState.ReligionId);
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "SexName", userState.SexId);
            ViewData["TemperamentId"] = new SelectList(_context.Temperaments, "Id", "TemperamentName", userState.TemperamentId);
            return View(userState);
        }

        // POST: UserStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,SexId,GenderId,TemperamentId,Credo,Character,ReligionId,Birthday")] UserState userState)
        {
            if (id != userState.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userState);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserStateExists(userState.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", userState.ApplicationUserId);
            ViewData["GenderId"] = new SelectList(_context.Genders, "Id", "GenderName", userState.GenderId);
            ViewData["ReligionId"] = new SelectList(_context.Religions, "Id", "ReligionType", userState.ReligionId);
            ViewData["SexId"] = new SelectList(_context.Sexes, "Id", "SexName", userState.SexId);
            ViewData["TemperamentId"] = new SelectList(_context.Temperaments, "Id", "TemperamentName", userState.TemperamentId);
            return View(userState);
        }

        // GET: UserStates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userState = await _context.UserStates
                .Include(u => u.ApplicationUsers)
                .Include(u => u.Gender)
                .Include(u => u.Religion)
                .Include(u => u.Sex)
                .Include(u => u.Temperament)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userState == null)
            {
                return NotFound();
            }

            return View(userState);
        }

        // POST: UserStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userState = await _context.UserStates.FindAsync(id);
            _context.UserStates.Remove(userState);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserStateExists(int id)
        {
            return _context.UserStates.Any(e => e.Id == id);
        }
    }
}
