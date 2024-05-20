using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Infrastructure.Services
{
    public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task CreateCategoryAsync(UploadCategory model)
        {
            var category = new Category
            {
                CategoryName = model.Name,
                CategoryDescription = model.Description,
                AdditionalParameters = model.AdditionalParameters
            };

            await _categoryRepository.CreateAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<ICollection<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            return await _categoryRepository.GetByNameAsync(name);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
