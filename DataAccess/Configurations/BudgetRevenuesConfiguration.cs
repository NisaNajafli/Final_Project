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
    public class BudgetRevenuesConfiguration : IEntityTypeConfiguration<BudgetRevenues>
    {
        public void Configure(EntityTypeBuilder<BudgetRevenues> builder)
        {
            builder.ConfigureBaseEntity();
            builder.HasOne(c => c.Company).WithMany(c => c.BudgetRevenues).HasForeignKey(c => c.CompanyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}