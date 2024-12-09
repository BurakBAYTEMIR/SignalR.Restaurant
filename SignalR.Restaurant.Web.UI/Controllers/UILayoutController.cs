using Microsoft.AspNetCore.Mvc;

namespace SignalR.Restaurant.Web.UI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
