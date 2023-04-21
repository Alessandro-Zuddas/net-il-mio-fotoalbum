using IlMioFotalbum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
