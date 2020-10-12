using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MvcBook.Data;
using MvcBook.Models;

namespace MvcBook.Controllers
{
    public class AuthorsController : Controller
    {
        
        private BooksService booksService;
        private AuthorsService authorsService;
        public AuthorsController(BooksService booksService, AuthorsService authorsService)
        {
            this.booksService = booksService;
            this.authorsService = authorsService;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {

            var authors = await authorsService.GetAll();

            var autorsVM = new AuthorViewModel
            {
                Authors =  authors
            };

            return View(autorsVM);
          
        }

        //[HttpPost]
        //public string Index(string searchString, bool notused)
        //{
        //    return "From [HttpPost]Index: filter on " + searchString;
        //}

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id, string returnURL)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await authorsService.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }

            author.ReturnUrl = returnURL;
            
            var books = await booksService.GetAll();

            books = books.Where(s => s.Autor.Id==author.Id).ToList();

            author.BooksforAuthor = books.ToList();
            return View(author);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Email")] Autor author)
        {
            if (ModelState.IsValid)
            {
                authorsService.Create(author);
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autor = await authorsService.GetAuthor(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Email")] Autor author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    authorsService.Update(author);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await BookExists(author.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = await authorsService.GetAuthor(id);
            if (author == null)
            {
                return NotFound();
            }
            
            var books = await booksService.GetAll();

            var book = books
                .FirstOrDefault(x => x.Autor.Name == author.Name);

            if (book != null)
            {
                author.InBook = true;
            }

            return View(author);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           authorsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BookExists(int id)
        {
            var authors = await authorsService.GetAll();

            return authors
                .Any(x=>x.Id==id);
        }
    }
}
