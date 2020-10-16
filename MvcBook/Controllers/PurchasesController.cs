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
    public class PurchasesController : Controller
    {
        

        private BooksService booksService;
        private AuthorsService authorsService;
        private PurchasesService purchasesService;
        public PurchasesController(BooksService booksService, AuthorsService authorsService, PurchasesService purchasesService)
        {
            this.booksService = booksService;
            this.authorsService = authorsService;
            this.purchasesService = purchasesService;
        }

        
        // GET: Books
        public async Task<IActionResult> Index()
        {
            var purchases = await purchasesService.GetAll();


            var purchasesVM = new PurchaseViewModel(purchases);
            

            return View(purchasesVM);
        }

        

        // GET: Books/Create
        public async Task<IActionResult> Create(int? id)
        {
            var book = await booksService.GetBook(id);

            return View(new Purchase(book)); 
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,Price,Ammount")] Purchase purchase)
        {

            if (ModelState.IsValid)
            {
                await purchasesService.Create(purchase);
                return RedirectToAction(nameof(Index));
            }

            return View(purchase);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await purchasesService.GetPurchase(id);
            if (purchase == null)
            {
                return NotFound();
            }
            

            return View(purchase);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookId,Price,Ammount")] Purchase purchase)
        {
            if (id != purchase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await purchasesService.Update(purchase);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PurchaseExists(purchase.Id))
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

            
            return View(purchase);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchase = await purchasesService.GetPurchase(id);
            if (purchase == null)
            {
                return NotFound();
            }

            return View(purchase);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await purchasesService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PurchaseExists(int id)
        {
            var purchase = await purchasesService.GetAll();

            return purchase.Any(x => x.Id == id);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy()
        {
            await purchasesService.Delete();
            return RedirectToAction(nameof(Index));
        }
    }
}
