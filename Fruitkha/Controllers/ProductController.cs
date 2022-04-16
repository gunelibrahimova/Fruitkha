using Fruitkha.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public ProductController(IProductServices productServices, ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        public IActionResult Index(int? id)
        {
            var products = _productServices.GetById(id.Value);

            ProductVM vm = new()
            {
                Productsingle = products,
                Categories = _categoryServices.GetAll(),
                Products = _productServices.GetAll()


            };
            return View(vm);
        }
    }
}
