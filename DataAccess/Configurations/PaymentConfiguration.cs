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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ConfigureBaseEntity();
            builder.HasOne(c=>c.Employee).WithMany(c=>c.Payments).HasForeignKey(c=>c.EmployeeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
