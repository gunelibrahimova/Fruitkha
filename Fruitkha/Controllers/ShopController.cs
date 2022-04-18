using Core.Helper;
using Fruitkha.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Controllers
{
    public class ShopController : Controller
    {
        private readonly IFreshServices _freshServices;
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;

        public ShopController(IFreshServices freshServices, IProductServices productServices, ICategoryServices categoryServices)
        {
            _freshServices = freshServices;
            _productServices = productServices;
            _categoryServices = categoryServices;
        }

        public IActionResult Index(int? recordSize = 6, int? pageNo = 1)
        {
            HomeVM vm = new()
            {
                Freshs = _freshServices.GetFreshById(10),
                Products = _productServices.GetAll(pageNo, recordSize.Value),
                Categories = _categoryServices.GetAll(),
                 

            };
            vm.Pager = new Pager(_productServices.GetAllCount(), pageNo, 2, 3);
            return View(vm);
        }
    }
}
