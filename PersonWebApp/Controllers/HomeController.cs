using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PersonWebApp.Models;
using Services.Contract;

namespace PersonWebApp.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)//ILogger<HomeController> logger, )
        {
            //  _logger = logger;
            _personService = personService;
        }

        public IActionResult Index()
        {
            var persons = _personService.GetList();
            return View(persons);
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
