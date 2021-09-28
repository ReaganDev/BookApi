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
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Rating = book.IsRead ? book.Rating.Value : null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };
            _bookContext.Books.Add(_book);
            _bookContext.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _bookAuthor = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _bookContext.BookAuthors.Add(_bookAuthor);
                _bookContext.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()
        {
            return _bookContext.Books.ToList();           
        }

        public BookDtoWithAuthors GetBookById(int id)
        {
            var _book = _bookContext.Books.Where(x => x.Id == id).Select(book => new BookDtoWithAuthors()
            {
                Title = book.Title,
                Description = book.Description, 
                Genre = book.Genre,
                IsRead = book.IsRead,
                PublisherName = book.Publisher.Name,
                DateRead = book.DateRead,
                Rating = book.Rating,
                CoverUrl = book.CoverUrl,
                AuthorNames = book.BookAuthors.Select(x => x.Author.Name).ToList()
            }).FirstOrDefault();

            return _book;
        }

        public Book UpdateBook(int id, BookDto book)
        {
            var existingBook = _bookContext.Books.FirstOrDefault(x => x.Id == id);
            if (existingBook != null)
            {
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

        public void DeleteBookById(int id)
        {
            var book = _bookContext.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                _bookContext.Books.Remove(book);
                _bookContext.SaveChanges();
            }
        }
    }
}
