using TapAndScroll.Core.Models;

namespace TapAndScroll.Application.RepositoryContracts
{
    public interface ICategoryRepository
    {
        public Task<ICollection<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(int id);
        public Task<Category?> GetByNameAsync(string name);
        public Task CreateAsync(Category category);
        public Task UpdateAsync(Category category);
        public Task DeleteAsync(int id);
    }
}
