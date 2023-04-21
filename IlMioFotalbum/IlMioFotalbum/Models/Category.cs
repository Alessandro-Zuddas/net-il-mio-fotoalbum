using System.ComponentModel.DataAnnotations;

namespace IlMioFotalbum.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obbligatorio!")]
        [StringLength(50, ErrorMessage = "Il nome non può essere più lungo di 50 caratteri!")]
        public string? Name { get; set; }

        public IEnumerable<Foto>? Fotos { get; set; }
    }
}
