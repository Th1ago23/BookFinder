using Bookfinder.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Bookfinder.Data;

namespace Bookfinder.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            int totalBooks = await _context.Books.CountAsync();
            int readedBooks = await _context.Books.CountAsync(b => b.IsReaded);
            double progress = ((double)readedBooks/totalBooks) * 100;
            string formatedProgress = progress.ToString("F0");

            var Dashboard = new Dashboard
            {
                TotalBooks = totalBooks,
                TotReadedBooks = readedBooks,
                Progress = formatedProgress
                
            }; 

            return View(Dashboard);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
