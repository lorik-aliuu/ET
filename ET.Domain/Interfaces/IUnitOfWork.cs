using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Domain.Interfaces
{
    public interface IUnitOfWork
    {

        IExpenseRepository ExpenseRepository { get; }

        ICategoryBudgetRepository CategoryBudgetRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken ct =  default);
    }
}
