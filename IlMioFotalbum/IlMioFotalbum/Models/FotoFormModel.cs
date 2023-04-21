using Microsoft.AspNetCore.Mvc.Rendering;

namespace IlMioFotalbum.Models
{
    public class FotoFormModel
    {
        public Foto Foto { get; set; } = new Foto();

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        public List<string>? SelectedCategories { get; set; }
    }
}

