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
    public class JobInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobInformationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: JobInformations
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobInformation.ToListAsync());
        }

        // GET: JobInformations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobInformation = await _context.JobInformation
                .FirstOrDefaultAsync(m => m.JobID == id);
            if (jobInformation == null)
            {
                return NotFound();
            }

            return View(jobInformation);
        }

        // GET: JobInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobID,JobRole,Department,JobLevel,StandardHours,EmployeeCount,BusinessTravel,StackOptionLevel")] JobInformation jobInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobInformation);
        }

        // GET: JobInformations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobInformation = await _context.JobInformation.FindAsync(id);
            if (jobInformation == null)
            {
                return NotFound();
            }
            return View(jobInformation);
        }

        // POST: JobInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("JobID,JobRole,Department,JobLevel,StandardHours,EmployeeCount,BusinessTravel,StackOptionLevel")] JobInformation jobInformation)
        {
            if (id != jobInformation.JobID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobInformationExists(jobInformation.JobID))
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
            return View(jobInformation);
        }

        // GET: JobInformations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobInformation = await _context.JobInformation
                .FirstOrDefaultAsync(m => m.JobID == id);
            if (jobInformation == null)
            {
                return NotFound();
            }

            return View(jobInformation);
        }

        // POST: JobInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var jobInformation = await _context.JobInformation.FindAsync(id);
            _context.JobInformation.Remove(jobInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobInformationExists(string id)
        {
            return _context.JobInformation.Any(e => e.JobID == id);
        }
    }
}
