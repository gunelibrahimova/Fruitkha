using Fruitkha.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Controllers
{
    public class CheckController : Controller
    {
        private readonly IFreshServices _freshServices;

        public CheckController(IFreshServices freshServices)
        {
            _freshServices = freshServices;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                Freshs = _freshServices.GetFreshById(11),

            };
            return View(vm);
        }
    }
}
