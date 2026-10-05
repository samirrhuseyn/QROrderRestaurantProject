using Microsoft.AspNetCore.Mvc;

namespace OrderRestaurantWebUI.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
