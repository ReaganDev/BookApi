using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApiDtos
{
    public class AuthorDto
    {
        public string Name { get; set; }
    }

    public class AuthorWithBookDto
    {
        public string Name { get; set; }
        public ICollection<string> BookTitles { get; set; }
    }
}
