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
    public class PersonalLyfeJoysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonalLyfeJoysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PersonalLyfeJoys
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PersonalLyfeJoys.Include(p => p.CurrentStatus);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PersonalLyfeJoys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalLyfeJoy = await _context.PersonalLyfeJoys
                .Include(p => p.CurrentStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalLyfeJoy == null)
            {
                return NotFound();
            }

            return View(personalLyfeJoy);
        }

        // GET: PersonalLyfeJoys/Create
        public IActionResult Create()
        {
            ViewData["CurrentStatusId"] = new SelectList(_context.CurrentStatuses, "Id", "StatusName");
            return View();
        }

        // POST: PersonalLyfeJoys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LifeJoyExpl,CurrentStatusId")] PersonalLyfeJoy personalLyfeJoy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalLyfeJoy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CurrentStatusId"] = new SelectList(_context.CurrentStatuses, "Id", "StatusName", personalLyfeJoy.CurrentStatusId);
            return View(personalLyfeJoy);
        }

        // GET: PersonalLyfeJoys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalLyfeJoy = await _context.PersonalLyfeJoys.FindAsync(id);
            if (personalLyfeJoy == null)
            {
                return NotFound();
            }
            ViewData["CurrentStatusId"] = new SelectList(_context.CurrentStatuses, "Id", "StatusName", personalLyfeJoy.CurrentStatusId);
            return View(personalLyfeJoy);
        }

        // POST: PersonalLyfeJoys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LifeJoyExpl,CurrentStatusId")] PersonalLyfeJoy personalLyfeJoy)
        {
            if (id != personalLyfeJoy.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalLyfeJoy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalLyfeJoyExists(personalLyfeJoy.Id))
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
            ViewData["CurrentStatusId"] = new SelectList(_context.CurrentStatuses, "Id", "StatusName", personalLyfeJoy.CurrentStatusId);
            return View(personalLyfeJoy);
        }

        // GET: PersonalLyfeJoys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalLyfeJoy = await _context.PersonalLyfeJoys
                .Include(p => p.CurrentStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personalLyfeJoy == null)
            {
                return NotFound();
            }

            return View(personalLyfeJoy);
        }

        // POST: PersonalLyfeJoys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalLyfeJoy = await _context.PersonalLyfeJoys.FindAsync(id);
            _context.PersonalLyfeJoys.Remove(personalLyfeJoy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalLyfeJoyExists(int id)
        {
            return _context.PersonalLyfeJoys.Any(e => e.Id == id);
        }
    }
}
