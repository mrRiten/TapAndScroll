using Microsoft.AspNetCore.Mvc;
using TapAndScroll.Application.ServiceContracts;
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
            var filterModel = new FilterProduct
            {
                Category = await _categoryService.GetCategoryByIdAsync(idCategory),
                Products = await _productService.GetProductsByCategoryAsync(idCategory)
            };

            return View(filterModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(FilterProduct filterModel)
        {
            filterModel.Products = await _catalogService.FilterProduct((int)filterModel.FilterUpload.CategoryId, filterModel.FilterUpload);
            filterModel.Category = await _categoryService.GetCategoryByIdAsync((int)filterModel.FilterUpload.CategoryId);

            return View(filterModel);
        }
    }
}
