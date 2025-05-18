using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<CategoryBudget> CategoryBudgets { get; set; } = new List<CategoryBudget>();
    }


}
