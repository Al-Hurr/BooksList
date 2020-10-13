

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MvcBook.Models
{
    public class BookAutorViewModel
    {
        public List<Book> Books { get; set; }
        public SelectList Autors { get; set; }
        public string BookAutor { get; set; }
        public SelectList Dates { get; set; }

        public int bookDateTimeto { get; set; } = 1990;
        public int bookDateTimefrom { get; set; } = DateTime.Today.Year;
        public string SearchString { get; set; }
    }
}
