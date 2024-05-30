using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;
using TapAndScroll.Infrastructure.Repositories;

namespace TapAndScroll.Infrastructure.Services
{
    public class ProductService(IProductRepository productRepository,
        IAdditionalParametersRepository additionalParametersRepository,
        IParametersHelper parametersHelper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IAdditionalParametersRepository _additionalParametersRepository = additionalParametersRepository;
        private readonly IParametersHelper _parametersHelper = parametersHelper;

        public async Task<Product> CreateProductAsync(UploadProduct model)
        {
            var countProductOnLastPage = await _productRepository.GetCountProductOnPageAsync();
            int page;

            if (countProductOnLastPage >= 10)
            {
                page = 0;
            }
            else
            {
                page = countProductOnLastPage+1;
            }

            var product = new Product
            {
                Brand = model.Brand,
                ProductName = model.ProductName,
                Price = model.Price,
                IsGaming = model.IsGaming,
                CategoryId = model.CategoryId,
                Description = model.Description,
                DiscountPercent = model.DiscountPercent,
                Page = page,
            };

            product = await _productRepository.CreateAsync(product);

            var parameters = _parametersHelper.CreateListParameters(model.AdditionalParameters, product.IdProduct);

            await _additionalParametersRepository.CreateAsync([.. parameters]);

            return await _productRepository.GetLastProductAsync();
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
