using BookAuthorApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookAuthorApp.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();
    }
}
