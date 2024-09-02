using Microsoft.AspNetCore.Mvc;

namespace Bookfinder.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
