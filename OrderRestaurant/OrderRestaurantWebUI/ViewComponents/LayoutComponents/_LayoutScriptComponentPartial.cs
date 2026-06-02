using Microsoft.AspNetCore.Mvc;

namespace OrderRestaurantWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); 
        }
    }
}
