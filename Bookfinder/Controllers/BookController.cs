using Microsoft.AspNetCore.Mvc;

namespace Bookfinder.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
