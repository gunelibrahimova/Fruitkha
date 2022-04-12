using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Areas.admin.Controllers
{
    [Area("admin")]
    public class NewController : Controller
    {
        private readonly INewServices _newServices;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<K205User> _userManager;

        public NewController(INewServices newServices, UserManager<K205User> userManager, IWebHostEnvironment environment)
        {
            _newServices = newServices;
            _userManager = userManager;
            _environment = environment;
        }

        // GET: NewController
        public IActionResult Index()
        {
           var news = _newServices.GetAll();
            return View(news);
        }

        // GET: NewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(New news, IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }
            try
            {
                    var userId = _userManager.GetUserId(HttpContext.User);
                    news.PhotoURL = path;
                    news.K205UserId = userId;
                
                _newServices.Create(news);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
