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
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ConfigureBaseEntity();
            builder.ConfigureBaseAuditable();
            builder.HasOne(c=>c.Client).WithMany(c=>c.Projects).HasForeignKey(c=>c.ClientId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
