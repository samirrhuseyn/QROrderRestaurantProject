using Microsoft.AspNetCore.Mvc;

namespace OrderRestaurantWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
