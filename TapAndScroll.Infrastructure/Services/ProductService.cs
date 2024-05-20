using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        public Task CreateProductAsync(UploadProduct model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product model)
        {
            throw new NotImplementedException();
        }
    }
}
