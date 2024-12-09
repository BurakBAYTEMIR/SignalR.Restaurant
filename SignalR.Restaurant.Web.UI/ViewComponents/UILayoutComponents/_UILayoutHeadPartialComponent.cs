using Microsoft.AspNetCore.Mvc;

namespace SignalR.Restaurant.Web.UI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeadPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
