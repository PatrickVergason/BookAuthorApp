using BookAuthorApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookAuthorApp.Services
{
    public class DbBookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;
        public DbBookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
            return book;
        }

        public async Task<ICollection<Book>> ReadAllAsync()
        {
            return await _db.Books.Include(p => p.Authors).ToListAsync();
        }

        public async Task<Book?> ReadAsync(int id)
        {
            var person = await _db.Books.FindAsync(id);
            if (person != null)
            {
                // explicit loading
                _db.Entry(person).Collection(p => p.Authors).Load();
            }
            return person;
        }

        public async Task<Author> CreateAuthorAsync(int bookId, Author author)
        {
            var book = await ReadAsync(bookId);
            if (book != null)
            {
                book.Authors.Add(author);
                author.Book = book;
                await _db.SaveChangesAsync();
            }
            return author;
        }
    }
}
