using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using ZomatoApp.BAL;
using ZomatoApp.Dal;
using ZomatoApp.Models;


namespace ZomatoApp.Controllers
{
    [CheackAccess]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        Home_DAL home_DAL = new Home_DAL();

        public IActionResult Index()
        {
            DataTable dt = home_DAL.dbo_PR_RecordCount();

            return View(dt);
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