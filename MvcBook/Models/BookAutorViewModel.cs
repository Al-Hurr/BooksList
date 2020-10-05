

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

        public string bookDateTime { get; set; }
        public string SearchString { get; set; }
    }
}
