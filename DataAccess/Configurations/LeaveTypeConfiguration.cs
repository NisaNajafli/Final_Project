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
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasMany(c=>c.Leaves).WithOne(c=>c.LeaveType).HasForeignKey(c=>c.LeaveTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.ConfigureBaseEntity();
            builder.Property(l => l.Type).IsRequired();
        }
    }
}
