using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TapAndScroll.Application.RepositoryContracts;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.UploadModels;
using TapAndScroll.Core.ViewModels;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json.Linq;
using TapAndScroll.Web.WebHelpers;

namespace TapAndScroll.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController(ICategoryService categoryService, IProductService productService,
        IImageProductService imageProductService, IWebHostEnvironment webHost) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IProductService _productService = productService;
        private readonly IImageProductService _imageProductService = imageProductService;
        private readonly IWebHostEnvironment _webHostEnvironment = webHost;

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

        [HttpGet("Admin/AddProduct/{categoryId}")]
        public async Task<IActionResult> AddProduct(int categoryId)
        {
            var model = new UploadProductCategory
            {
                TargetCategory = await _categoryService.GetCategoryByIdAsync(categoryId)
            };

            return View(model);
        }

        [HttpPost("Admin/AddProduct/{id?}")]
        public async Task<IActionResult> AddProduct(UploadProductCategory model, int id)
        {
            model.UploadProduct.CategoryId = id;
            var newProduct = await _productService.CreateProductAsync(model.UploadProduct);
            await _imageProductService.CreateImageProductAsync(newProduct.IdProduct, model.UploadProduct.ProductImg);
            ImageSaveWebHelper.SaveImages(newProduct.IdProduct, model.UploadProduct.ProductImg, _webHostEnvironment);

            return RedirectToAction("Index", "Admin");
        }

    }
}
