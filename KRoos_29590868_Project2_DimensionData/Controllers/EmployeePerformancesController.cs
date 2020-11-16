using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KRoos_29590868_Project2_DimensionData.Data;
using KRoos_29590868_Project2_DimensionData.Models;

namespace KRoos_29590868_Project2_DimensionData.Controllers
{
    public class EmployeePerformancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeePerformancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeePerformances
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeePerformance.ToListAsync());
        }

        // GET: EmployeePerformances/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePerformance = await _context.EmployeePerformance
                .FirstOrDefaultAsync(m => m.empPerformanceID == id);
            if (employeePerformance == null)
            {
                return NotFound();
            }

            return View(employeePerformance);
        }

        // GET: EmployeePerformances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeePerformances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("empPerformanceID,PerformanceRating,WorkLifeBalance,JobInvolvement")] EmployeePerformance employeePerformance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeePerformance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeePerformance);
        }

        // GET: EmployeePerformances/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePerformance = await _context.EmployeePerformance.FindAsync(id);
            if (employeePerformance == null)
            {
                return NotFound();
            }
            return View(employeePerformance);
        }

        // POST: EmployeePerformances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("empPerformanceID,PerformanceRating,WorkLifeBalance,JobInvolvement")] EmployeePerformance employeePerformance)
        {
            if (id != employeePerformance.empPerformanceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeePerformance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeePerformanceExists(employeePerformance.empPerformanceID))
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
            return View(employeePerformance);
        }

        // GET: EmployeePerformances/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePerformance = await _context.EmployeePerformance
                .FirstOrDefaultAsync(m => m.empPerformanceID == id);
            if (employeePerformance == null)
            {
                return NotFound();
            }

            return View(employeePerformance);
        }

        // POST: EmployeePerformances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employeePerformance = await _context.EmployeePerformance.FindAsync(id);
            _context.EmployeePerformance.Remove(employeePerformance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeePerformanceExists(string id)
        {
            return _context.EmployeePerformance.Any(e => e.empPerformanceID == id);
        }
    }
}
