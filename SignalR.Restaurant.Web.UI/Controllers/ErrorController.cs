using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalR.Restaurant.Web.UI.Controllers
{
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        public IActionResult NotFound404Page()
        {
            return View();
        }
    }
}
