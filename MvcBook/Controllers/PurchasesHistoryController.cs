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
    public class PurchasesHistoryController : Controller
    {
        

        private BooksService booksService;
        private AuthorsService authorsService;
        private PurchasesService purchasesService;
        private PurchasesHistoryService purchasesHistoryService;
        public PurchasesHistoryController(BooksService booksService, AuthorsService authorsService, 
            PurchasesService purchasesService, PurchasesHistoryService purchaseshistoryservice)
        {
            this.booksService = booksService;
            this.authorsService = authorsService;
            this.purchasesService = purchasesService;
            this.purchasesHistoryService = purchaseshistoryservice;
        }

        
        // GET: Books
        public async Task<IActionResult> Index()
        {
            var purchaseshistory = await purchasesService.GetAll(BuyStatus.Bought);

            var purchasesVM = new PurchaseViewModel(purchaseshistory);
            
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
        public async Task<IActionResult> Create([Bind("BookId,Price,Ammount")] PurchasesHistory purchaseshistory)
        {

            if (ModelState.IsValid)
            {
                await purchasesHistoryService.Create(purchaseshistory);
                return RedirectToAction(nameof(Index));
            }

            return View(purchaseshistory);
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
        [HttpPost]
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
        public async Task<IActionResult> Delete()
        {
            await purchasesService.Delete(BuyStatus.Bought);
            return RedirectToAction(nameof(Index));
        }
    }
}
