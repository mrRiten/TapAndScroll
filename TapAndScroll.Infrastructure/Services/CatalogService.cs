using TapAndScroll.Application.HelperContracts;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;
using TapAndScroll.Core.ViewModels;

namespace TapAndScroll.Infrastructure.Services
{
    public class CatalogService(IProductRepository productRepository, ICategoryRepository categoryRepository, 
        IParametersHelper parametersHelper, IFilterHelper filterHelper) : ICatalogService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IParametersHelper _parametersHelper = parametersHelper;
        private readonly IFilterHelper _filterHelper = filterHelper;

        public async Task<CatalogProduct> GetProducts(int categoryId, int page)
        {
            var products = await _productRepository.GetProductsByCategoryAsync(categoryId);
            var currentCategory = await _categoryRepository.GetByIdAsync(categoryId);

            var catalogProduct = new CatalogProduct
            {
                Category = currentCategory,
                Products = products
            };

            return catalogProduct;
        }

        //Fix: Region locale for parse "." or ","
        public async Task<ICollection<Product>> FilterProduct(int categoryId, FilterUpload filter)
        {
            var products = await _productRepository.GetAllAsync(categoryId);

            var filterList = _parametersHelper.CreateListParameters(filter.AdditionalParameters, 0);
            filterList.RemoveAt(0); // Delete ASP.Net Core spec parameters

            foreach (var parameter in filterList)
            {
                var middleFilterList = new List<Product>();
                if (parameter.Value != null && parameter.Value.Length > 1)
                {
                    var targetKey = parameter.Key;
                    var targetValue = parameter.Value;

                    if (targetValue.Contains('~'))
                    {
                        if (!_filterHelper.GetCorrectValues(parameter, out decimal beginValue, out decimal endValue)) { continue; }

                        foreach (var prod in products)
                        {
                            if (_filterHelper.DoRangeQuery(prod, targetKey, beginValue, endValue))
                            {
                                middleFilterList.Add(prod);
                            }
                        }
                    }
                    else
                    {

                        targetValue = _filterHelper.GetCorrectValue(parameter);

                        foreach (var prod in products)
                        {
                            if (_filterHelper.DoAloneQuery(prod, targetKey, targetValue))
                            {
                                middleFilterList.Add(prod);
                            }
                        }
                    }

                    products = middleFilterList;
                }

            }

            return products;
        }

    }
}
