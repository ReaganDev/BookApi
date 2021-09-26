using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApiModels
{
    public class Book_Author
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Book Book { get; set; }
        public string BookId { get; set; }
        public Author Author { get; set; }
        public string AuthorId { get; set; }
    }
}
