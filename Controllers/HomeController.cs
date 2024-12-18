using Frond_end.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Frond_end.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Overview()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult Data()
        {
            return View();
        }

        public IActionResult Issues()
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