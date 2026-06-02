using Microsoft.AspNetCore.Mvc;

namespace OrderRestaurantWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutSidebarComponentsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
