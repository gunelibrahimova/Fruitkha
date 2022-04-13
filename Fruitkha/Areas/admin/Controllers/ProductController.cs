using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace Fruitkha.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IWebHostEnvironment _environment;

        public ProductController(IProductServices productServices, ICategoryServices categoryServices, IWebHostEnvironment environment)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _environment = environment;
        }

        // GET: ProductController
        public ActionResult Index()
        {
           var product = _productServices.GetAll();
            return View(product);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryServices.GetAll();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile Image, string OldPhoto)
        {
            try
            {
                if(Image != null)
                {
                    string path = "/files/" + Guid.NewGuid() + Image.FileName;
                    using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                    {
                        await Image.CopyToAsync(fileStream);
                    }
                    product.PhotoURL = path;
                }
                else
                {
                    product.PhotoURL = OldPhoto;
                }
                
                _productServices.Create(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = _categoryServices.GetAll();
            var product = _productServices.GetById(id);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile Image)
        {
            if (Image != null)
            {
                string path = "/files/" + Guid.NewGuid() + Image.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Image.CopyToAsync(fileStream);
                }
                product.PhotoURL = path;
            }
            try
            {
                _productServices.Edit(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _productServices.GetById(id);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Product product)
        {
            try
            {
                _productServices.Delete(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
