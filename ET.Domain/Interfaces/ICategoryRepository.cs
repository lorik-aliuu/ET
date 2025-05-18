using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Domain.Entities;

namespace ET.Domain.Interfaces
{
    public interface ICategoryRepository  : IRepository<Category>
    {
        Task<Category?> GetCategoryByIdAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken ct = default);

        Task<Category> AddCategoryAsync(Category category);

        Task<Category> UpdateCategoryAsync(Category category, CancellationToken ct = default);

        Task<bool> DeleteCategoryAsync(int id);
    }
}
