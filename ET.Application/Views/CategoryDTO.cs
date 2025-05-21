using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
        [MaxLength(50, ErrorMessage = "Name must not exceed 50 characters.")]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "Description must not exceed 200 characters.")]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
        public int UserId { get; set; }
    }

    public class UpdateCategoryDTO
    {
   
        public string Name { get; set; }
        public string Description { get; set; }

    }
}


