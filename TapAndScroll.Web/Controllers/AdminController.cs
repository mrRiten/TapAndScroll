using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TapAndScroll.Application.ServiceContracts;
using TapAndScroll.Core.UploadModels;

namespace TapAndScroll.Web.Controllers
{
    public class AdminController(ICategoryService categoryService) : Controller
    {
        private readonly ICategoryService _categoryService = categoryService;

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCategory(UploadCategory model)
        {
            await _categoryService.CreateCategoryAsync(model);

            return RedirectToAction("Index", "Admin");
        }
    }
}
