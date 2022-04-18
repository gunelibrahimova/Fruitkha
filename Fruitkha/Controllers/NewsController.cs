using Core.Helper;
using Fruitkha.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Controllers
{
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> _logger;
        private readonly INewServices _newServices;
        private readonly IFreshServices _freshServices;

        public NewsController(ILogger<NewsController> logger, INewServices newServices, IFreshServices freshServices, IFreeServices freeServices, IDealServices dealServices, IOwnerServices ownerServices, IProductServices productServices, ICategoryServices categoryServices, ISinceServices sinceServices, ISaleServices saleServices)
        {
            _logger = logger;
            _newServices = newServices;
            _freshServices = freshServices;

        }

        public IActionResult Index(int? recordSize = 6, int? pageNo = 1)
        {
            HomeVM vm = new()
            {
                Freshs = _freshServices.GetFreshById(9),
                News = _newServices.GetAll(pageNo, recordSize.Value),

            };
            vm.Pager = new Pager(_newServices.GetAllCount(), pageNo, 2, 3);
            return View(vm);
        }
    }
}
