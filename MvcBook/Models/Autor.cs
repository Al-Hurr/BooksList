using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBook.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }

        public string Email { get; set; }

        [NotMapped]
        public string ReturnUrl { get; set; }
        [NotMapped]
        public bool InBook { get; set; } = false;
        [NotMapped]
        [Display(Name = "Books")]
        public List<Book> BooksforAuthor { get; set; }
    }
}
