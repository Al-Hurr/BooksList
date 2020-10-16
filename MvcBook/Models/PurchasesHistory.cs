

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBook.Models
{
    public class PurchasesHistory : BaseEntity
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int? BookId { get; set; }

        [Display(Name = "Количество")]
        public int Ammount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Цена")]
        public decimal? Price { get; set; }

        [Display(Name = "Дата покупки")] //Желательно давать названия таким способом.
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BuyDate { get; set; } = DateTime.Today;

        public PurchasesHistory() { }

        public PurchasesHistory(Book book)
        {
            Book = book;
            BookId = book.Id;
            Price = Book.Price;
        }
    }

}
