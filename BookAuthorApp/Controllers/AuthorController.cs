using BookAuthorApp.Models.ViewModels;
using BookAuthorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookRepository _bookRepo;

        public AuthorController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task<IActionResult> Create([Bind(Prefix = "id")] int bookId)
        {
            var book = await _bookRepo.ReadAsync(bookId);
            if (book == null)
            {
                return RedirectToAction("Index", "Book");
            }
            ViewData["Book"] = book;

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int bookId, CreateAuthorVM authorVM)
        {
            if (ModelState.IsValid)
            {
                var author = authorVM.GetAuthorInstance();

                await _bookRepo.CreateAuthorAsync(bookId, author);

                return RedirectToAction("Details", "Book", new { id = bookId});
            }
            ViewData["Book"] = await _bookRepo.ReadAsync(bookId);
            return View(authorVM);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
