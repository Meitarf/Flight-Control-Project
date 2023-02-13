using FlightsClient.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;



namespace FlightsClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5114") };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await client.GetFromJsonAsync<IEnumerable<LoggerDto>>("api/Loggers");
            logs = logs.OrderByDescending(l => l.Id).Take(15);
            ViewData["Logs"] = logs;
            return View(logs);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}