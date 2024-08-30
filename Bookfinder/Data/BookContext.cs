using Bookfinder.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookfinder.Data
{
    public class BookContext : DbContext
    {
        public  BookContext(DbContextOptions<BookContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }

    }
}
