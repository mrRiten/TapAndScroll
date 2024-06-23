using TapAndScroll.Core.Models;
using TapAndScroll.Core.ViewModels;

namespace TapAndScroll.Application.RepositoryContracts
{
    public interface IProductRepository
    {
        public Task<List<ProductDTO>> GetAllAsync(int categoryId);
        public Task<Product?> GetProductByIdAsync(int productId);
        public Task<Product?> GetProductBySlug(string slug);
        public Task<Product?> GetLastProductAsync(int categoryId);

        public Task<Product> CreateAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(int productId);
    }
}
