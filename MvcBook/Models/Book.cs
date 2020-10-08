using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBook.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [System.ComponentModel.DisplayName("Название")]
        public string Title { get; set; }

        [Display(Name = "Дата выпуска")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        // [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Автор")]
        public Autor Autor { get; set; }
        public int? AutorId { get; set; }
        
       
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [NotMapped]
        public SelectList Authors { get; set; }
    }
}
