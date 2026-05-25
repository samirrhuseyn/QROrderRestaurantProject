using Microsoft.AspNetCore.Mvc;

namespace OrderRestaurantWebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
