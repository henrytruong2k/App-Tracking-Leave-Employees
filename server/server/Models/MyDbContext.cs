using Microsoft.EntityFrameworkCore;
using System;

namespace server.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Employee>().HasData(new Employee
            //{
            //    Id = 1,
            //    FullName = "Nguyen Van HR",
            //    Email = "hr@gmail.com",
            //    Password = "1234",
            //    Dayoff = 5,
            //    Role = "HR",
            //    ApproverId = 1,
            //    CreatedAt = DateTime.Now,
            //    UpdatedAt = DateTime.Now
            //});
            //modelBuilder.Entity<Employee>().HasData(new Employee
            //{
            //    Id = 2,
            //    FullName = "Nguyen Van Emp",
            //    Email = "emp@gmail.com",
            //    Password = "1234",
            //    Dayoff = 5,
            //    Role = "Employee",
            //    ApproverId = 1,
            //    CreatedAt = DateTime.Now,
            //    UpdatedAt = DateTime.Now
            //});
            //modelBuilder.Entity<LeaveRequest>().HasData(new LeaveRequest
            //{
            //    Id = 1,
            //    FromDate = DateTime.Now,
            //    ToDate = DateTime.Now.AddDays(8),
            //    CreatedById = 2,
            //    RequestedById = 1,
            //    Approved = true,
            //    CreatedAt = DateTime.Now,
            //    UpdatedAt = DateTime.Now
            //});
        }
    }
}
