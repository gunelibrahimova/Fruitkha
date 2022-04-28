using Fruitkha.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Controllers
{
    public class CheckController : Controller
    {
        private readonly IFreshServices _freshServices;
        private readonly ICheckServices _checkServices;
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public CheckController(IFreshServices freshServices, ICheckServices checkServices, IProductServices productServices, ICategoryServices categoryServices)
        {
            _freshServices = freshServices;
            _checkServices = checkServices;
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                Freshs = _freshServices.GetFreshById(11),
                Check = _checkServices.GetAll(),
                Products = _productServices.GetAll(),
                Categories = _categoryServices.GetAll(),

            };
            return View(vm);
        }
    }
}
