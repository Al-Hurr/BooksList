

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcBook.Data;
using System;
using System.Linq;

namespace MvcBook.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcBookContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcBookContext>>()))
            {
                // Look for any books.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Буря мечей",
                        ReleaseDate = DateTime.Parse("2018-2-12"),
                        Autor = "Джордж Мартин",
                        Price = 7.99M
                    },

                    new Book
                    {
                        Title = "Властелин Колец. Возвращение короля",
                        ReleaseDate = DateTime.Parse("1990-3-13"),
                        Autor = "Джон Р. Р. Толкин",
                        Price = 8.99M
                    },

                    new Book
                    {
                        Title = "Крестный отец",
                        ReleaseDate = DateTime.Parse("2009-2-23"),
                        Autor = "Марио Пьюзо",
                        Price = 9.99M
                    },

                    new Book
                    {
                        Title = "Вторая жизнь Уве",
                        ReleaseDate = DateTime.Parse("1999-4-15"),
                        Autor = "Фредрик Бакман",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
