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
    public class CostToCompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CostToCompaniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CostToCompanies
        public async Task<IActionResult> Index()
        {
            return View(await _context.CostToCompany.ToListAsync());
        }

        // GET: CostToCompanies/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costToCompany = await _context.CostToCompany
                .FirstOrDefaultAsync(m => m.PayID == id);
            if (costToCompany == null)
            {
                return NotFound();
            }

            return View(costToCompany);
        }

        // GET: CostToCompanies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CostToCompanies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayID,HourlyRate,MonthlyRate,MonthlyIncome,DailyRate,OverTime,PercentageSalaryHike")] CostToCompany costToCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(costToCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(costToCompany);
        }

        // GET: CostToCompanies/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costToCompany = await _context.CostToCompany.FindAsync(id);
            if (costToCompany == null)
            {
                return NotFound();
            }
            return View(costToCompany);
        }

        // POST: CostToCompanies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PayID,HourlyRate,MonthlyRate,MonthlyIncome,DailyRate,OverTime,PercentageSalaryHike")] CostToCompany costToCompany)
        {
            if (id != costToCompany.PayID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costToCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostToCompanyExists(costToCompany.PayID))
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
            return View(costToCompany);
        }

        // GET: CostToCompanies/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costToCompany = await _context.CostToCompany
                .FirstOrDefaultAsync(m => m.PayID == id);
            if (costToCompany == null)
            {
                return NotFound();
            }

            return View(costToCompany);
        }

        // POST: CostToCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var costToCompany = await _context.CostToCompany.FindAsync(id);
            _context.CostToCompany.Remove(costToCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostToCompanyExists(string id)
        {
            return _context.CostToCompany.Any(e => e.PayID == id);
        }
    }
}
