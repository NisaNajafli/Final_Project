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
    public class ExpectedRevenuesConfiguration : IEntityTypeConfiguration<ExpectedRevenues>
    {
        public void Configure(EntityTypeBuilder<ExpectedRevenues> builder)
        {
            builder.ConfigureBaseEntity();
            builder.HasOne(c => c.Budget).WithMany(c => c.ExpectedRevenues).HasForeignKey(c => c.BudgetId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
