using Microsoft.AspNetCore.Mvc;

namespace OrderRestaurantWebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
