using BookApiModels;
using BooksApiDtos;
using System.Collections.Generic;

namespace BooksApiData
{
    public interface IBookService
    {
        void AddBook(BookDto book);
        List<Book> GetAllBooks();
        Book GetBookById(string id);
        Book UpdateBook(string id, BookDto book);
        void DeleteBookById(string id);
    }
}
