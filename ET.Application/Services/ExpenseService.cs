using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ET.Application.Interfaces;
using ET.Application.Views;
using ET.Domain.Entities;
using ET.Domain.Interfaces;

namespace ET.Application.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpenseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
            
        public async Task<ExpenseDTO> CreateExpenseAsync(int userId, int categoryId, CreateExpenseDTO expenseDto)
        {
            bool canAdd = await CanAddExpenseAsync(userId, categoryId, expenseDto.Amount);
            if (!canAdd)
            {
                throw new Exception("Expense exceeds category or overall user budget.");
            }

            var expense = _mapper.Map<Expense>(expenseDto);
            expense.UserId = userId;
            expense.CategoryId = categoryId;

            var result = await _unitOfWork.ExpenseRepository.AddExpenseAsync(expense);
            return _mapper.Map<ExpenseDTO>(result);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAllExpensesAsync()
        {
            var expenses = await _unitOfWork.ExpenseRepository.GetAllExpensesAsync();
            return _mapper.Map<IEnumerable<ExpenseDTO>>(expenses);
        }

        public async Task<ExpenseDTO?> GetExpenseByIdAsync(int id)
        {
            var expense = await _unitOfWork.ExpenseRepository.GetExpenseAsync(id);
            return expense == null ? null : _mapper.Map<ExpenseDTO>(expense);
        }

        public async Task<ExpenseDTO?> UpdateExpenseAsync(int id, UpdateExpenseDTO expenseDto)
        {
            var existingExpense = await _unitOfWork.ExpenseRepository.GetExpenseAsync(id);
            if (existingExpense == null)
                return null;

            _mapper.Map(expenseDto, existingExpense);
            var updated = await _unitOfWork.ExpenseRepository.UpdateExpenseAsync(existingExpense);
            return _mapper.Map<ExpenseDTO>(updated);
        }

        public async Task<bool> DeleteExpenseAsync(int id)
        {
            return await _unitOfWork.ExpenseRepository.DeleteExpenseAsync(id);
        }

        public async Task<bool> CanAddExpenseAsync(int userId, int categoryId, decimal newAmount)
        {
            var categoryBudget = await _unitOfWork.CategoryBudgetRepository.GetByUserAndCategoryAsync(userId, categoryId);
            if (categoryBudget == null) return false;

            var totalCategoryExpenses = await _unitOfWork.ExpenseRepository.GetTotalExpensesForCategoryAsync(userId, categoryId);
            if (totalCategoryExpenses + newAmount > categoryBudget.Budget)
                return false;

            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(userId);
            if (user == null) return false;

            var totalExpenses = await _unitOfWork.ExpenseRepository.GetTotalExpensesForUserAsync(userId);
            if (totalExpenses + newAmount > user.OverAllBudget)
                return false;

            return true;
        }

       
            public async Task<IEnumerable<ExpenseDTO>> GetExpensesByUserIdAsync(int userId)
        {
            var expenses = await _unitOfWork.ExpenseRepository.GetExpensesByUserIdAsync(userId);

            // Use AutoMapper to map entities to DTOs
            var expenseDtos = _mapper.Map<IEnumerable<ExpenseDTO>>(expenses);

            return expenseDtos;
        }

        public async Task<IEnumerable<ExpenseDTO>> GetExpensesByCategoryIdAsync(int categoryId)
        {
            var expenses = await _unitOfWork.ExpenseRepository.GetExpensesByCategoryIdAsync(categoryId);
            return _mapper.Map<IEnumerable<ExpenseDTO>>(expenses);
        }

    }
    
}
