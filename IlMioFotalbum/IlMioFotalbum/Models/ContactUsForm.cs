using System.ComponentModel.DataAnnotations.Schema;

namespace IlMioFotalbum.Models
{
    public class ContactUsForm
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "text")]
        public string Message { get; set; } = string.Empty;
    }
}
