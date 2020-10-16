using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcBook.Data;
using MvcBook.Models;

namespace MvcBook.Controllers
{
    public class PurchasesHistoryService
    {

        private readonly MvcBookContext _context;

        public PurchasesHistoryService(MvcBookContext context)
        {
            _context = context;
        }

        public async Task<List<PurchasesHistory>> GetAll()
        {
            return await _context.PurchasesHistory
                .Include(x=>x.Book.Autor)
                .OrderBy(x=>x.Book.Title)
                .ToListAsync();
        }

        public async Task<PurchasesHistory> GetPurchaseHistory(int? id)
        {
            var purchasehistory = _context.PurchasesHistory
                .Include(x=>x.Book)
                .ThenInclude(x=>x.Autor)
                .FirstOrDefaultAsync(m => m.Id == id);
            return await purchasehistory;
        }       

        public async Task Delete(int id)
        {
            var purchasehistory = await _context.PurchasesHistory.FindAsync(id);
            _context.PurchasesHistory.Remove(purchasehistory);
            await _context.SaveChangesAsync();
        }

        public async Task Delete()
        {
            var purchasehistory = await _context.PurchasesHistory.ToListAsync();
            _context.PurchasesHistory.RemoveRange(purchasehistory);
            await _context.SaveChangesAsync();
        }

        public async Task Create(PurchasesHistory purchasehistory)
        {
            _context.Add(purchasehistory);
            await _context.SaveChangesAsync();
        }
        
    }
}
