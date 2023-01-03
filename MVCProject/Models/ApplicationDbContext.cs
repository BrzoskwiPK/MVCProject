using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = 1, Title = "Quo vadis", Category = "Historical", Language = "Polish"},
                new Book() { Id = 2, Title = "Lalka", Category = "Novel", Language = "Polish" },
                new Book() { Id = 3, Title = "Zemsta", Category = "Comedy", Language = "Polish"},
                new Book() { Id = 4, Title = "Balladyna", Category = "Drama", Language = "Polish"},
                new Book() { Id = 5, Title = "Zbrodnia i kara", Category = "Novel", Language = "Russian"},
                new Book() { Id = 6, Title = "Dziady", Category = "Drama", Language = "Polish"},
                new Book() { Id = 7, Title = "Ferdydurke", Category = "Novel", Language = "Polish"},
                new Book() { Id = 8, Title = "Romeo i Julia", Category = "Novel", Language = "English"},
                new Book() { Id = 9, Title = "Wesele", Category = "Drama", Language = "Polish"},
                new Book() { Id = 10, Title = "Cymanowski Młyn", Category = "Fantasy", Language = "Polish"}
            );

            modelBuilder.Entity<Author>().HasData(
                new Author() { Id = 1, FirstName = "Henryk", LastName = "Sienkiewicz" },
                new Author() { Id = 2, FirstName = "Bolesław", LastName = "Prus" },
                new Author() { Id = 3, FirstName = "Aleksander", LastName = "Fredro" },
                new Author() { Id = 4, FirstName = "Juliusz", LastName = "Słowacki" },
                new Author() { Id = 5, FirstName = "Fiodor", LastName = "Dostojewski" },
                new Author() { Id = 6, FirstName = "Adam", LastName = "Mickiewicz" },
                new Author() { Id = 7, FirstName = "Witold", LastName = "Gombrowicz" },
                new Author() { Id = 8, FirstName = "William", LastName = "Szekspir" },
                new Author() { Id = 9, FirstName = "Stanisław", LastName = "Wyspiański" },
                new Author() { Id = 10, FirstName = "Magdalena", LastName = "Witkiewicz" },
                new Author() { Id = 11, FirstName = "Stefan", LastName = "Darda" }
            );

            modelBuilder.Entity<Book>()
                .HasMany<Author>(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity(join => join.HasData(
                    new {BooksId = 1, AuthorsId = 1},
                    new {BooksId = 2, AuthorsId = 2},
                    new {BooksId = 3, AuthorsId = 3},
                    new {BooksId = 4, AuthorsId = 4},
                    new {BooksId = 5, AuthorsId = 5},
                    new {BooksId = 6, AuthorsId = 6},
                    new {BooksId = 7, AuthorsId = 7},
                    new {BooksId = 8, AuthorsId = 8},
                    new {BooksId = 9, AuthorsId = 9},
                    new {BooksId = 10, AuthorsId = 10},
                    new {BooksId = 10, AuthorsId = 11}
                ));
        }
    }
}
