using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fruitkha.Areas.admin.Controllers
{
    [Area("admin")]
    public class SinceController : Controller
    {
        // GET: SinceController
        public IActionResult Index()
        {
            return View();
        }

        // GET: SinceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SinceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SinceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: SinceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SinceController/Edit/5
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

        // GET: SinceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SinceController/Delete/5
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
