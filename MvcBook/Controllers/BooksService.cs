using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcBook.Data;
using MvcBook.Models;

namespace MvcBook.Controllers
{
    public class BooksService
    {

        private readonly MvcBookContext _context;

        public BooksService(MvcBookContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _context.Book
                .Include(x => x.Autor)
                .OrderBy(x=>x.Title)
                .ToListAsync();
        }
            

        public async Task<Book> GetBook(int? id)
        {
            var book = _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            return await book;
        }

        public async Task Update(Book book)
        {
            _context.Update(book);
            
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task Create(Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
        }
    }
}
