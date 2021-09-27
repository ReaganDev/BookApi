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
    }
}
