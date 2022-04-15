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
        private readonly ICommentServices _commentManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public NewController(INewServices newServices, UserManager<K205User> userManager, IHttpContextAccessor httpContextAccessor, ICommentServices commentManager)
        {
            _newServices = newServices;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _commentManager = commentManager;
        }

        public IActionResult Index(int? id)
        {
            var news = _newServices.GetById(id);
            NewVM vm = new()
            {
                NewSingle = news,
                User = _userManager.FindByIdAsync(news.K205UserId).Result,
                Comments = _commentManager.GetNewComment(news.Id),
                News = _newServices.GetAll()
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddNewComment(Comment comment, int newId)
        {
            comment.NewId = newId;

            _commentManager.AddComment(comment);
            return RedirectToAction("Index", "New", new { id = newId });
        }
    }
}
