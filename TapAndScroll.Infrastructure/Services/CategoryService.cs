using TapAndScroll.Application.RepositoryContracts;
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
                var isRange = false;
                var nameParameter = parameter;
                if (parameter.Contains('~'))
                {
                    isRange = true;
                    nameParameter = parameter.Remove(parameter.Length - 1);
                }

                additionalParametersList.Add(new AdditionalParametersCategory 
                { 
                    CategoryId = categoryNew.IdCategory,
                    NameParameters = nameParameter,
                    SlugParameters = nameParameter.GenerateSlug(),
                    IsRange = isRange
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
