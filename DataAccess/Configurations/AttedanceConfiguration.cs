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
    public class AttedanceConfiguration : IEntityTypeConfiguration<EmployeeAttedance>
    {
        public void Configure(EntityTypeBuilder<EmployeeAttedance> builder)
        {
            builder.ConfigureBaseAuditable();
            builder.ConfigureBaseEntity();
            builder.Property(c=>c.IsPunch).HasDefaultValue(false);
        }
    }
}
