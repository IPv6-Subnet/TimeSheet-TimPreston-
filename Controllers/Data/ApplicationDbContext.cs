using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductionsProductionCompany.Models.ObjectModels;

namespace ProductionsProductionCompany.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee> 
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<EmployeeAssignment> EmployeeAssignments { get; set; }
        public DbSet<PayPeriod> PayPeriods { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<TimeClock> TimeClocks { get; set; }
        public DbSet<VacationRequest> VacationRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Employee>().ToTable("Employee");

            modelBuilder.Entity<Division>().ToTable("Division");
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<EmployeeAssignment>().ToTable("EmployeeAssignment");
            modelBuilder.Entity<PayPeriod>().ToTable("PayPeriod");
            modelBuilder.Entity<Payroll>().ToTable("Payroll");
            modelBuilder.Entity<TimeClock>().ToTable("TimeClock");
            modelBuilder.Entity<VacationRequest>().ToTable("VacationRequest");
        }
    }
}
