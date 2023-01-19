using MVCProject.Interfaces;
using MVCProject.Models;
using MVCProject.Controllers;

namespace MVCPProjectTest
{
    public class BooksControllerTest
    {
        private readonly RestBookController _controller;
        private readonly IBookService _service;

        public BooksControllerTest()
        {
            _service = new BookServiceTest();
            _controller = new RestBookController(_service);

            _service.Save(new Book() { Id = 1, Title = "Quo vadis", Language = "Polish", ReleaseDate = new DateTime(1951, 11, 08), CategoryId = 1 });
            _service.Save(new Book() { Id = 2, Title = "Lalka", Language = "Polish", ReleaseDate = new DateTime(1890, 01, 01), CategoryId = 2 });
            _service.Save(new Book() { Id = 3, Title = "Zemsta", Language = "Polish", ReleaseDate = new DateTime(1834, 11, 05), CategoryId = 3 });
        }

        [Fact]
        public void GetBookByIdTest()
        {
            // Given
            Book expected = new()
            {
                Id = 2,
                Title = "Lalka",
                Language = "Polish",
                ReleaseDate = new DateTime(1890, 01, 01),
                CategoryId = 2
            };
            // When
            Book? actual = _controller.GetBookById(2).Value;
            // Then
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Title, actual.Title);
            Assert.Equal(expected.Language, actual.Language);
            Assert.Equal(expected.ReleaseDate, actual.ReleaseDate);
            Assert.Equal(expected.CategoryId, actual.CategoryId);
        }

        [Fact]
        public void GetAllBooks()
        {
            // Given
            // When
            List<Book?> listOfBooks = _controller.GetAllBooks().Value;
            // Then
            Assert.Equal(3, listOfBooks.Count);
        }

        [Fact]
        public void PutBook()
        {
            // Given
            Book updatedBook = new()
            {
                Id = 2,
                Title = "Updated Lalka",
                Language = "Polish2",
                ReleaseDate = new DateTime(1890, 02, 02),
                CategoryId = 3
            };

            // When
            _controller.PutBook(2, updatedBook);
            // Then
            Book? book = _controller.GetBookById(2).Value;
            Assert.Equal(book.Id, updatedBook.Id);
            Assert.Equal(book.Title, updatedBook.Title);
            Assert.Equal(book.Language, updatedBook.Language);
            Assert.Equal(book.ReleaseDate, updatedBook.ReleaseDate);
            Assert.Equal(book.CategoryId, updatedBook.CategoryId);
        }

        [Fact]
        public void DeleteBook()
        {
            // Given
            // When
            _controller.Delete(3);
            // Then
            Assert.Equal(2, _controller.GetAllBooks().Value.Count);
        }

        [Fact]
        public void CreateBook()
        {
            Book book = new()
            {
                Id = 4,
                Title = "Rest Book",
                ReleaseDate = new DateTime(2023, 01, 01),
                CategoryId = 5,
                Language = "English"
            };

            // When
            _controller.Create(book);

            // Then
            Book createdBook = _controller.GetBookById(4).Value;

            Assert.Equal(4, _controller.GetAllBooks().Value.Count);
            Assert.Equal(createdBook.Id, book.Id);
            Assert.Equal(createdBook.Title, book.Title);
            Assert.Equal(createdBook.Language, book.Language);
            Assert.Equal(createdBook.ReleaseDate, book.ReleaseDate);
            Assert.Equal(createdBook.CategoryId, book.CategoryId);
        }
    }
}
