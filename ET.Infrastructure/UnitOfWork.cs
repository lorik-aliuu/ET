using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Domain.Interfaces;
using ET.Infrastructure.Repositories;

namespace ET.Infrastructure
{
    public class UnitOfWork : IUnitOfWork 
    {
        readonly ApplicationDbContext _context;

        IExpenseRepository _expenseRepository;
        IUserRepository _userRepository;
        ICategoryRepository _categoryRepository;
        ICategoryBudgetRepository _categoryBudgetRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IExpenseRepository ExpenseRepository
        {
            get
            {
                if(_expenseRepository == null)
                    _expenseRepository = new ExpenseRepository(_context);
                return _expenseRepository;
            }
        }

        public ICategoryBudgetRepository CategoryBudgetRepository
        {
            get
            {
                if (_categoryBudgetRepository == null)
                    _categoryBudgetRepository = new CategoryBudgetRepository(_context);
                return _categoryBudgetRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository(_context);
                return _categoryRepository;
            }
        }


        async Task<int> IUnitOfWork.SaveChangesAsync(CancellationToken ct)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
