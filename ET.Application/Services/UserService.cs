using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ET.Application.Interfaces;
using ET.Application.Views;
using ET.Domain.Entities;
using ET.Domain.Interfaces;

namespace ET.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordService passwordService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        public async Task<UserDTO> CreateUserAsync(UserRegistrationDTO userRegistration)
        {
            // Check if user with email exists
            var existingUser = await _unitOfWork.UserRepository.GetByEmailAsync(userRegistration.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists.");
            }

            // Map registration DTO to User entity
            var user = _mapper.Map<User>(userRegistration);

            // Hash password before saving
            user.PasswordHash = _passwordService.HashPassword(userRegistration.Password);

            // Add user and save changes
            await _unitOfWork.UserRepository.AddUserAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);
            if (user == null) return null;
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUserAsync(int userId, UpdateUserDTO updateUserDto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found.");

            
            _mapper.Map(updateUserDto, user);

            await _unitOfWork.UserRepository.UpdateUserAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            return await _unitOfWork.UserRepository.DeleteUserAsync(id);
        }

        public async Task<bool> IsAuthenticated(string email, string password)
        {
            var user = await _unitOfWork.UserRepository.GetByEmailAsync(email);
            if (user == null) return false;

            return _passwordService.VerifyPassword(user.PasswordHash, password);
        }
    }
}
