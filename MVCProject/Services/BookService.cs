using Microsoft.EntityFrameworkCore;
using MVCProject.Interfaces;
using MVCProject.Models;

namespace MVCProject.service
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BookService> _logger;
        public BookService(ApplicationDbContext context, ILogger<BookService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Book Save(Book book)
        {
            try
            {
                foreach (var bookAuthor in book.Authors)
                {
                    _context.Attach(bookAuthor);
                }

                var entityEntry = _context.Books.Add(book);

                _context.SaveChanges();

                return entityEntry.Entity;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return null;
            }
        }
        public Book? FindById(int? id)
        {
            Book? book = _context.Books.Include(b => b.Authors).Include(book => book.Category).Include(b => b.BookDetails).AsNoTracking().FirstOrDefault(b => b.Id == id);
            _context.Entry(book).State = EntityState.Detached;

            return id is null ? null : book;
        }

        public List<Book> FindAll()
        {
            return _context.Books.Include(book => book.Authors).Include(book => book.Category).Include(b => b.BookDetails).AsNoTracking().ToList();
        }

        public bool Delete(int? id)
        {
            if (id == null) return false;

            var foundBook = _context.Books.Find(id);

            if (foundBook is not null)
            {
                _context.Books.Remove(foundBook);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Update(Book book)
        {
            try
            {
                var foundBook = _context.Books.Find(book.Id);

                if (foundBook is not null)
                {

                    foundBook.Title = book.Title;
                    foundBook.ReleaseDate = book.ReleaseDate;
                    foundBook.Language = book.Language;
                    foundBook.CategoryId = book.CategoryId;
                    _context.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
