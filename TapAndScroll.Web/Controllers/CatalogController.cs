using Microsoft.AspNetCore.Mvc;

namespace TapAndScroll.Web.Controllers
{
    public class CatalogController : Controller
    {
        [HttpGet("Catalog/Index/{id?}")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
