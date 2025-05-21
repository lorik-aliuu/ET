using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Application.Views
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
    }

    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int UserId { get; set; }
    }

    public class UpdateCategoryDTO
    {
   
        public string Name { get; set; }
        public string Description { get; set; }

    }
}


