

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBook.Models
{
    public class Purchase : BaseEntity
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int? BookId { get; set; }

        [Display(Name = "Количество")]
        public int Ammount { get; set; } = 1;
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Цена")]
        public decimal? Price { get; set; }

        public Purchase() { }

        public Purchase(Book book)
        {
            Book = book;
            BookId = book.Id;
            Price = Book.Price;
        }
    }

}
