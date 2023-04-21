using IlMioFotalbum.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;

namespace IlMioFotalbum.Controllers
{
    public class FotoController : Controller
    {
        private readonly ILogger<FotoController> _logger;

        public FotoController(ILogger<FotoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using var ctx = new FotoContext();

            var foto = ctx.Fotos
                .Include(c => c.Categories)
                .ToArray();

            return View(foto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            using var ctx = new FotoContext();

            var foto = ctx.Fotos
                .Include(c => c.Categories)
                .SingleOrDefault(f => f.Id == id);

            if (foto == null)
            {
                return NotFound("Foto non trovata!");
            }

            return View(foto);
        }

        public IActionResult Create()
        {
            using var ctx = new FotoContext();

            var formModel = new FotoFormModel()
            {
                Categories = ctx.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToArray(),
            };

            return View(formModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FotoFormModel form)
        {
            using var ctx = new FotoContext();

            if (!ModelState.IsValid)
            {
                form.Categories = ctx.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToArray();

                return View(form);
            }

            form.Foto.Categories = form.SelectedCategories.Select(sc => ctx.Categories.First(c => c.Id == Convert.ToInt32(sc))).ToList();

            ctx.Fotos.Add(form.Foto);

            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            using var ctx = new FotoContext();

            var foto = ctx.Fotos.Include(f => f.Categories).FirstOrDefault(p => p.Id == id);

            if (foto == null)
            {
                return NotFound();
            }

            var formModel = new FotoFormModel
            {
                Foto = foto,

                Categories = ctx.Categories.ToArray().Select(c => new SelectListItem(c.Name, c.Id.ToString(), foto.Categories!
                .Any(_c => _c.Id == c.Id)))
                .ToArray(),
            };

            formModel.SelectedCategories = formModel.Categories.Where(c => c.Selected).Select(c => c.Value).ToList();

            return View(formModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, FotoFormModel form)
        {
            using var ctx = new FotoContext();

            if (!ModelState.IsValid)
            {
                form.Categories = ctx.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToArray();

                return View(form);
            }

            form.Foto.Categories = form.SelectedCategories.Select(sc => ctx.Categories.First(c => c.Id == Convert.ToInt32(sc))).ToList();

            ctx.Fotos.Update(form.Foto);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using var ctx = new FotoContext();

            var fotoToDelete = ctx.Fotos.FirstOrDefault(p => p.Id == id);

            if (fotoToDelete is null)
            {
                return NotFound();
            }

            ctx.Fotos.Remove(fotoToDelete);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
