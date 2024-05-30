using Microsoft.AspNetCore.Mvc;

namespace TapAndScroll.Web.Controllers
{
    public class CatalogController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int idCategory)
        {

            return View();
        }
    }
}
