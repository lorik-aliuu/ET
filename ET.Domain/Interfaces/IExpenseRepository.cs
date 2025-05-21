using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Domain.Entities;

namespace ET.Domain.Interfaces
{
    public interface IExpenseRepository : IRepository<Expense>
    {
        Task<Expense?> GetExpenseAsync(int id, CancellationToken ct = default);

        Task<IEnumerable<Expense>> GetAllExpensesAsync(CancellationToken ct = default);

        Task<Expense> AddExpenseAsync(Expense expense);

        Task<Expense> UpdateExpenseAsync(Expense expense, CancellationToken ct = default);

        Task<bool> DeleteExpenseAsync(int id);

        Task<decimal> GetTotalExpensesForCategoryAsync(int userId, int categoryId, CancellationToken ct = default);
        Task<decimal> GetTotalExpensesForUserAsync(int userId, CancellationToken ct = default);

        Task<IEnumerable<Expense>> GetExpensesByUserIdAsync(int userId);

        Task<IEnumerable<Expense>> GetExpensesByCategoryIdAsync(int categoryId);


    }
}
