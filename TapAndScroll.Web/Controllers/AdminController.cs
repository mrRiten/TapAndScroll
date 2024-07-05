using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.Models;
using TapAndScroll.Core.UploadModels;
using TapAndScroll.Core.ViewModels;
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
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(UploadCategory model)
        {
            await _categoryService.CreateCategoryAsync(model);

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoryService.GetCategoriesAsync();

            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            Task<ICollection<ProductDTO>> productsTask = _productService.GetProductsByCategoryAsync(categoryId);
            Task categoryTask = _categoryService.DeleteCategoryAsync(categoryId);

            await Task.WhenAll(productsTask, categoryTask);

            foreach (var productDTO in await productsTask)
            {
                ImageWebHelper.DeleteImages(productDTO.Product.IdProduct, _webHostEnvironment);
            }

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
            ImageWebHelper.SaveImages(newProduct.IdProduct, model.UploadProduct.ProductImg, _webHostEnvironment);

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet("Admin/ProductList/{categoryId}")]
        public async Task<IActionResult> ProductList(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryAsync(categoryId);

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> EditProduct(string slug)
        {
            var product = await _productService.GetProductBySlugAsync(slug);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            await _productService.UpdateProductAsync(product);

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _productService.DeleteProductAsync(productId);

            ImageWebHelper.DeleteImages(productId, _webHostEnvironment);

            return RedirectToAction("Index", "Admin");
        }
    }
}
