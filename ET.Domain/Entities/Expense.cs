using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Domain.Entities
{
   
        public class Expense : Entity
    {
           public string? Description { get; set; }
         
            public decimal? Amount { get; set; }
    
            public bool? IsRecurring { get; set; }

            public string? Notes { get; set; }

            public DateTime Date { get; set; } = DateTime.UtcNow;

        public int UserId { get; set; }
        public int CategoryId { get; set; }

       
        public User User { get; set; } = null!;
        public Category Category { get; set; } = null!;



    }
    
}
