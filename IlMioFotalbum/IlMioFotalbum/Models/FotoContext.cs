using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IlMioFotalbum.Models
{
    public class FotoContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Category> Categories { get; set; }

        public FotoContext()
        {

        }

        public FotoContext(DbContextOptions<FotoContext> options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=AlbumDb;Integrated Security=True;Pooling=False;TrustServerCertificate = True");
        }

        public void Seed()
        {
            var fotoSeed = new Foto[]
            {
                new Foto
                {
                    Name = "Foto 1",
                    Description = "Descrizione foto 1",
                    ImgPath = "https://media.istockphoto.com/id/1147544807/it/vettoriale/la-commissione-per-la-immagine-di-anteprima-grafica-vettoriale.jpg?s=612x612&w=0&k=20&c=gsxHNYV71DzPuhyg-btvo-QhhTwWY0z4SGCSe44rvg4=",
                    IsVisible = true,
                },
                new Foto
                {
                    Name = "Foto 2",
                    Description = "Descrizione foto 2",
                    ImgPath = "https://media.istockphoto.com/id/1147544807/it/vettoriale/la-commissione-per-la-immagine-di-anteprima-grafica-vettoriale.jpg?s=612x612&w=0&k=20&c=gsxHNYV71DzPuhyg-btvo-QhhTwWY0z4SGCSe44rvg4=",
                    IsVisible = true,
                },
                new Foto
                {
                    Name = "Foto 3",
                    Description = "Descrizione foto 3",
                    ImgPath = "https://media.istockphoto.com/id/1147544807/it/vettoriale/la-commissione-per-la-immagine-di-anteprima-grafica-vettoriale.jpg?s=612x612&w=0&k=20&c=gsxHNYV71DzPuhyg-btvo-QhhTwWY0z4SGCSe44rvg4=",
                    IsVisible = true,
                },
                new Foto
                {
                    Name = "Foto 4",
                    Description = "Descrizione foto 4",
                    ImgPath = "https://media.istockphoto.com/id/1147544807/it/vettoriale/la-commissione-per-la-immagine-di-anteprima-grafica-vettoriale.jpg?s=612x612&w=0&k=20&c=gsxHNYV71DzPuhyg-btvo-QhhTwWY0z4SGCSe44rvg4=",
                    IsVisible = true,
                },
                new Foto
                {
                    Name = "Foto 5",
                    Description = "Descrizione foto 5",
                    ImgPath = "https://media.istockphoto.com/id/1147544807/it/vettoriale/la-commissione-per-la-immagine-di-anteprima-grafica-vettoriale.jpg?s=612x612&w=0&k=20&c=gsxHNYV71DzPuhyg-btvo-QhhTwWY0z4SGCSe44rvg4=",
                    IsVisible = false,
                }
            };

            if (!Fotos.Any())
            {
                Fotos.AddRange(fotoSeed);
            };

            if (!Categories.Any())
            {
                var seed = new Category[]
                {
                    new Category
                    {
                        Name = "Natura",
                        Fotos = fotoSeed,
                    },
                    new Category
                    {
                        Name = "Eventi",
                    },
                    new Category
                    {
                        Name = "Generica",
                    }
                };

                Categories.AddRange(seed);
            };

            SaveChanges();
        }
    }
}
