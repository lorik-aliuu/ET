using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Application.Views
{
    public class CategoryBudgetDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public decimal Budget { get; set; }
    }

    public class CreateCategoryBudgetDTO
    {
        public int UserId { get; set; }

        public int CategoryId { get; set; }

        public decimal Budget { get; set; }
    }

    public class UpdateCategoryBudgetDTO
    {
        public decimal Budget { get; set; }
    }
}
