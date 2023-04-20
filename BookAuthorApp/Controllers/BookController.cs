using BookAuthorApp.Models.Entities;
using BookAuthorApp.Models.ViewModels;
using BookAuthorApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookAuthorApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;
        public BookController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task<IActionResult> Index()
        {
            var allBooks = await _bookRepo.ReadAllAsync();
            var model = allBooks.Select(b =>
               new BookDetailsVM
               {
                   Id = b.Id,
                   Title = b.Title,
                   PublicationYear = b.PublicationYear,
                   NumberOfAuthors = b.Authors.Count
               });
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            await _bookRepo.CreateAsync(book);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookRepo.ReadAsync(id);
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            BookDetailsVM bookVM = new BookDetailsVM
            {
                Id = book.Id,
                Title = book.Title,
                PublicationYear = book.PublicationYear,
                NumberOfAuthors = book.Authors.Count,
                Authors = book.Authors
            };

            return View(bookVM);
        }
    }
}
