using Microsoft.AspNetCore.Mvc;
using MyGym.DataAccess.DbContexts;
using MyGym.DataAccess.Models;
using System.Diagnostics;


namespace MyGym.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GYMDbcontext _dbcontext;

        public HomeController(ILogger<HomeController> logger, GYMDbcontext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
          
            var result = _dbcontext.Plans.ToList();
            return View(result);
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
