using Microsoft.AspNetCore.Mvc;

namespace SignalR.Restaurant.Web.UI.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
