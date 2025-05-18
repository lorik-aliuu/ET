using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Application.Views;

namespace ET.Application.Interfaces
{
    public interface IExpenseService
    {
        Task<ExpenseDTO> CreateExpenseAsync(int userId, int categoryId, CreateExpenseDTO expenseDto);
        Task<IEnumerable<ExpenseDTO>> GetAllExpensesAsync();
        Task<ExpenseDTO?> GetExpenseByIdAsync(int id);
        Task<ExpenseDTO?> UpdateExpenseAsync(int id, UpdateExpenseDTO expenseDto);
        Task<bool> DeleteExpenseAsync(int id);

        Task<bool> CanAddExpenseAsync(int userId, int categoryId, decimal newAmount);
    }
}
