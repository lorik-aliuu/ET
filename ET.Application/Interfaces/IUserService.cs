using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ET.Application.Views;

namespace ET.Application.Interfaces
{
  
        public interface IUserService
        {
            Task<UserDTO> CreateUserAsync(UserRegistrationDTO userRegistration);

            Task<IEnumerable<UserDTO>> GetUsersAsync();

            Task<UserDTO> GetUserByIdAsync(int id);
        
        Task<UserDTO> UpdateUserAsync(int userId, UpdateUserDTO updateUserDto);


        Task<bool> DeleteUserAsync(int id);

            Task<bool> IsAuthenticated(string email, string password);

        }
    
}
