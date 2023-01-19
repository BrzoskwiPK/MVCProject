using MVCProject.Interfaces;
using MVCProject.Models;

namespace MVCPProjectTest
{
    public class BookServiceTest : IBookService
    {
        private List<Book> _books;
        private int index;

        public BookServiceTest()
        {
            _books = new List<Book>();
        }

        private int NextIndex()
        {
            return ++index;
        }

        public Book Save(Book book)
        {
            book.Id = NextIndex();
            _books.Add(book);

            return _books.Find(b => b.Id == book.Id);
        }

        public bool Delete(int? id)
        {
            Book? book = _books.Find(b => b.Id == id);

            if (book != null)
            {
                _books.Remove(book);
                return true;
            }

            return false;
        }

        public List<Book> FindAll()
        {
            return _books;
        }

        public Book? FindById(int? id)
        {
            Book? book = _books.Find(b => b.Id == id);

            if (book == null) return null;
            return book;
        }

        public bool Update(Book updatedBook)
        {
            Book? book = _books.Find(b => b.Id == updatedBook.Id);

            if (book == null)
            {
                return false;
            }

            _books.Remove(book);
            _books.Add(updatedBook);

            return true;
        }
    }
}