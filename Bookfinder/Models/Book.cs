using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Bookfinder.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Author { get; set; }

        [Required]
        public String Category { get; set; }

        [Required]
        public String Comment { get; set; }

        [Required]
        public float Rating { get; set; }

        [Required]
        public bool IsReaded {  get; set; }
    }
}
