using DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = DataAccess.Entities.Task;

namespace DataAccess.DataContext
{
    public class ManagementDb:IdentityDbContext<User,Role,int>
    {
        public ManagementDb(DbContextOptions<ManagementDb> opt):base(opt)
        {
            
        }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetExpenses> BudgetExpenses { get; set; }
        public DbSet<BudgetRevenues> BudgetRevenues { get; set; }
        public DbSet<ExpectedRevenues> ExpectedRevenues { get; set; }
        public DbSet<ExpectedExpenses> ExpectedExpenses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAttedance> EmployeesAttedances { get;set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Team> Teams { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
