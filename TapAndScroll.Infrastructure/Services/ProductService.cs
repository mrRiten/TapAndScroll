using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;
using TapAndScroll.Core.ViewModels;
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

            var product = new Product
            {
                ProductName = model.ProductName,
                CategoryId = model.CategoryId,
                Description = model.Description,
            };

            product = await _productRepository.CreateAsync(product);

            var parameters = _parametersHelper.CreateListParameters(model.AdditionalParameters, product.IdProduct);

            await _additionalParametersRepository.CreateAsync([.. parameters]);

            return await _productRepository.GetLastProductAsync(product.CategoryId);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public Task<Product> GetProductByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetProductBySlugAsync(string slug)
        {
            return await _productRepository.GetProductBySlug(slug);
        }

        public Task<ICollection<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ProductDTO>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _productRepository.GetAllAsync(categoryId);
        }

        public async Task UpdateProductAsync(Product model)
        {
            await _productRepository.UpdateAsync(model);

            var sourceParameters = await _additionalParametersRepository.GetByProductId(model.IdProduct);
            var editParameters = _parametersHelper.CreateListParameters(model.AdditionalParameters, model.IdProduct);

            // Сопоставление объектов на основе `Key` и копирование `IdAAdditionalParameters`
            foreach (var editParam in editParameters)
            {
                var sourceParam = sourceParameters.FirstOrDefault(sp => sp.Key == editParam.Key);
                if (sourceParam != null)
                {
                    editParam.IdAAdditionalParameters = sourceParam.IdAAdditionalParameters;
                }
            }

            await _additionalParametersRepository.UpdateAsync([.. editParameters]);


        }
    }
}
