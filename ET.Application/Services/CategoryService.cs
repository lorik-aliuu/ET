using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ET.Application.Interfaces;
using ET.Application.Views;
using ET.Domain.Entities;
using ET.Domain.Interfaces;

namespace ET.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO?> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetCategoryByIdAsync(id);
            return category == null ? null : _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CreateCategoryDTO createDto)
        {
            var category = _mapper.Map<Category>(createDto);
            await _unitOfWork.CategoryRepository.AddCategoryAsync(category);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO?> UpdateCategoryAsync(int id, UpdateCategoryDTO updateDto)
        {
            var existingCategory = await _unitOfWork.CategoryRepository.GetCategoryByIdAsync(id);
            if (existingCategory == null) return null;

            _mapper.Map(updateDto, existingCategory);

            await _unitOfWork.CategoryRepository.UpdateCategoryAsync(existingCategory);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<CategoryDTO>(existingCategory);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var deleted = await _unitOfWork.CategoryRepository.DeleteCategoryAsync(id);
            if (deleted)
            {
                await _unitOfWork.SaveChangesAsync();
            }
            return deleted;
        }
    }
}
