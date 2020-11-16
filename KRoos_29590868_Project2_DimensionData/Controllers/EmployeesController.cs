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
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Employee.Include(e => e.Education).Include(e => e.Job).Include(e => e.Pay).Include(e => e.Survey);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Education)
                .Include(e => e.Job)
                .Include(e => e.Pay)
                .Include(e => e.Survey)
                .FirstOrDefaultAsync(m => m.EmployeeNumer == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["educationID"] = new SelectList(_context.Set<EmployeeEducation>(), "EducationID", "EducationID");
            ViewData["JobID"] = new SelectList(_context.Set<JobInformation>(), "JobID", "JobID");
            ViewData["PayID"] = new SelectList(_context.CostToCompany, "PayID", "PayID");
            ViewData["SurveyID"] = new SelectList(_context.Set<Surveys>(), "SurveyID", "SurveyID");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeNumer,PayID,EmpID,empHistoryID,educationID,SurveyID,empPerformanceID,JobID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["educationID"] = new SelectList(_context.Set<EmployeeEducation>(), "EducationID", "EducationID", employee.educationID);
            ViewData["JobID"] = new SelectList(_context.Set<JobInformation>(), "JobID", "JobID", employee.JobID);
            ViewData["PayID"] = new SelectList(_context.CostToCompany, "PayID", "PayID", employee.PayID);
            ViewData["SurveyID"] = new SelectList(_context.Set<Surveys>(), "SurveyID", "SurveyID", employee.SurveyID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["educationID"] = new SelectList(_context.Set<EmployeeEducation>(), "EducationID", "EducationID", employee.educationID);
            ViewData["JobID"] = new SelectList(_context.Set<JobInformation>(), "JobID", "JobID", employee.JobID);
            ViewData["PayID"] = new SelectList(_context.CostToCompany, "PayID", "PayID", employee.PayID);
            ViewData["SurveyID"] = new SelectList(_context.Set<Surveys>(), "SurveyID", "SurveyID", employee.SurveyID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeNumer,PayID,EmpID,empHistoryID,educationID,SurveyID,empPerformanceID,JobID")] Employee employee)
        {
            if (id != employee.EmployeeNumer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeNumer))
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
            ViewData["educationID"] = new SelectList(_context.Set<EmployeeEducation>(), "EducationID", "EducationID", employee.educationID);
            ViewData["JobID"] = new SelectList(_context.Set<JobInformation>(), "JobID", "JobID", employee.JobID);
            ViewData["PayID"] = new SelectList(_context.CostToCompany, "PayID", "PayID", employee.PayID);
            ViewData["SurveyID"] = new SelectList(_context.Set<Surveys>(), "SurveyID", "SurveyID", employee.SurveyID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Education)
                .Include(e => e.Job)
                .Include(e => e.Pay)
                .Include(e => e.Survey)
                .FirstOrDefaultAsync(m => m.EmployeeNumer == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.EmployeeNumer == id);
        }
    }
}
