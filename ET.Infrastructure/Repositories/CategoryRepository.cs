using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Domain.Entities;
using ET.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ET.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Category?> GetCategoryByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Categories.FirstOrDefaultAsync(b => b.Id == id, ct);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken ct = default)
        {
            return await _context.Categories.ToListAsync(ct);
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category> UpdateCategoryAsync(Category category, CancellationToken ct = default)
        {
            var existingCategory = await _context.Categories.FirstOrDefaultAsync(e => e.Id == category.Id, ct);
            if (existingCategory == null)
            {
                throw new InvalidOperationException($"Category with ID {category.Id} not found.");
            }

            _context.Entry(existingCategory).CurrentValues.SetValues(category);
            await _context.SaveChangesAsync(ct);
            return existingCategory;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
