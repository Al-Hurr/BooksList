using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcBook.Data;
using MvcBook.Models;

namespace MvcBook.Controllers
{
    public class BooksController : Controller
    {
        

        private BooksService booksService;
        private AuthorsService authorsService;
        public BooksController(BooksService booksService, AuthorsService authorsService)
        {
            this.booksService = booksService;
            this.authorsService = authorsService;
        }

        
        // GET: Books
        public async Task<IActionResult> Index(int? bookAutor, string searchString, int? bookDateTimeto, int? bookDateTimefrom)
        {
            var autorQuery = await authorsService.GetAll();

            var books = await booksService.GetAll();

            var dates = books
                .OrderBy(x => x.ReleaseDate)
                .Select(x => x.ReleaseDate.ToString("d"));

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString)).ToList();
            }


            if (bookDateTimeto.HasValue && bookDateTimefrom.HasValue)
            {        
                books = books.Where(x => x.ReleaseDate.Year >= bookDateTimeto && x.ReleaseDate.Year <= bookDateTimefrom).ToList();
            }
            
           

            if (bookAutor.HasValue)
            {
                books = books.Where(x => x.Autor.Id == bookAutor).ToList();
            }

            var bookAutorVM = new BookAutorViewModel
            {
                Autors = new SelectList(autorQuery, nameof(Autor.Id), nameof(Autor.Name)),
                Dates = new SelectList(dates.Distinct()),
                Books = books 
            };

            return View(bookAutorVM);

            
        }

        //[HttpPost]
        //public string Index(string searchString, bool notused)
        //{
        //    return "From [HttpPost]Index: filter on " + searchString;
        //}

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await booksService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            var autorQuery = await authorsService.GetAll();

            return View(new Book
            {
                Authors = new SelectList(autorQuery, nameof(Autor.Id), nameof(Autor.Name))
            });
        }
        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,ReleaseDate,AutorId,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                await booksService.Create(book);
                return RedirectToAction(nameof(Index));
            }

            var autorQuery = await authorsService.GetAll();

            book.Authors = new SelectList(autorQuery, nameof(Autor.Id), nameof(Autor.Name));

            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await booksService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            var autorQuery = await authorsService.GetAll();

            book.Authors = new SelectList(autorQuery, nameof(Autor.Id), nameof(Autor.Name));

            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,AutorId,Price")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await booksService.Update(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await BookExists(book.Id))
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

            var autorQuery = await authorsService.GetAll();

            book.Authors = new SelectList(autorQuery, nameof(Autor.Id), nameof(Autor.Name));

            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await booksService.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await booksService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> BookExists(int id)
        {
            var books = await booksService.GetAll();

            return books.Any(x => x.Id == id);

        }
    }
}
