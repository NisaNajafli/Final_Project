using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(c=>c.IsDeleted).HasDefaultValue(false);
            builder.Property(c=>c.IsActive).HasDefaultValue(true);
            builder.HasMany(c => c.Tasks).WithMany(c => c.Employees);
            builder.HasMany(c=>c.Tickets).WithOne(c=>c.Employee).HasForeignKey(c=>c.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c => c.Leaves).WithOne(c=>c.Employee).HasForeignKey(c=>c.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c => c.Attedances).WithOne(c => c.Employee).HasForeignKey(c => c.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e=>e.Company).WithMany(e=>e.Employees).HasForeignKey(c=>c.CompanyId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Information).WithOne(c => c.Employee);

        }
    }
}
