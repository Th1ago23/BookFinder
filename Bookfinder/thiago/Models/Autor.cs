using System.ComponentModel.DataAnnotations;

namespace Locacoes.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Bio { get; set; }

        public ICollection<Livro> livros
        {
            get; set;
        }
    }
}