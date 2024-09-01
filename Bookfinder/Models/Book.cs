using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookfinder.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        
        public String Title { get; set; }

        
        public String Author { get; set; }

        
        public String Category { get; set; }

        
        public String Comment { get; set; }

        
        public int Rating { get; set; }

        public bool IsReaded {  get; set; }

        public int UserId { get; set; }

        // Propriedade de navegação
        [ForeignKey("UserId")]
        [NotMapped]
        public User User { get; set; }
    }
}
