using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class GroceryItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroceryItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GroceryItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.GroceryItem.ToListAsync());
        }

        public async Task<IActionResult> Search()
        {
            return View();
        }

        public async Task<IActionResult> SearchResults(String SearchKey)
        {
            return View("Index",await _context.GroceryItem.Where(x => x.Name.Contains(SearchKey)).ToListAsync());
        }

        // GET: GroceryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryItem = await _context.GroceryItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groceryItem == null)
            {
                return NotFound();
            }

            return View(groceryItem);
        }

        // GET: GroceryItems/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroceryItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] GroceryItem groceryItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groceryItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groceryItem);
        }

        // GET: GroceryItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryItem = await _context.GroceryItem.FindAsync(id);
            if (groceryItem == null)
            {
                return NotFound();
            }
            return View(groceryItem);
        }

        // POST: GroceryItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] GroceryItem groceryItem)
        {
            if (id != groceryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groceryItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroceryItemExists(groceryItem.Id))
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
            return View(groceryItem);
        }

        // GET: GroceryItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groceryItem = await _context.GroceryItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groceryItem == null)
            {
                return NotFound();
            }

            return View(groceryItem);
        }

        // POST: GroceryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groceryItem = await _context.GroceryItem.FindAsync(id);
            _context.GroceryItem.Remove(groceryItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroceryItemExists(int id)
        {
            return _context.GroceryItem.Any(e => e.Id == id);
        }
    }
}
