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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book_Author>()
               .HasOne(ba => ba.Book)
               .WithMany(b => b.BookAuthors)
               .HasForeignKey(ba => ba.BookId);

            modelBuilder.Entity<Book_Author>()
                .HasOne(ba => ba.Author)
                .WithMany(a => a.BookAuthors)
                .HasForeignKey(ba => ba.AuthorId);
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> BookAuthors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

    }
}
