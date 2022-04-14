using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Areas.admin.Controllers
{
    [Area("admin")]
    public class FreshController : Controller
    {
        private readonly IFreshServices _freshServices;
        private readonly IWebHostEnvironment _environment;

        public FreshController(IFreshServices freshServices, IWebHostEnvironment environment)
        {
            _freshServices = freshServices;
            _environment = environment;
        }

        // GET: FreshController
        public IActionResult Index()
        {
            var fresh = _freshServices.GetAll();
            return View(fresh);
        }

        // GET: FreshController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: FreshController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FreshController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Fresh fresh)
        {
            try
            {
                _freshServices.Create(fresh);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FreshController/Edit/5
        public IActionResult Edit(int id)
        {
            var fresh = _freshServices.GetById(id);
            return View(fresh);
        }

        // POST: FreshController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Fresh fresh)
        {
            try
            {
                _freshServices.Edit(fresh);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FreshController/Delete/5
        public IActionResult Delete(int id)
        {
            var fresh = _freshServices.GetById(id);
            return View(fresh);
        }

        // POST: FreshController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Fresh fresh)
        {
            try
            {
                _freshServices.Delete(fresh);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
