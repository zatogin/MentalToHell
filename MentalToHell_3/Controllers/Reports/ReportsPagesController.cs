using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MentalToHell_3.Data;
using MentalToHell_3.Models.Reports;

namespace MentalToHell_3.Controllers.Reports
{
    public class ReportsPagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsPagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReportsPages
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ReportsPages.Include(r => r.ApplicationUsers).Include(r => r.Hobby).Include(r => r.Motivation).Include(r => r.Report);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ReportsPages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportsPage = await _context.ReportsPages
                .Include(r => r.ApplicationUsers)
                .Include(r => r.Hobby)
                .Include(r => r.Motivation)
                .Include(r => r.Report)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportsPage == null)
            {
                return NotFound();
            }

            return View(reportsPage);
        }

        // GET: ReportsPages/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            ViewData["HobbyId"] = new SelectList(_context.Hobbies, "Id", "HobbyName");
            ViewData["MotivationId"] = new SelectList(_context.Motivations, "Id", "MotivationText");
            ViewData["ReportId"] = new SelectList(_context.Reports, "Id", "Content");
            return View();
        }

        // POST: ReportsPages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ApplicationUserId,HobbyId,MotivationId,PartyId,ReportId")] ReportsPage reportsPage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportsPage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", reportsPage.ApplicationUserId);
            ViewData["HobbyId"] = new SelectList(_context.Hobbies, "Id", "HobbyName", reportsPage.HobbyId);
            ViewData["MotivationId"] = new SelectList(_context.Motivations, "Id", "MotivationText", reportsPage.MotivationId);
            ViewData["ReportId"] = new SelectList(_context.Reports, "Id", "Content", reportsPage.ReportId);
            return View(reportsPage);
        }

        // GET: ReportsPages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportsPage = await _context.ReportsPages.FindAsync(id);
            if (reportsPage == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", reportsPage.ApplicationUserId);
            ViewData["HobbyId"] = new SelectList(_context.Hobbies, "Id", "HobbyName", reportsPage.HobbyId);
            ViewData["MotivationId"] = new SelectList(_context.Motivations, "Id", "MotivationText", reportsPage.MotivationId);
            ViewData["ReportId"] = new SelectList(_context.Reports, "Id", "Content", reportsPage.ReportId);
            return View(reportsPage);
        }

        // POST: ReportsPages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,HobbyId,MotivationId,PartyId,ReportId")] ReportsPage reportsPage)
        {
            if (id != reportsPage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportsPage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportsPageExists(reportsPage.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", reportsPage.ApplicationUserId);
            ViewData["HobbyId"] = new SelectList(_context.Hobbies, "Id", "HobbyName", reportsPage.HobbyId);
            ViewData["MotivationId"] = new SelectList(_context.Motivations, "Id", "MotivationText", reportsPage.MotivationId);
            ViewData["ReportId"] = new SelectList(_context.Reports, "Id", "Content", reportsPage.ReportId);
            return View(reportsPage);
        }

        // GET: ReportsPages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportsPage = await _context.ReportsPages
                .Include(r => r.ApplicationUsers)
                .Include(r => r.Hobby)
                .Include(r => r.Motivation)
                .Include(r => r.Report)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reportsPage == null)
            {
                return NotFound();
            }

            return View(reportsPage);
        }

        // POST: ReportsPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportsPage = await _context.ReportsPages.FindAsync(id);
            _context.ReportsPages.Remove(reportsPage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportsPageExists(int id)
        {
            return _context.ReportsPages.Any(e => e.Id == id);
        }
    }
}
