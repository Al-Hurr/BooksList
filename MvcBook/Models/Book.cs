using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBook.Models
{
    public class Book : BaseEntity
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required(ErrorMessage = "Вы не ввели имя.")]
        [System.ComponentModel.DisplayName("Название")]
        public string Title { get; set; }
        
        [Display(Name = "Дата выпуска")] //Желательно давать названия таким способом.
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;
        // [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
       
        public Autor Autor { get; set; }
        [Display(Name = "Автор")]
        public int? AutorId { get; set; }
        
        [Range(1, 1000000, ErrorMessage = "Цена должна быть в пределах от 1 до 1 000 000 руб.")]
        [Required(ErrorMessage = "Вы не ввели цену.")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Цена")]
        public decimal? Price { get; set; }

        [NotMapped]
        public SelectList Authors { get; set; }

       
    }
}
