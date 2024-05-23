using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.UploadModels;
using TapAndScroll.Core.ViewModels;

namespace TapAndScroll.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController(ICategoryService categoryService, IProductService productService,
        IImageProductService imageProductService) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IProductService _productService = productService;
        private readonly IImageProductService _imageProductService = imageProductService;

        public async Task<IActionResult> Index()
        {
            var model = new ListCategory
            {
                Categories = await _categoryService.GetCategoriesAsync(),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(UploadCategory model)
        {
            await _categoryService.CreateCategoryAsync(model);

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet("Admin/AddProductForm/{categoryId}")]
        public async Task<IActionResult> AddProductForm(int categoryId)
        {
            var model = new UploadProductCategory
            {
                TargetCategory = await _categoryService.GetCategoryByIdAsync(categoryId)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(UploadProductCategory model)
        {
            var newProduct = await _productService.CreateProductAsync(model.UploadProduct);
            await _imageProductService.CreateImageProductAsync(newProduct.IdProduct, model.UploadProduct.ProductImg);

            return RedirectToAction("Index", "Admin");
        }

    }
}
