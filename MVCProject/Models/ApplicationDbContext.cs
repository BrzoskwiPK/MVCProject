using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVCProject.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookDetails> BookDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = 1, Title = "Quo vadis", Language = "Polish", ReleaseDate = new DateTime(1951, 11, 08), CategoryId = 1 },
                new Book() { Id = 2, Title = "Lalka", Language = "Polish", ReleaseDate = new DateTime(1890, 01, 01), CategoryId = 2 },
                new Book() { Id = 3, Title = "Zemsta", Language = "Polish", ReleaseDate = new DateTime(1834, 11, 05), CategoryId = 3 },
                new Book() { Id = 4, Title = "Balladyna", Language = "Polish", ReleaseDate = new DateTime(1839, 04, 05), CategoryId = 4 },
                new Book() { Id = 5, Title = "Zbrodnia i kara", Language = "Russian", ReleaseDate = new DateTime(1866, 11, 8), CategoryId = 3 },
                new Book() { Id = 6, Title = "Dziady", Language = "Polish", ReleaseDate = new DateTime(1860, 12, 12), CategoryId = 1},
                new Book() { Id = 7, Title = "Ferdydurke", Language = "Polish", ReleaseDate = new DateTime(1937, 10, 10), CategoryId = 2 },
                new Book() { Id = 8, Title = "Romeo i Julia", Language = "English", ReleaseDate = new DateTime(1597, 01, 15), CategoryId = 3 },
                new Book() { Id = 9, Title = "Wesele", Language = "Polish", ReleaseDate = new DateTime(1901, 03, 16), CategoryId = 2 },
                new Book() { Id = 10, Title = "Cymanowski Młyn", Language = "Polish", ReleaseDate = new DateTime(2019, 02, 01), CategoryId = 5 }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, Name = "Historical", Description = "Books about historical events" },
                new Category() { CategoryId = 2, Name = "Novel", Description = "Books with extensive plots" },
                new Category() { CategoryId = 3, Name = "Drama", Description = "Books about misfortunes" },
                new Category() { CategoryId = 4, Name = "Comedy", Description = "Funny books" },
                new Category() { CategoryId = 5, Name = "Fantasy", Description = "Books about uncreated stories" }
            );

            modelBuilder.Entity<Book>().HasOne(b => b.Category).WithMany(c => c.Books);

            modelBuilder.Entity<Book>()
                .Property<DateTime>(b => b.Created)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

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

            modelBuilder.Entity<BookDetails>().HasData(
                new BookDetails() { BookDetailsId = 1, NumberOfPages = 450, Rating = 5.0},
                new BookDetails() { BookDetailsId = 2, NumberOfPages = 450, Rating = 4.5 },
                new BookDetails() { BookDetailsId = 3, NumberOfPages = 450, Rating = 4.5 },
                new BookDetails() { BookDetailsId = 4, NumberOfPages = 450, Rating = 5.0 },
                new BookDetails() { BookDetailsId = 5, NumberOfPages = 450, Rating = 4.0 },
                new BookDetails() { BookDetailsId = 6, NumberOfPages = 450, Rating = 3.5 },
                new BookDetails() { BookDetailsId = 7, NumberOfPages = 450, Rating = 5.0 },
                new BookDetails() { BookDetailsId = 8, NumberOfPages = 450, Rating = 4.0 },
                new BookDetails() { BookDetailsId = 9, NumberOfPages = 450, Rating = 5.0 },
                new BookDetails() { BookDetailsId = 10, NumberOfPages = 450, Rating = 2.0 }
            );

            modelBuilder.Entity<BookDetails>().HasOne(b => b.Book).WithOne(c => c.BookDetails);

            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity(join => join.HasData(
                    new { BooksId = 1, AuthorsId = 1 },
                    new { BooksId = 2, AuthorsId = 2 },
                    new { BooksId = 3, AuthorsId = 3 },
                    new { BooksId = 4, AuthorsId = 4 },
                    new { BooksId = 5, AuthorsId = 5 },
                    new { BooksId = 6, AuthorsId = 6 },
                    new { BooksId = 7, AuthorsId = 7 },
                    new { BooksId = 8, AuthorsId = 8 },
                    new { BooksId = 9, AuthorsId = 9 },
                    new { BooksId = 10, AuthorsId = 10 },
                    new { BooksId = 10, AuthorsId = 11 }
                ));
        }
    }
}
