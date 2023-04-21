using IlMioFotalbum.Models;
using Microsoft.AspNetCore.Mvc;

namespace IlMioFotalbum.Controllers
{
    public class FotoController : Controller
    {

        public IActionResult Index()
        {
            using var ctx = new FotoContext();

            var foto = ctx.Fotos.ToArray();

            return View(foto);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
