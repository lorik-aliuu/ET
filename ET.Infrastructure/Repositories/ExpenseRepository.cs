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
    public class ExpenseRepository : Repository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Expense?> GetExpenseAsync(int id, CancellationToken ct = default)
        {
            return await _context.Expenses.FirstOrDefaultAsync(b => b.Id == id, ct);
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync(CancellationToken ct = default)
        {
            return await _context.Expenses.ToListAsync(ct);
        }

        public async Task<Expense> AddExpenseAsync(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<Expense> UpdateExpenseAsync(Expense expense, CancellationToken ct = default)
        {
            var existingExpense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == expense.Id, ct);
            if (existingExpense == null)
            {
                throw new InvalidOperationException($"Expense with ID {expense.Id} not found.");
            }

            _context.Entry(existingExpense).CurrentValues.SetValues(expense);
            await _context.SaveChangesAsync(ct);
            return existingExpense;
        }

        public async Task<bool> DeleteExpenseAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return false;
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> GetTotalExpensesForCategoryAsync(int userId, int categoryId, CancellationToken ct = default)
        {
            return await _context.Expenses
                .Where(e => e.UserId == userId && e.CategoryId == categoryId)
                .SumAsync(e => e.Amount ?? 0, ct);
        }

        public async Task<decimal> GetTotalExpensesForUserAsync(int userId, CancellationToken ct = default)
        {
            return await _context.Expenses
                .Where(e => e.UserId == userId)
                .SumAsync(e => e.Amount ?? 0, ct);
        }

        public async Task<IEnumerable<Expense>> GetExpensesByUserIdAsync(int userId)
        {
            return await _context.Expenses
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetExpensesByCategoryIdAsync(int categoryId)
        {
            return await _context.Expenses
                                 .Where(e => e.CategoryId == categoryId)
                                 .ToListAsync();
        }
    }
}
