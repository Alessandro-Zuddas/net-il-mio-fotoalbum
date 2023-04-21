using Microsoft.AspNetCore.Mvc;

namespace IlMioFotalbum.Controllers
{
    public class FotoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
