    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ET.Application.Views
    {
        public class ExpenseDTO
        {
            public int Id { get; set; }

            public string? Description { get; set; }

        public int CategoryId { get; set; }

        public decimal? Amount { get; set; }

        public DateTime Date { get; set; }


        public string? Notes { get; set; }
        }
        public class CreateExpenseDTO
        {
            public string? Description { get; set; }
            public decimal Amount { get; set; }

        public int CategoryId { get; set; }
        public string? Notes { get; set; }
        public DateTime Date { get; set; }         
         
        }

        public class UpdateExpenseDTO
        {
            public string? Description { get; set; }
            public decimal? Amount { get; set; }
     
            public string? Notes { get; set; }

       
        public DateTime Date { get; set; }
        }
    }
