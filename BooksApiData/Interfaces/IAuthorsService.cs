using BooksApiDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApiData.Interfaces
{
    public interface IAuthorsService
    {
        void AddAuthor(AuthorDto model);
        AuthorWithBookDto GetAuthorAndBooks(int id);
    }
}
