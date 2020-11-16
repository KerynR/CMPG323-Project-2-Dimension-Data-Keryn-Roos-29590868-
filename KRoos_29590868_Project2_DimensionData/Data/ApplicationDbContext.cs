using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KRoos_29590868_Project2_DimensionData.Models;

namespace KRoos_29590868_Project2_DimensionData.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<KRoos_29590868_Project2_DimensionData.Models.CostToCompany> CostToCompany { get; set; }
        public DbSet<KRoos_29590868_Project2_DimensionData.Models.Employee> Employee { get; set; }
        public DbSet<KRoos_29590868_Project2_DimensionData.Models.EmployeeDetails> EmployeeDetails { get; set; }
        public DbSet<KRoos_29590868_Project2_DimensionData.Models.EmployeeEducation> EmployeeEducation { get; set; }
        public DbSet<KRoos_29590868_Project2_DimensionData.Models.EmployeeHistory> EmployeeHistory { get; set; }
        public DbSet<KRoos_29590868_Project2_DimensionData.Models.EmployeePerformance> EmployeePerformance { get; set; }
        public DbSet<KRoos_29590868_Project2_DimensionData.Models.Gender> Gender { get; set; }
        public DbSet<KRoos_29590868_Project2_DimensionData.Models.JobInformation> JobInformation { get; set; }
        public DbSet<KRoos_29590868_Project2_DimensionData.Models.MaritalStatus> MaritalStatus { get; set; }
        public DbSet<KRoos_29590868_Project2_DimensionData.Models.Surveys> Surveys { get; set; }
    }
}
