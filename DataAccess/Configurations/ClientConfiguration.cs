﻿using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);
            builder.Property(c => c.IsActive).HasDefaultValue(true);;
            builder.HasMany(c=>c.Projects).WithOne(c=>c.Client).HasForeignKey(c=>c.ClientId).OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(c=>c.Company).WithMany(c=>c.Clients).HasForeignKey(c=>c.CompanyId).OnDelete(DeleteBehavior.NoAction);
        }
    }

}

