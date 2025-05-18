using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Application.Views;

namespace ET.Application.Interfaces
{
    public interface ICategoryBudgetService
    {
        Task<IEnumerable<CategoryBudgetDTO>> GetBudgetsByUserIdAsync(int userId);
        Task<CategoryBudgetDTO> GetBudgetByIdAsync(int id);
        Task<CategoryBudgetDTO> CreateBudgetAsync(CreateCategoryBudgetDTO createDto);
        Task<CategoryBudgetDTO> UpdateBudgetAsync(int id, UpdateCategoryBudgetDTO updateDto);
        Task<bool> DeleteBudgetAsync(int id);

       
    }
}
