using Microsoft.AspNetCore.Mvc;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.ViewModels;

namespace TapAndScroll.Web.Controllers
{
    public class CatalogController(ICategoryService categoryService, ICatalogService catalogService,
        IProductService productService) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly ICatalogService _catalogService = catalogService;
        private readonly IProductService _productService = productService;


        [HttpGet("Catalog/Index/{idCategory}")]
        public async Task<IActionResult> Index(int idCategory)
        {
            Task<Category> category = _categoryService.GetCategoryByIdAsync(idCategory);
            Task<ICollection<Product>> products = _productService.GetProductsByCategoryAsync(idCategory);

            var filterModel = new FilterProduct
            {
                Category = await category,
                Products = await products,
            };

            return View(filterModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(FilterProduct filterModel)
        {
            Task<ICollection<Product>> products = _catalogService.FilterProduct((int)filterModel.FilterUpload.CategoryId, filterModel.FilterUpload);
            Task<Category> category = _categoryService.GetCategoryByIdAsync((int)filterModel.FilterUpload.CategoryId);

            filterModel.Products = await products;
            filterModel.Category = await category;

            return View(filterModel);
        }
    }
}
