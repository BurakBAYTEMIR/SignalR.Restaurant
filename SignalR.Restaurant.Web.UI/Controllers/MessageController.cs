using Microsoft.AspNetCore.Mvc;

namespace SignalR.Restaurant.Web.UI.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClientUserCount()
        {
            return View();
        } 
    }
}
