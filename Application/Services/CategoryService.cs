using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new CategoryDTO { Id = c.Id, Name = c.Name }).ToList();
        }

        public async Task<CategoryDTO?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category is null ? null : new CategoryDTO { Id = category.Id, Name = category.Name };
        }
        public async Task<CategoryDTO?> GetCategoryByNameAsync(string categoryName)
        {
            var category = await _categoryRepository.GetByNameAsync(categoryName);
            return category is null ? null : new CategoryDTO { Id = category.Id, Name = category.Name };
        }
    }
}
