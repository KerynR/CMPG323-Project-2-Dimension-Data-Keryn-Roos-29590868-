using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Xrm.Sdk;

namespace KRoos_29590868_Project2_DimensionData.Data
{
    public class DimensionDataContext : DbContext
    {

        public DimensionDataContext()
        {
        }
        public DimensionDataContext(DbContextOptions<DimensionDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Models.AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<Models.AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<Models.AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<Models.AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<Models.AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<Models.AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Models.AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Models.CostToCompany> AspNetCostToComanies { get; set; }
        public virtual DbSet<Models.Employee> Employee { get; set; }
        public virtual DbSet<Models.EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<Models.EmployeeEducation> EmployeeEducation { get; set; }
        public virtual DbSet<Models.EmployeeHistory> EmployeeHistory { get; set; }
        public virtual DbSet<Models.EmployeePerformance> EmployeePerformance { get; set; }
        public virtual DbSet<Models.Gender> Gender { get; set; }
        public virtual DbSet<Models.JobInformation> JobInformation { get; set; }
        public virtual DbSet<Models.MaritalStatus> MaritalStatus { get; set; }
        public virtual DbSet<Models.Surveys> Surveys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning to protect potentially sensitive information in your connection string...
                optionsBuilder.UseSqlServer("Data Source=dimensiondataserver20.database.windows.net;Initial Catalog=DataDimensionDB;User ID=azureuser;Password=********;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                //base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelbuilder.Entity<AspNetRoles>(entity =>
          {
              entity.HasIndex(e => e.NormalizedName)
                  .HasName("RoleNameIndex")
                  .IsUnique()
                  .HasFilter("([NormalizedName] IS NOT NULL)");

              entity.Property(e => e.Name).HasMaxLength(256);
          });

            modelbuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelbuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(d => d.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelbuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(d => d.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelbuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelbuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelbuilder.Entity<CostToCompany>(entity =>
            {
                entity.HasKey(e => e.PayId);

                entity.Property(e => e.PayId).ValueGeneratedNever();

                entity.Property(e => e.OverTime).HasMaxLength(50);
            });

            modelbuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeNumber);

                entity.Property(e => e.EmployeeNumber).ValueGeneratedNever();

                entity.Property(e => e.DetailsId).HasColumnName("empID");

                entity.Property(e => e.EducationId).HasColumnName("EduID");

                entity.Property(e => e.HistoryId).HasColumnName("empHistoryID");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.PayId).HasColumnName("PayID");

                entity.Property(e => e.PerformanceId).HasColumnName("empPerformanceID");

                entity.Property(e => e.SurveyId).HasColumnName("SurveyID");

                entity.HasOne(d => d.Details)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DetailsId)
                    .HasConstraintName("FK_Employee_Detail_52593CB8");

                entity.HasOne(d => d.Education)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.EducationId)
                    .HasConstraintName("FK_Employee_Educat_4E88ABD4");

                entity.HasOne(d => d.History)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.HistoryId)
                    .HasConstraintName("FK_Employee_Histor_4D94879B");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_Employee_JobId_4F7CD00D");

                entity.HasOne(d => d.Pay)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PayId)
                    .HasConstraintName("FK_Employee_PayId_49C3F6B7");

                entity.HasOne(d => d.Performance)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PerformanceId)
                    .HasConstraintName("FK_Employee_Perfor_4CA06362");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("FK_Employee_Survey_4BAC3F29");

            });

            modelbuilder.Entity<EmployeeDetails>(entity =>
            {
                entity.HasKey(e => e.DetailsId);

                entity.Property(e => e.DetailsId).HasColumnName("empID").ValueGeneratedNever();

                entity.Property(e => e.Attrition).HasMaxLength(50);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.MaritalId).HasColumnName("MaritalID");

                entity.Property(e => e.Over18).HasMaxLength(50);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.EmployeeDetails)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_Employee_Gende_5165187");

                entity.HasOne(d => d.Marital)
                    .WithMany(p => p.EmployeeDetails)
                    .HasForeignKey(d => d.MaritalId)
                    .HasConstraintName("FK_Employee_Marit_5070F446");
            });

            modelbuilder.Entity<EmployeeEducation>(entity =>
            {
                entity.HasKey(e => e.EducationId);

                entity.Property(e => e.EducationId).HasColumnName("EduID").ValueGeneratedNever();

                entity.Property(e => e.EducationField).HasMaxLength(50);
            });

            modelbuilder.Entity<EmployeeHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId);

                entity.Property(e => e.HistoryId).HasColumnName("empHistoryID").ValueGeneratedNever();
            });

            modelbuilder.Entity<Performance>(entity =>
            {
                entity.HasKey(e => e.HistoryId);

                entity.Property(e => e.Performance).HasColumnName("empPerformanceID").ValueGeneratedNever();
            });

            modelbuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.HistoryId).HasColumnName("GenderID").ValueGeneratedNever();

                entity.Property(e => e.GenderField).HasColumnName("GenderID").HasMaxLength(50);
                //CHECK THIS!
            });

            modelbuilder.Entity<JobInformation>(entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.Property(e => e.JobId).HasColumnName("JobID").ValueGeneratedNever();

                entity.Property(e => e.BusinessTravel).HasMaxLength(50);

                entity.Property(e => e.Department).HasMaxLength(50);

                entity.Property(e => e.JobRole).HasMaxLength(50);
            });

            modelbuilder.Entity<MaritalStatus>(entity =>
            {
                entity.HasKey(e => e.MaritalId);

                entity.Property(e => e.MaritalId).HasColumnName("MaritalID").ValueGeneratedNever();

                entity.Property(e => e.MaritalStatus1).HasColumnName("MaritalStatus").HasMaxLength(50);
            });

            modelbuilder.Entity<Surveys>(entity =>
            {
                entity.HasKey(e => e.SurveyId);

                entity.Property(e => e.SurveyId).HasColumnName("SurveyID").ValueGeneratedNever();
            });

            OnModelCreatingPartial(ModelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
