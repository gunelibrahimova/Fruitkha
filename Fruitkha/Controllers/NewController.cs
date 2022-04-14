using Entities;
using Fruitkha.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Controllers
{
    public class NewController : Controller
    {
        private readonly INewServices _newServices;
        private readonly UserManager<K205User> _userManager;
        //private readonly ICommentServices _commentManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NewController(INewServices newServices, UserManager<K205User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _newServices = newServices;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index(int? id)
        {
            var news = _newServices.GetById(id);
            NewVM vm = new()
            {
                NewSingle = news,
                User = _userManager.FindByIdAsync(news.K205UserId).Result,
                News = _newServices.GetAll()
            };
            return View(vm);
        }
    }
}
