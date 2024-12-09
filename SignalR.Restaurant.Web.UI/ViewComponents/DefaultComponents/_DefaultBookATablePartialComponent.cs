using Microsoft.AspNetCore.Mvc;

namespace SignalR.Restaurant.Web.UI.ViewComponents.DefaultComponents
{
    public class _DefaultBookATablePartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
