using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ET.Infrastructure.EntityConfigurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.Notes).HasMaxLength(1000);

            builder.Property(e => e.IsRecurring).HasDefaultValue(false);

            builder.HasOne(e => e.User)
                   .WithMany(u => u.Expenses)
                   .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Category)
                   .WithMany(c => c.Expenses)
                   .HasForeignKey(e => e.CategoryId);
        }
    }
}
