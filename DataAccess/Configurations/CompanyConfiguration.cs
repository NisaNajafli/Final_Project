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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ConfigureBaseEntity();
            builder.Property(c => c.Name).IsRequired();
            builder.HasMany(c => c.Employees).WithOne(c=>c.Company).HasForeignKey(c=>c.CompanyId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c => c.Clients).WithOne(c => c.Company).HasForeignKey(c => c.CompanyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
