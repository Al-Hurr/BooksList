using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcBook.Data;
using MvcBook.Models;

namespace MvcBook.Controllers
{
    public class PurchasesService
    {

        private readonly MvcBookContext _context;

        public PurchasesService(MvcBookContext context)
        {
            _context = context;
        }

        public async Task<List<Purchase>> GetAll(BuyStatus buyStatus = BuyStatus.AwaitingPayment)
        {
            return await _context.Purchases
                .Include(x=>x.Book.Autor)
                .Where(x => x.BuyStatus == buyStatus)
                .OrderBy(x=>x.Book.Title)
                .ToListAsync();
        }

        public async Task<int> GetCount()
        {
            return await _context.Purchases
                .Include(x => x.Book.Autor)
                .Where(x => x.BuyStatus == BuyStatus.AwaitingPayment)
                .SumAsync(x => x.Ammount);
        }
            

        public async Task<Purchase> GetPurchase(int? id)
        {
            var purchase = _context.Purchases
                .Include(x=>x.Book)
                .ThenInclude(x=>x.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            return await purchase;
        }

       

        public async Task Delete(int id)
        {
            var purchase = await _context.Purchases.FindAsync(id);
            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(BuyStatus buyStatus)
        {
            var purchases = await GetAll(buyStatus);
            _context.Purchases.RemoveRange(purchases);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Purchase purchase)
        {
            _context.Add(purchase);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Purchase purchase)
        {
            _context.Update(purchase);

            await _context.SaveChangesAsync();
        }
    }
}
