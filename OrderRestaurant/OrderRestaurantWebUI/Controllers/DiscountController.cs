using Microsoft.AspNetCore.Mvc;

namespace OrderRestaurantWebUI.Controllers
{
    public class DiscountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
