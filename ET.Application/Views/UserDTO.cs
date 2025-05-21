using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Application.Views
{
    public class UserDTO
    {
        public int Id { get; set; }          
        public string Name { get; set; }     
        public string Email { get; set; }  

        public decimal OverAllBudget { get; set; }
    }

    public class UserRegistrationDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Budget must be zero or positive.")]
        public decimal OverAllBudget { get; set; }
    }

    public class UpdateUserDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Budget must be zero or positive.")]
        public decimal OverAllBudget { get; set; }
    }

    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
