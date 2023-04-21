using System.ComponentModel.DataAnnotations;

namespace IlMioFotalbum.Models
{
    public class Foto
    {
        public Foto() { }

        public Foto(string _name, string _description, string _imgPath)
        {
            Name = _name;
            Description = _description;
            ImgPath = _imgPath;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Nome obbligatorio!")]
        [StringLength(50, ErrorMessage = "Il nome non può essere più lungo di 50 caratteri!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Descrizione obbligatoria!")]
        [StringLength(150, ErrorMessage = "La descrizione non può essere più lunga di 150 caratteri!")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Percorso dell'immagine obbligatorio!")]
        public string? ImgPath { get; set; }

        [Required(ErrorMessage = "Visibilità da dichiarare!")]
        public string IsVisible { get; set; }

        public List<Category>? Categories { get; set; }
    }
}
