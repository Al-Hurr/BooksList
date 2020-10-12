using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcBook.Models
{
    public class Autor : BaseEntity
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Вы не ввели имя.")]
        [System.ComponentModel.DisplayName("Имя")]
        public string Name { get; set; }
        
       
        
        [Range(7, 120, ErrorMessage = "Возраст должен быть в пределах от 7 до 100.")]
        [Required(ErrorMessage = "Вы не ввели возраст.")]
        [System.ComponentModel.DisplayName("Возраст")]
        public int? Age { get; set; }
        [System.ComponentModel.DisplayName("Электронная почта")]
        [Required(ErrorMessage = "Вы не ввели почту.")]

        public string Email { get; set; }

        [NotMapped]
        public string ReturnUrl { get; set; }
        [NotMapped]
        public bool InBook { get; set; } = false;
        [NotMapped]
        [System.ComponentModel.DisplayName("Книги")]
        public List<Book> BooksforAuthor { get; set; }

        
    }
}
