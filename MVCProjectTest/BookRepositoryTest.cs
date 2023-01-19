using MVCProject.Interfaces;
using MVCProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCProjectTest
{
    internal class BookRepositoryTest : IBookRepository
    {
        private Dictionary<int, Book> _books;
        private int index;
        public BookRepositoryTest()
        {
            _books= new Dictionary<int, Book>();
        }
        public bool AddAsync(Book book)
        {
            book.Id = nextIndex();
            _books.Add(book.Id, book);
            
        }

        public bool Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookById(int? bookId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateAsync(Book book)
        {
            throw new NotImplementedException();
        }

        private int nextIndex()
        {
            return ++index;
        }
    }
}
