using Entities;
using Fruitkha.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IFreshServices _freshServices;
        private readonly IContectServices _contectServices;


        public ContactController(ILogger<ContactController> logger, IFreshServices freshServices, IContectServices contectServices)
        {
            _logger = logger;
            _freshServices = freshServices;
            _contectServices = contectServices;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                Freshs = _freshServices.GetFreshById(8),
                
            };
            return View(vm);
        }


        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _contectServices.Post(contact);
            return RedirectToAction("Index");
        }
    }
}
