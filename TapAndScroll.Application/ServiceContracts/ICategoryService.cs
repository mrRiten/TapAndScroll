using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Application.ServiceContracts
{
    public interface ICategoryService
    {
        public Task<ICollection<Category>> GetCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<Category> GetCategoryByNameAsync(string name);

        public Task CreateCategoryAsync(UploadCategory model);
        public Task DeleteCategoryAsync(int id);
        public Task UpdateCategoryAsync(Category category);
    }
}
