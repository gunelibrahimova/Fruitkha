using Fruitkha.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;
        private readonly INewServices _newServices;
        private readonly IFreshServices _freshServices;
        private readonly IFreeServices _freeServices;
        private readonly IDealServices _dealServices;
        private readonly IOwnerServices _ownerServices;
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly ISinceServices _sinceServices;
        private readonly ISaleServices _saleServices;

        public AboutController(ILogger<AboutController> logger, INewServices newServices, IFreshServices freshServices, IFreeServices freeServices, IDealServices dealServices, IOwnerServices ownerServices, IProductServices productServices, ICategoryServices categoryServices, ISinceServices sinceServices, ISaleServices saleServices)
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
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                News = _newServices.GetAll(),
                Freshs = _freshServices.GetFreshById(7),
                Frees = _freeServices.GetAll(),
                Deals = _dealServices.GetAll(),
                Owners = _ownerServices.GetAll(),
                Products = _productServices.GetAll(),
                Categories = _categoryServices.GetAll(),
                Since = _sinceServices.GetAll(),
                Sales = _saleServices.GetAll(),
            };
            return View(vm);
        }
    }
}
