using Microsoft.AspNetCore.Mvc;

namespace OrderRestaurantWebUI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
