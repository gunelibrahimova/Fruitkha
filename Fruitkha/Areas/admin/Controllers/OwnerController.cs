using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Areas.admin.Controllers
{
    [Area("admin")]
    public class OwnerController : Controller
    {
        private readonly IOwnerServices _ownerServices;
        private readonly IWebHostEnvironment _environment;

        public OwnerController(IWebHostEnvironment environment, IOwnerServices ownerServices)
        {
            _environment = environment;
            _ownerServices = ownerServices;
        }

       


        // GET: OwnerController
        public IActionResult Index()
        {
            var owner = _ownerServices.GetAll();
            return View(owner);
        }

        // GET: OwnerController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: OwnerController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OwnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile Image, string OldPhoto, Owner owner)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                owner.PhotoRURL = path;
            }
            try
            {
                _ownerServices.Create(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Edit/5
        public IActionResult Edit(int id)
        {
            var owner = _ownerServices.GetById(id);
            return View(owner);
        }

        // POST: OwnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Owner owner, IFormFile Image)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                owner.PhotoRURL = path;
            }
            try
            {
                _ownerServices.Edit(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OwnerController/Delete/5
        public IActionResult Delete(int id)
        {
            var owner = _ownerServices.GetById(id);
            return View(owner);
        }

        // POST: OwnerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Owner owner)
        {

            try
            {
                _ownerServices.Delete(owner);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
