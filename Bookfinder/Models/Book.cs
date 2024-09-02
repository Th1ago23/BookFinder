using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookfinder.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public String Title { get; set; }

        [Required]
        [MaxLength(30)]
        public String Author { get; set; }

        [Required]
        [MaxLength(20)]
        public String Category { get; set; }

        [Required]
        [MaxLength(100)]
        public String Comment { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public bool IsReaded {  get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
