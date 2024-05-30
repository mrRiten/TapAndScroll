using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.UploadModels;
using TapAndScroll.Core.ViewModels;

namespace TapAndScroll.Infrastructure.Services
{
    public class CatalogService(IProductRepository productRepository, ICategoryRepository categoryRepository) : ICatalogService
    {
        public readonly IProductRepository _productRepository = productRepository;
        public readonly ICategoryRepository _categoryRepository = categoryRepository;

        public Task<CatalogProduct> FilterProduct(FilterUpload filter)
        {
            throw new NotImplementedException();
        }

        public async Task<CatalogProduct> GetProducts(int categoryId, int page)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(categoryId, page);
            var currentCategory = await _categoryRepository.GetByIdAsync(categoryId);

            var catalogProduct = new CatalogProduct
            {
                Category = currentCategory,
                Products = products
            };

            return catalogProduct;
        }
    }
}
