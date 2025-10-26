using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Netflix.Database.Entities;

namespace Netflix.Database.Context
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        // Informacje jakie tabele są w bazie
        // (za pomocą tych obiektów kominukujemy się bezpośrednio z poszczególnymi tabelami)
        public virtual required DbSet<Category> Categories { get; set; }
        public virtual required DbSet<Movie> Movies { get; set; }
        public virtual required DbSet<Actor> Actors { get; set; }


        // Można umieścić dodatkowe informacje jeżeli potrzeba
        // Jeżeli wystepują relacje, musimy wskazać jakiego są typu
        // Możemy również utworzyć bazę danych z początkowymi wartościami
        // Powyższe info zamieszczamy za pomocą metody OnModelCraeting

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Relacje
            modelBuilder.Entity<Movie>().HasOne(m => m.Category).WithMany(c => c.Movies);

            // Nabijanie danych początkowych
            var initialCategories = CreateInitialCategories();
            modelBuilder.Entity<Category>().HasData(initialCategories);
        }

        private static Category[] CreateInitialCategories()
        {
            var result = new List<Category>
            {
                new Category { Id = 1, Name = "Horror" },
                new Category { Id = 2, Name = "Komedia" },
                new Category { Id = 3, Name = "Dramat" },
                new Category { Id = 4, Name = "Akcja" },
                new Category { Id = 5, Name = "Thriller" },
                new Category { Id = 6, Name = "Sci-Fi" },
                new Category { Id = 7, Name = "Animowany" }
            };

            return result.OrderBy(r => r.Name).ToArray();
        }
    }
}
