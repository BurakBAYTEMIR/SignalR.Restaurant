using Microsoft.AspNetCore.Mvc;

namespace SignalR.Restaurant.Web.UI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
