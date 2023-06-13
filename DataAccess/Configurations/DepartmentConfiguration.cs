using DataAccess.Entities;
using DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ConfigureBaseAuditable();
            builder.ConfigureBaseEntity();
            builder.Property(c=>c.Name).IsRequired();
            builder.HasMany(d=>d.Employees).WithOne(d=>d.Department).HasForeignKey(d=>d.DepartmentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
