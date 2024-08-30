using Bookfinder.Data;
using Bookfinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Bookfinder.Controllers
{
    public class BookController : Controller
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

       

        [Route("book")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.OrderBy(i => i.Title).ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title", "Author", "Category")] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(book);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "DEU RUIM"); 
            }
            return View(book);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await _context.Books.SingleOrDefaultAsync(i => i.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }


        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await _context.Books.SingleOrDefaultAsync(i => i.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long? id)
        {
            var book = await _context.Books.SingleOrDefaultAsync(i => i.Id == id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await _context.Books.SingleOrDefaultAsync(i => i.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Id", "Title", "Author", "Category")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                        throw;
                   
                }
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
