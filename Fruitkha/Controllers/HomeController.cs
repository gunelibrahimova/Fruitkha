using Fruitkha.Models;
using Fruitkha.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using System.Diagnostics;

namespace Fruitkha.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewServices _newServices;

        public HomeController(ILogger<HomeController> logger, INewServices newServices)
        {
            _logger = logger;
            _newServices = newServices;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                News = _newServices.GetAll(),
            };
            return View(vm);
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