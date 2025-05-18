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
    public class CategoryBudgetRepository : Repository<CategoryBudget>, ICategoryBudgetRepository
    {
        public CategoryBudgetRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<CategoryBudget?> GetByUserAndCategoryAsync(int userId, int categoryId, CancellationToken ct = default)
        {
            return await _context.CategoryBudgets
                .FirstOrDefaultAsync(cb => cb.UserId == userId && cb.CategoryId == categoryId, ct);
        }

        public async Task<IEnumerable<CategoryBudget>> GetByUserAsync(int userId, CancellationToken ct = default)
        {
            return await _context.CategoryBudgets
                .Where(cb => cb.UserId == userId)
                .ToListAsync(ct);
        }

        public async Task<CategoryBudget> AddCategoryBudgetAsync(CategoryBudget categoryBudget)
        {
            await _context.CategoryBudgets.AddAsync(categoryBudget);
            await _context.SaveChangesAsync();
            return categoryBudget;
        }

        public async Task<CategoryBudget> UpdateCategoryBudgetAsync(CategoryBudget categoryBudget, CancellationToken ct = default)
        {
            var existing = await _context.CategoryBudgets.FirstOrDefaultAsync(cb => cb.Id == categoryBudget.Id, ct);
            if (existing == null)
                throw new KeyNotFoundException("Category budget not found.");

            _context.Entry(existing).CurrentValues.SetValues(categoryBudget);
            await _context.SaveChangesAsync(ct);
            return existing;
        }

        public async Task<bool> DeleteCategoryBudgetAsync(int id)
        {
            var entity = await _context.CategoryBudgets.FindAsync(id);
            if (entity == null)
                return false;

            _context.CategoryBudgets.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CategoryBudget?> GetBudgetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.CategoryBudgets.FirstOrDefaultAsync(cb => cb.Id == id, ct);
        }
    }
}

