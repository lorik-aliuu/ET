using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Application.Views;

namespace ET.Application.Interfaces
{
    public interface ICategoryService
    {

        Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        Task<CategoryDTO?> GetCategoryByIdAsync(int id);
        Task<CategoryDTO> CreateCategoryAsync(CreateCategoryDTO category);
        Task<CategoryDTO> UpdateCategoryAsync(int id, UpdateCategoryDTO category);

        Task<IEnumerable<CategoryDTO>> GetCategoriesByUserIdAsync(int userId);

        Task<bool> DeleteCategoryAsync(int id);
 

    }
}
