using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Domain.Entities;

namespace ET.Domain.Interfaces
{
    public interface ICategoryBudgetRepository : IRepository<CategoryBudget>
    {
        Task<CategoryBudget?> GetByUserAndCategoryAsync(int userId, int categoryId, CancellationToken ct = default);
        Task<IEnumerable<CategoryBudget>> GetByUserAsync(int userId, CancellationToken ct = default);
        Task<CategoryBudget> AddCategoryBudgetAsync(CategoryBudget categoryBudget);
        Task<CategoryBudget> UpdateCategoryBudgetAsync(CategoryBudget categoryBudget, CancellationToken ct = default);

        Task<CategoryBudget?> GetBudgetByIdAsync(int id, CancellationToken ct = default);
        Task<bool> DeleteCategoryBudgetAsync(int id);

    }
}
