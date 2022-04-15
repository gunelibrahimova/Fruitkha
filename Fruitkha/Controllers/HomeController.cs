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
        private readonly IFreshServices _freshServices;
        private readonly IFreeServices _freeServices;
        private readonly IDealServices _dealServices;
        private readonly IOwnerServices _ownerServices;

        public HomeController(ILogger<HomeController> logger, INewServices newServices, IFreshServices freshServices, IFreeServices freeServices, IDealServices dealServices, IOwnerServices ownerServices)
        {
            _logger = logger;
            _newServices = newServices;
            _freshServices = freshServices;
            _freeServices = freeServices;
            _dealServices = dealServices;
            _ownerServices = ownerServices;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                News = _newServices.GetAll(),
                Freshs = _freshServices.GetAll(),
                Frees = _freeServices.GetAll(),
                Deals = _dealServices.GetAll(),
                Owners = _ownerServices.GetAll(),
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