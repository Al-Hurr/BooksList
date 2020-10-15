using Microsoft.EntityFrameworkCore;
using MvcBook.Models;



namespace MvcBook.Data
{
    public class MvcBookContext:DbContext
    {
        public MvcBookContext(DbContextOptions<MvcBookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Autor> Autors { get; set; }

        public DbSet<Purchase> Purchases { get; set; }





        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=booksdb;Username=postgres;Password=password");
        //}
    }

}
