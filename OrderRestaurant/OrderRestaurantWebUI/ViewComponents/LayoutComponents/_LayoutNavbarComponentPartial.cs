using Microsoft.AspNetCore.Mvc;

namespace OrderRestaurantWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
