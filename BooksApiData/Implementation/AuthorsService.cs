using BookApiModels;
using BooksApiData.Interfaces;
using BooksApiDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApiData.Implementation
{
    public class AuthorsService : IAuthorsService
    {
        private BookContext _authorContext;

        public AuthorsService(BookContext Context)
        {
            _authorContext = Context;
        }

        public void AddAuthor(AuthorDto model)
        {
            var _author = new Author()
            {
                Name = model.Name
            };
            _authorContext.Authors.Add(_author);
            
            _authorContext.SaveChanges();
        }

        public AuthorWithBookDto GetAuthorAndBooks(int id)
        {
            var _books = _authorContext.Authors.Where(x => x.Id == id).Select(x => new AuthorWithBookDto()
            {
                Name = x.Name,
                BookTitles = x.BookAuthors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _books;
        }
    }
}
