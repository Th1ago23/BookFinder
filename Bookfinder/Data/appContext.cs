using Microsoft.EntityFrameworkCore;
using Bookfinder.Models;

namespace Bookfinder.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        // DbSet para Books
        public DbSet<Book> Books { get; set; }

        // DbSet para Users
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar a relação 1:N entre User e Book
            modelBuilder.Entity<User>()
                .HasMany(u => u.Books)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Adiciona comportamento de deleção em cascata
        }
    }
}
