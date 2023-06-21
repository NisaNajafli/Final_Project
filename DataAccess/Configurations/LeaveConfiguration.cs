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
    public class LeaveConfiguration : IEntityTypeConfiguration<Leave>
    {
        public void Configure(EntityTypeBuilder<Leave> builder)
        {
            builder.ConfigureBaseAuditable();
            builder.ConfigureBaseEntity();
            builder.HasOne(c=>c.Employee).WithMany(c=>c.Leaves).HasForeignKey(c=>c.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            
            
        }
    }
}
