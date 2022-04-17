using Fruitkha.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IFreshServices _freshServices;

        public ProductController(IProductServices productServices, ICategoryServices categoryServices, IFreshServices freshServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _freshServices = freshServices;
        }

        public IActionResult Index(int? id)
        {
            var products = _productServices.GetById(id.Value);

            ProductVM vm = new()
            {
                Productsingle = products,
                Categories = _categoryServices.GetAll(),
                Products = _productServices.GetAll(),
                FreshProducts = _freshServices.GetFreshById(5)

            };
            return View(vm);
        }
    }
}
