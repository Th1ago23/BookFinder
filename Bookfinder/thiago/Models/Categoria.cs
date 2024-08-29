using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locacoes.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        public ICollection<Livro> livros { get; set; }
    }
}
