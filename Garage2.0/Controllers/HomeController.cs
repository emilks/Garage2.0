using Garage2._0.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Garage2._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private object db;
        private object _context;

        public object context { get; private set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //automatic time alg
        //public IActionResult Index()
        //{
        //    Statistics stats = new Statistics();

        //    var dates = context.Select(v => v.Date);
        //    DateTime now = DateTime.Now;

        //    foreach (var d in dates)
        //    {
        //        stats.Time += now - d;
        //    }
        //    return View();
        //}

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