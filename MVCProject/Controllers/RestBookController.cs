using Microsoft.AspNetCore.Mvc;
using MVCProject.Interfaces;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    [Route("/api/books")]
    [ApiController]
    public class RestBookController : ControllerBase
    {
        private readonly IBookService _service;

        public RestBookController(IBookService service)
        {
            _service = service;
        }

        // GET: api/Books
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            if (_service == null)
            {
                return NotFound();
            }

            return new ActionResult<List<Book>>(_service.FindAll());
        }

        // GET: api/Books/5
        [HttpGet]
        [Route("{id?}")]
        public ActionResult<Book?> GetBookById(int? id)
        {
            if (_service == null)
            {
                return NotFound();
            }

            Book? book = _service.FindById(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book? book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            book.Id = id;
            _service.Update(book);
            return NoContent();
        }

        // POST: api/Books
        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            if (_service == null)
            {
                return Problem("Entity set AppDbContext.Books is null.");
            }

            if (ModelState.IsValid)
            {
                var saved = _service.Save(book);
                return Created($"/api/books/{saved.Id}", saved);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (_service == null)
            {
                return NotFound();
            }

            var book = _service.Delete(id);

            if (book == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
