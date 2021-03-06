using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApiModels
{
   public class Book
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rating { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        // Navigation Properties
        public Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        public ICollection<Book_Author> BookAuthors { get; set; }


    }
}
