using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApiDtos
{
    public class PublisherDto
    {
        public string Name { get; set; }
    }

    public class PublisherAndBook
    {       
        public string PublisherName { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }

    public class BookAuthor
    {
        public string BookName { get; set; }
        public ICollection<string> BookAuthors { get; set; }
    }
}
