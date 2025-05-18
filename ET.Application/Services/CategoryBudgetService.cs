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
    public class CategoryBudgetService : ICategoryBudgetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryBudgetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryBudgetDTO>> GetBudgetsByUserIdAsync(int userId)
        {
            var budgets = await _unitOfWork.CategoryBudgetRepository.GetByUserAsync(userId);
            return _mapper.Map<IEnumerable<CategoryBudgetDTO>>(budgets);
        }

        public async Task<CategoryBudgetDTO> GetBudgetByIdAsync(int id)
        {
            var budget = await _unitOfWork.CategoryBudgetRepository.GetBudgetByIdAsync(id);
            if (budget == null) return null;
            return _mapper.Map<CategoryBudgetDTO>(budget);
        }

        public async Task<CategoryBudgetDTO> CreateBudgetAsync(CreateCategoryBudgetDTO createDto)
        {
            var budget = _mapper.Map<CategoryBudget>(createDto);
            await _unitOfWork.CategoryBudgetRepository.AddCategoryBudgetAsync(budget);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryBudgetDTO>(budget);
        }

        public async Task<CategoryBudgetDTO> UpdateBudgetAsync(int id, UpdateCategoryBudgetDTO updateDto)
        {
            var existingBudget = await _unitOfWork.CategoryBudgetRepository.GetBudgetByIdAsync(id);
            if (existingBudget == null)
                throw new Exception("Category budget not found");

            _mapper.Map(updateDto, existingBudget);
            await _unitOfWork.CategoryBudgetRepository.UpdateCategoryBudgetAsync(existingBudget);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryBudgetDTO>(existingBudget);
        }

        public async Task<bool> DeleteBudgetAsync(int id)
        {
            var result = await _unitOfWork.CategoryBudgetRepository.DeleteCategoryBudgetAsync(id);
            if (result)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return result;
        }

       
    }
}

