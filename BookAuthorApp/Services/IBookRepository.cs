﻿using BookAuthorApp.Models.Entities;
using System;

namespace BookAuthorApp.Services
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> ReadAllAsync();

        Task<Book> CreateAsync(Book book);
        Task<Book?> ReadAsync(int id);

        Task<Author> CreateAuthorAsync(int bookId, Author author);
    }
}
