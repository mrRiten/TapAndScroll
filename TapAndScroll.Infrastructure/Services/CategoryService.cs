﻿using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;
using SlugGenerator;

namespace TapAndScroll.Infrastructure.Services
{
    public class CategoryService(ICategoryRepository categoryRepository, IAdditionalParametersCategoryRepository parametersRepository) : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IAdditionalParametersCategoryRepository _parametersRepository = parametersRepository;

        // ToDo: Add mark for range-parameter
        public async Task CreateCategoryAsync(UploadCategory model)
        {
            var category = new Category
            {
                CategoryName = model.Name,
                CategoryDescription = model.Description,
            };

            var categoryNew = await _categoryRepository.CreateAsync(category);

            var parameters = model.AdditionalParameters.Split(',');
            var additionalParametersList = new List<AdditionalParametersCategory>();

            foreach (var parameter in parameters)
            {
                additionalParametersList.Add(new AdditionalParametersCategory 
                { 
                    CategoryId = categoryNew.IdCategory, 
                    NameParameters = parameter,
                    SlugParameters = parameter.GenerateSlug(),
                });
            }

            await _parametersRepository.CreateAsync([.. additionalParametersList]);
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
