using DataAccess.Entities;
using DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Entities.Task> builder)
        {
            builder.ConfigureBaseEntity();
            builder.ConfigureBaseAuditable();
            builder.HasMany(c=>c.Employees).WithMany(c=>c.Tasks);  
        }
    }
}
