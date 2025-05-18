using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Domain.Entities
{
    public class CategoryBudget : Entity
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public decimal Budget { get; set; }

        public User User { get; set; } = null!;
        public Category Category { get; set; } = null!;
    }
}
