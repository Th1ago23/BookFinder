using Bookfinder.Data;
using Bookfinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Bookfinder.Controllers
{
    public class BookController : Controller
    {
        private readonly MyContext _context;

        public BookController(MyContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }


        public async Task<IActionResult> Index()
        {
            var books = await _context.Books
                .Include(b => b.User)
                .OrderBy(i => i.Title)
                .ToListAsync();
            return View(books);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Author,Category,Comment,Rating,IsReaded,UserId")] Book book)
        {
            ModelState.Remove("User"); // Remove a validação para o campo de navegação 'User'

            foreach (var state in ModelState)
            {
                Console.WriteLine($"Key: {state.Key}, Errors: {string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage))}");
            }
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", book.UserId);
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


        public async Task<IActionResult> Edit(int? Id)
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            if (Id == null)
            {
                return NotFound();
            }
            var book = await _context.Books.SingleOrDefaultAsync(i => i.Id == Id);

            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? Id, [Bind("Id, Title,Author,Category,Comment,Rating,IsReaded,UserId")] Book book)
        {
            ModelState.Remove("User");

            if (Id != book.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try{
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {    
                   throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
    }
}
