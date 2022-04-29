using Entities;
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



        public IActionResult Index(int? id)
        {
            var product = _productServices.GetById(id.Value);

            HomeVM vm = new()
            {
                Productsingle = product,
                Freshs = _freshServices.GetFreshById(11),
                
                Products = _productServices.GetAll(),
                Categories = _categoryServices.GetAll(),

            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(Checkout checkout)
        {
            _checkServices.Post(checkout);
            return RedirectToAction(nameof(Index));
        }
    }
}
