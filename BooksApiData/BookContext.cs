using BookApiModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace BooksApiData
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
