using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KRoos_29590868_Project2_DimensionData.Models;

namespace KRoos_29590868_Project2_DimensionData.Data
{
    public class dimensiondataContext : DbContext
    {
    

    public dimensiondataContext()
    {

    }
    public dimensiondataContext(DbContextOptions<dimensiondataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
    public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
    public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
    public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
    public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
    public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
    public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
    public virtual DbSet<CostToCompany> CostToCompany { get; set; }
    public virtual DbSet<Employee> Employee { get; set; }
    public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
    public virtual DbSet<EmployeeEducation> EmployeeEducation { get; set; }
    public virtual DbSet<EmployeeHistory> EmployeeHistory { get; set; }
    public virtual DbSet<EmployeePerformance> EmployeePerformance { get; set; }
    public virtual DbSet<Gender> Gender { get; set; }
    public virtual DbSet<JobInformation> JobInformation { get; set; }
    public virtual DbSet<MaritalStatus> MaritalStatus { get; set; }
    public virtual DbSet<Surveys> Surveys { get; set; }
}

}

