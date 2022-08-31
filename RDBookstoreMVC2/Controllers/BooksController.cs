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
        private readonly BooksDbContext _context;
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
                var responseTask = Client.GetAsync("api/Books");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Books>>();
                    readTask.Wait();
                    lsBooks = readTask.Result;
                }
            }
            catch (Exception ex)
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

            var books = GetBooks(id.Value);
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
        public async Task<IActionResult> Create([Bind("Id,Title,Author,Price,Overview,Summary,Publisher,Pages,Length,Width,Height,Genre,PublicationDate,ImageUrl,ISBN")] Books books)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responseTask = Client.PostAsJsonAsync("api/Books", books);
                    responseTask.Wait();
                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index", "Customer");
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

            var books = GetBooks(id.Value);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,Price,Overview,Summary,Publisher,Pages,Length,Width,Height,Genre,PublicationDate,ImageUrl,ISBN")] Books books)
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
                    var responseTask = Client.PutAsJsonAsync($"api/Books/{id}", books);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                  
                }
                catch (Exception ex)
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

            var books = GetBooks(id.Value);
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

                var responseTask = Client.DeleteAsync($"api/Books/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
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

        private bool BooksExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }

        private Books GetBooks(int id)
        {
            Books books = null;

            var responseTask = Client.GetAsync($"api/Books/{id}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Books>();
                readTask.Wait();
                books = readTask.Result;
            }
            else
            {
                return null;
            }
            return books;
        }
    }
}
