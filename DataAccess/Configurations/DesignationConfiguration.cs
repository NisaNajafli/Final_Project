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
    public class DesignationConfiguration : IEntityTypeConfiguration<Designation>
    {
        public void Configure(EntityTypeBuilder<Designation> builder)
        {
            builder.ConfigureBaseAuditable();
            builder.ConfigureBaseEntity();
            builder.HasMany(d=>d.Employees).WithOne(d=>d.Designation).HasForeignKey(d=>d.DesignationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
