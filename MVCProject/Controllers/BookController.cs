using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using MVCProject.Interfaces;
using MVCProject.Models;
using MVCProject.service;
using MVCProject.ViewModels;

namespace MVCProject.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ApplicationDbContext _context;
        public BookController(IBookService bookService, ApplicationDbContext context)
        {
            _bookService = bookService;
            _context = context;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            const int pageSize = 5;

            List<Book?> listOfBooks = (List<Book?>)_bookService.FindAll();

            return View(PaginatedList<Book>.Create(listOfBooks, pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> Details(Book bookModel)
        {
            Book? bookDetails = _bookService.FindById(bookModel.Id);

            if (bookDetails == null)
            {
                TempData["Error"] = "Book is not found in the database!";
                return View(bookModel);
            }

            return bookDetails is null ? NotFound() : View(bookDetails);
        }

        public IActionResult Update(int? id)
        {
            var book = _bookService.FindById(id);
            return book is null ? NotFound() : View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind("Id,Title,ReleaseDate,Created,Language,CategoryId,Category,Authors,AuthorsId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.Update(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Add()
        {
            BookViewModel bookViewModel = new();
            bookViewModel.Authors = GetAuthors();

            return View(bookViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,Title,ReleaseDate,Language,CategoryId,BookDetails,Authors,AuthorsId")] BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                BookDetails bookDetails= new()
                {
                    NumberOfPages = bookViewModel.BookDetails.NumberOfPages,
                    Rating = Convert.ToDouble(bookViewModel.BookDetails.Rating)
                };

                Book newBook = new()
                {
                    Title = bookViewModel.Title,
                    ReleaseDate = bookViewModel.ReleaseDate,
                    CategoryId = bookViewModel.CategoryId,
                    Language = bookViewModel.Language,
                    BookDetails = bookDetails
                };

                foreach (var strId in bookViewModel.AuthorsId)
                {
                    if (int.TryParse(strId, out int id))
                    {
                        newBook.Authors.Add(_context.Authors.Find(id));
                    }
                }

                _bookService.Save(newBook);

                return RedirectToAction(nameof(Index));
            }

            bookViewModel.Authors = GetAuthors();
            return View(bookViewModel);
        }

        public IActionResult Delete(Book bookModel)
        {
            var bookDetails = _bookService.FindById(bookModel.Id);

            if (bookDetails == null) return View("Error");

            _bookService.Delete(bookModel.Id);

            return RedirectToAction("Index");
        }

        private List<SelectListItem> GetAuthors()
        {
            return _context.Authors.Select(a => new SelectListItem()
            {
                Value = a.Id.ToString(),
                Text = $"{a.FirstName} {a.LastName}"
            }).ToList();
        }
    }
}
