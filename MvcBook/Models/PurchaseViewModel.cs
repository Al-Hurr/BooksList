

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MvcBook.Models
{
    public class PurchaseViewModel
    {
        public List<Purchase> Purchases { get; set; }

        public decimal? Sum { get; set; } = 0;

        public PurchaseViewModel(List<Purchase> purchases)
        {
            Purchases = purchases;
            Pracesum(purchases);
        }

        private void Pracesum(List<Purchase> purchases)
        {
           
            foreach(var item in purchases)
            {
                Sum += item.Price;
            }

        }
    }
}
