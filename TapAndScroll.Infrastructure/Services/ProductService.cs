using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;
using TapAndScroll.Infrastructure.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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
                ProductName = model.ProductName,
                CategoryId = model.CategoryId,
                Description = model.Description,
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

        public async Task<ICollection<Product>> GetProductsByParameters(int categoryId, FilterUpload filter)
        {
            var products = await _productRepository.GetAllAsync(categoryId);

            var filterList = _parametersHelper.CreateListParameters(filter.AdditionalParameters, 0);
            filterList.RemoveAt(0);

            foreach (var parameter in filterList)
            {
                var middleFilterList = new List<Product>();
                if (parameter.Value != null && parameter.Value.Length > 1)
                {
                    var targetKey = parameter.Key;
                    var targetValue = parameter.Value;

                    if (targetValue.Contains('~'))
                    {
                        var beginValue = decimal.Parse(parameter.Value.Split("~")[0]);
                        var endValue = decimal.Parse(parameter.Value.Split("~")[1]);

                        foreach( var prod in products)
                        {
                            var pr = from p in prod.Parameters
                                     where p.Key.Contains(targetKey) && decimal.Parse(p.Value) >= beginValue && decimal.Parse(p.Value) <= endValue
                                     select p;

                            if (pr.Count() > 0) { middleFilterList.Add(await _productRepository.GetProductByIdAsync(prod.IdProduct)); }
                        }
                    }
                    else
                    {
                        foreach (var prod in products)
                        {
                            var pr = from p in prod.Parameters
                                     where p.Key == targetKey && p.Value == targetValue
                                     select p;

                            if (pr.Count() > 0) { middleFilterList.Add(await _productRepository.GetProductByIdAsync(prod.IdProduct)); }
                        }
                    }
                    products = middleFilterList;
                }

                
            }

            return products;

        }

        public Task UpdateProductAsync(Product model)
        {
            throw new NotImplementedException();
        }
    }
}
