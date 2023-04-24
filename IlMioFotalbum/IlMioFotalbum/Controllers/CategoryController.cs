using IlMioFotalbum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IlMioFotalbum.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using var ctx = new FotoContext();

            var categories = ctx.Categories.ToArray();

            return View(categories);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            using var ctx = new FotoContext();

            var formModel = new CategoryFormModel();

            return View(formModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryFormModel form)
        {
            using var ctx = new FotoContext();

            if (!ModelState.IsValid)
            {
                return View(form);
            }

            ctx.Categories.Add(form.Category);

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            using var ctx = new FotoContext();

            var category = ctx.Categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            var formModel = new CategoryFormModel
            {
                Category = category,
            };

            return View(formModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, CategoryFormModel form)
        {
            using var ctx = new FotoContext();

            if (!ModelState.IsValid)
            {
                form.Category = ctx.Categories.FirstOrDefault(c => c.Id == id);

                return View(form);
            }

            ctx.Categories.Update(form.Category);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using var ctx = new FotoContext();

            var catToDelete = ctx.Categories.FirstOrDefault(p => p.Id == id);

            if (catToDelete is null)
            {
                return NotFound();
            }

            ctx.Categories.Remove(catToDelete);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
