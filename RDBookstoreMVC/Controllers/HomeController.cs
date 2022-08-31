using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RDBookstoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RDBookstoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly string _apiUrl;
        public static HttpClient Client = null;

        public HomeController(IConfiguration config, ILogger<HomeController> logger)
        {
            _logger = logger;
            _config = config;
            _apiUrl = _config.GetValue<string>("WebApiUrl");
            if (Client == null)
            {
                Client = new HttpClient();
                Client.Timeout = TimeSpan.FromSeconds(_config.GetValue<int>("WebApiTimeOut"));
                Client.BaseAddress = new Uri(_apiUrl);
            }
        }

        public IActionResult Index()
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
