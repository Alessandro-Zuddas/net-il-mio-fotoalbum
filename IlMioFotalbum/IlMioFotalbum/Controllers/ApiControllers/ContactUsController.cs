using IlMioFotalbum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IlMioFotalbum.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly FotoContext _context;

        public ContactUsController(FotoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult sendContactData([FromBody]ContactUsForm contactUsForm)
        {
            _context.contactUsForms.Add(contactUsForm);

            _context.SaveChanges();

            return Ok(contactUsForm);
        }
    }
}
