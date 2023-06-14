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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ConfigureBaseEntity();
            builder.HasMany(c=>c.BudgetRevenues).WithOne(c => c.Category).HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(c=>c.BudgetExpenses).WithOne(c => c.Category).HasForeignKey(c=>c.CategoryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
