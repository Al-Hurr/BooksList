﻿

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcBook.Models
{
    public enum BuyStatus
    {
        AwaitingPayment,
        Bought,
        Refunded
    }
    public class Purchase : BaseEntity
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int? BookId { get; set; }

        [Display(Name = "Количество")]
        public int Ammount { get; set; } = 1;
        [Column(TypeName = "decimal(18, 2)")]
        [Display(Name = "Сумма")]
        public decimal? Price { get; set; }

        public BuyStatus BuyStatus { get; set; }


        [Display(Name = "Дата покупки")] //Желательно давать названия таким способом.
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BuyDate { get; set; } = DateTime.Now;

        [NotMapped]
        public string Time { get { return BuyDate.ToShortTimeString(); } }

        public Purchase() { }

        public Purchase(Book book)
        {
            Book = book;
            BookId = book.Id;
            Price = Book.Price;
        }
    }

}
