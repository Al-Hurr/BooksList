

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace MvcBook.Models
{
    public class AuthorViewModel
    {
        public List<Autor> Authors { get; set; }
        
        public List<string> AuthorsStr { get; set; }

        public SelectList Ages { get; set; }

        public string searchauthor { get; set; }

        public int searchage { get; set; }
    }
}
