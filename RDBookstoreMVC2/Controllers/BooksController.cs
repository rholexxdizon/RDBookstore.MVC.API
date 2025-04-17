using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RDBookstoreMVC2.Models;

namespace RDBookstoreMVC2.Controllers
{
    public class BooksController : Controller
    {
        private readonly IConfiguration _config;
        private readonly string _apiUrl;
        public static HttpClient Client = null;

        public BooksController(IConfiguration config)
        {
            _config = config;
            _apiUrl = _config.GetValue<string>("WebApiUrl");

            if (Client == null)
            {
                Client = new HttpClient();
                Client.Timeout = TimeSpan.FromSeconds(_config.GetValue<int>("WebApiTimeOut"));
                Client.BaseAddress = new Uri(_apiUrl);
            }
        }

        // GET: Books
        
        public async Task<IActionResult> Index()
        {
            IList<Books> lsBooks = null;
            try
            {
                var responseTask = await Client.GetAsync("api/Books");

                if (responseTask.IsSuccessStatusCode)
                {
                    lsBooks = await responseTask.Content.ReadAsAsync<IList<Books>>();
                }
            }
            catch (Exception)
            {
                return BadRequest("Application Error");
            }

            return View(lsBooks);

        }

        public async Task<IActionResult> BooksList()
        {
            IList<Books> lsBooks = null;
            try
            {
                var responseTask = await Client.GetAsync("api/Books"); 

                if (responseTask.IsSuccessStatusCode)
                {
                    lsBooks = await responseTask.Content.ReadAsAsync<IList<Books>>();
                
                }
            }
            catch (Exception)
            {
                return BadRequest("Application Error");
            }

            return View(lsBooks);

        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await GetBooks(id.Value);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
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
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Price,Overview,Summary,Publisher,Pages,Length,Width,Height,Genre,PublicationDate,ImageUrl,ISBN,SalesRank")] Books books)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responseTask = await Client.PostAsJsonAsync("api/Books", books);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                return BadRequest();
            }
            return View(books);
        }

        //GET: BookInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await GetBooks(id.Value);
            if (books == null)
            {
                return NotFound();
            }
            return View(books);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Price,Overview,Summary,Publisher,Pages,Length,Width,Height,Genre,PublicationDate,ImageUrl,ISBN,SalesRank")] Books books)
        {
            if (id != books.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //HTTP GET
                    var responseTask = await Client.PutAsJsonAsync($"api/Books/{id}", books);
                    
                    if (responseTask.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                  
                }
                catch (Exception)
                {
                    return BadRequest("Application Error");
                }
            }
            return View(books);
        }

        // GET: BookInfoDatabases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await GetBooks(id.Value);
            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }


        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                //HTTP GET

                var responseTask = await Client.DeleteAsync($"api/Books/{id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            catch (Exception)
            {
                return BadRequest("Application Error");
            }
            return RedirectToAction(nameof(Delete), id);

        }

        private async Task <Books> GetBooks(int id)
        {
            Books books = null;

            var responseTask = await Client.GetAsync($"api/Books/{id}");
            if (responseTask.IsSuccessStatusCode)
            {
                books = await responseTask.Content.ReadAsAsync<Books>();
            }
            else
            {
                return null;
            }
            return books;
        }
    }
}
