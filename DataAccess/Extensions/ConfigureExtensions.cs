using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Extensions
{
    public static class ConfigureExtensions
    {
        public static void ConfigureBaseEntity<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : BaseEntity
        {
            builder.Property(c=>c.IsActive).HasDefaultValue(true);
            builder.Property(c=>c.IsDeleted).HasDefaultValue(false);
        }
        public static void ConfigureBaseAuditable<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : BaseAuditable
        {
            builder.Property(c => c.CreatedDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(c => c.UpdatedDate).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
