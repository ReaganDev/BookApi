using System;
using System.Collections.Generic;

namespace BooksApiDtos
{
    public class BookDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public bool IsRead { get; set; }
        public int PublisherId { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rating { get; set; }
        public string CoverUrl { get; set; }
        public ICollection<int> AuthorIds { get; set; }
    }

    public class BookDtoWithAuthors
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public bool IsRead { get; set; }
        public string PublisherName { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rating { get; set; }
        public string CoverUrl { get; set; }
        public ICollection<string> AuthorNames { get; set; }
    }
}
