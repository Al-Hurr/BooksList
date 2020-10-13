

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcBook.Data;
using MvcBook.Models;

namespace MvcBook.Controllers
{
    public class AuthorsService
    {
        private readonly MvcBookContext _context;

        public AuthorsService(MvcBookContext context)
        {
            _context = context;
        }

        public async Task<List<Autor>> GetAll()
        {
            return await _context.Autors
                .OrderBy(x=>x.Name)
                .ToListAsync();
        }

        public async Task<Autor> GetAuthor(int? id)
        {
            var author = _context.Autors
                .FirstOrDefaultAsync(m => m.Id == id);
            return await author;
        }

        public async Task Create(Autor author)
        {
            _context.Add(author);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Autor author)
        {
            _context.Update(author);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var author = await _context.Autors.FindAsync(id);
            _context.Autors.Remove(author);
            await _context.SaveChangesAsync();
        }

    }
}
