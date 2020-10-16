

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MvcBook.Models
{
    public class PurchaseHistoryViewModel
    {
        public List<PurchasesHistory> PurchasesHistory { get; set; }

        public decimal? Sum { get; set; } = 0;

        public PurchaseHistoryViewModel(List<PurchasesHistory> purchaseshistory)
        {
            PurchasesHistory = purchaseshistory;
            Pracesum(purchaseshistory);
        }

        private void Pracesum(List<PurchasesHistory> purchaseshistory)
        {
           
            foreach(var item in purchaseshistory)
            {
                Sum += item.Price;
            }

        }
    }
}
