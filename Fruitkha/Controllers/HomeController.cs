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
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly ISinceServices _sinceServices;
       private readonly ISaleServices _saleServices;
        private readonly ICheckServices _checkServices;

        public HomeController(ILogger<HomeController> logger, INewServices newServices, IFreshServices freshServices, IFreeServices freeServices, IDealServices dealServices, IOwnerServices ownerServices, IProductServices productServices, ICategoryServices categoryServices, ISinceServices sinceServices, ISaleServices saleServices, ICheckServices checkServices)
        {
            _logger = logger;
            _newServices = newServices;
            _freshServices = freshServices;
            _freeServices = freeServices;
            _dealServices = dealServices;
            _ownerServices = ownerServices;
            _productServices = productServices;
            _categoryServices = categoryServices;
            _sinceServices = sinceServices;
            _saleServices = saleServices;
            _checkServices = checkServices;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                
                News = _newServices.GetNewAll(),
                Freshs = _freshServices.GetFreshAll(),
                Frees = _freeServices.GetFreeAll(),
                Deals = _dealServices.GetAll(),
                Owners = _ownerServices.GetAll(),
                Products = _productServices.GetAll(),
                Categories = _categoryServices.GetAll(),
                Since = _sinceServices.GetAll(),
                Sales = _saleServices.GetAll(),
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