using Locacoes.Models;
using Microsoft.EntityFrameworkCore;

namespace Locacoes.Data
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions options) : base(options){}
        public DbSet<Autor> autores { get; set; }
        public DbSet<Livro> livros { get; set; }
        public DbSet<Categoria> categorias { get; set; }
    }
}
