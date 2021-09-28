using BookApiModels;
using BooksApiDtos;
using System.Collections.Generic;

namespace BooksApiData
{
    public interface IBookService
    {
        void AddBook(BookDto book);
        List<Book> GetAllBooks();
        BookDtoWithAuthors GetBookById(int id);
        Book UpdateBook(int id, BookDto book);
        void DeleteBookById(int id);
    }
}
