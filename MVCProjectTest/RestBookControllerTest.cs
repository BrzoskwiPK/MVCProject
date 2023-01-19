using Microsoft.AspNetCore.Mvc;
using MVCProject.Controllers;
using MVCProject.Models;

namespace MVCProjectTest
{
    public class RestBookControllerTest
    {
        [Fact]
        public void TestGet()
        {
            // Given
            RestBookController bookController = new RestBookController(new BookRepositoryTest());
            Book expectedBook = new()
            {
                Id = 1,
                Title = "Quo vadis",
                Category = "Historical",
                Language = "Polish"
            };
            // When
            Book fetchedBook = Controller.Get(1).Value;
            // Then
            Assert.Equal(expectedBook.Id, fetchedBook.Id);
            Assert.Equal(expectedBook.Title, fetchedBook.Title);
            Assert.Equal(expectedBook.Category, fetchedBook.Category);
            Assert.Equal(expectedBook.Language, fetchedBook.Language);
        }

        [Fact]
        public void TestGet()
        {
            // Given
            // When
            // Then
        }

    }
}