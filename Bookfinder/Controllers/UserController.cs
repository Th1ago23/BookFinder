using Microsoft.AspNetCore.Mvc;

namespace Bookfinder.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
