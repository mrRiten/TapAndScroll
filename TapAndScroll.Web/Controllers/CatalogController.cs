using Microsoft.AspNetCore.Mvc;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.ViewModels;

namespace TapAndScroll.Web.Controllers
{
    public class CatalogController(ICategoryService categoryService, IProductService productService) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        public readonly IProductService _productService = productService;

        [HttpGet("Catalog/{idCategory}")]
        public async Task<IActionResult> Index(int idCategory)
        {
            var filterModel = new FilterProduct
            {
                Category = await _categoryService.GetCategoryByIdAsync(idCategory)
            };

            return View(filterModel);
        }

        [HttpPost]
        public async Task<IActionResult> List(FilterProduct filterModel)
        {
            filterModel.Products = await _productService.GetProductsByParameters((int)filterModel.FilterUpload.CategoryId, filterModel.FilterUpload);

            return View(filterModel);
        }
    }
}
