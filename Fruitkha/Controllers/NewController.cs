using Core.Helper;
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
        private readonly IFreshServices _freshServices;


        public NewController(INewServices newServices, UserManager<K205User> userManager, IHttpContextAccessor httpContextAccessor, ICommentServices commentManager, IFreshServices freshServices)
        {
            _newServices = newServices;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _commentManager = commentManager;
            _freshServices = freshServices;
        }

        public IActionResult Index(int? id)
        {
            var news = _newServices.GetById(id);
            var comments = _commentManager.GetNewComment(news.Id);

            ViewBag.Comments = comments.Count;
            NewVM vm = new()
            {
                NewSingle = news,
                User = _userManager.FindByIdAsync(news.K205UserId).Result,
                Comments = _commentManager.GetNewComment(news.Id),
                FreshNews = _freshServices.GetFreshById(6),
                News = _newServices.GetAll(),
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


