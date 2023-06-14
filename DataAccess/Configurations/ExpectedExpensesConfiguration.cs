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
    public class ExpectedExpensesConfiguration : IEntityTypeConfiguration<ExpectedExpenses>
    {
        public void Configure(EntityTypeBuilder<ExpectedExpenses> builder)
        {
            builder.ConfigureBaseEntity();
            builder.HasOne(c=>c.Budget).WithMany(c=>c.ExpectedExpenses).HasForeignKey(c=>c.BudgetId).OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
