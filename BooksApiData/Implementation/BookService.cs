using BookApiModels;
using BooksApiDtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksApiData
{
    public class BookService : IBookService
    {
        private BookContext _bookContext;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public void AddBook(BookDto book)
        {
            var _book = new Book()
            {
                Author = book.Author,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rating = book.IsRead ? book.Rating.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
            _bookContext.Books.Add(_book);
            _bookContext.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return _bookContext.Books.ToList();           
        }

        public Book GetBookById(string id)
        {
            return _bookContext.Books.FirstOrDefault(x => x.Id == id);
        }

        public Book UpdateBook(string id, BookDto book)
        {
            var existingBook = GetBookById(id);
            if (existingBook != null)
            {
                existingBook.Author = book.Author;
                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.IsRead = book.IsRead;
                existingBook.DateRead = book.IsRead ? book.DateRead.Value : null;
                existingBook.Rating = book.IsRead ? book.Rating.Value : null;
                existingBook.Genre = book.Genre;
                existingBook.CoverUrl = book.CoverUrl;

                _bookContext.SaveChanges();
            }
            return existingBook;
        }

        public void DeleteBookById(string id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _bookContext.Books.Remove(book);
                _bookContext.SaveChanges();
            }
        }
    }
}
