using ET.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name).IsRequired();


        builder.HasOne(c => c.User)
         .WithMany(u => u.Categories)
         .HasForeignKey(c => c.UserId)
         .OnDelete(DeleteBehavior.Restrict);


        builder.HasMany(c => c.Expenses)
               .WithOne(e => e.Category)
               .HasForeignKey(e => e.CategoryId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.CategoryBudgets)
               .WithOne(cb => cb.Category)
               .HasForeignKey(cb => cb.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
