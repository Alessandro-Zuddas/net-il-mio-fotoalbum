using IlMioFotalbum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IlMioFotalbum.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotoController : Controller
    {
        private readonly FotoContext _context;

        public FotoController(FotoContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetFotos([FromQuery] string? name)
        {
            var fotos = _context.Fotos
                .Include(f => f.Categories)
                .Where(f => name == null || f.Name.ToLower().Contains(name.ToLower()))
                .ToList();

            return Ok(fotos);
        }

        [HttpGet("{id}")]
        public IActionResult GetFotos(int id)
        {
            var foto = _context.Fotos.FirstOrDefault(f => f.Id == id);

            if (foto == null)
            {
                return NotFound();
            }

            return Ok(foto);
        }
    }
}
