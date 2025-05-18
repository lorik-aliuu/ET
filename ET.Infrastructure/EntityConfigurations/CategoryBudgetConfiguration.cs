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
    public class CategoryBudgetConfiguration : IEntityTypeConfiguration<CategoryBudget>
    {
        public void Configure(EntityTypeBuilder<CategoryBudget> builder)
        {
            builder.HasKey(cb => cb.Id);

            builder.Property(cb => cb.Budget)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.HasOne(cb => cb.User)
                   .WithMany(u => u.CategoryBudgets)
                   .HasForeignKey(cb => cb.UserId);

            builder.HasOne(cb => cb.Category)
                   .WithMany(c => c.CategoryBudgets)
                   .HasForeignKey(cb => cb.CategoryId);

            
            builder.HasIndex(cb => new { cb.UserId, cb.CategoryId }).IsUnique();
        }
    }
}
