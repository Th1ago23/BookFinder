using Locacoes.Models;
using System.ComponentModel.DataAnnotations;
namespace Locacoes.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Range(1000, 9999)]
        public int Ano { get; set; }

        [Required]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        public Categoria categoria { get; set; }
    }
}

