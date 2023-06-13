using DataAccess.Entities;
using DataAccess.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ConfigureBaseEntity();
            builder.ConfigureBaseAuditable();
            builder.HasMany(s=>s.Employees).WithOne(s=>s.Session).HasForeignKey(s=>s.SessionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
