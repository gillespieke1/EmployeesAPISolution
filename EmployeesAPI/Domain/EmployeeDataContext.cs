using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAPI.Domain
{
    public class EmployeeDataContext :DbContext
    {
        public EmployeeDataContext(DbContextOptions<EmployeeDataContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().Property(e => e.FirstName).HasMaxLength(200);
            modelBuilder.Entity<Employee>().Property(e => e.LastName).HasMaxLength(200);
            modelBuilder.Entity<Employee>().Property(e => e.Department).HasMaxLength(20);

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "Harry", LastName = "Potter", Department = "DEV", IsActive = true },
                new Employee { Id = 2, FirstName = "Hermione", LastName = "Granger", Department = "CEO", IsActive = true },
                new Employee { Id = 3, FirstName = "Ron", LastName = "Weasley", Department = "QA", IsActive = false }
            );
        }
    }
}

