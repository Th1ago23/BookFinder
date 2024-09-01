using System.ComponentModel.DataAnnotations;

namespace Bookfinder.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
