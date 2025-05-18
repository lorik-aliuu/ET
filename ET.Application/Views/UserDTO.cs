using System;
using System.Collections.Generic;
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

        public decimal OverallBudget { get; set; }
    }

    public class UserRegistrationDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public decimal OverallBudget { get; set; }
    }

    public class UpdateUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public decimal OverallBudget { get; set; }
    }

    public class UserLoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
