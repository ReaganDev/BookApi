using BookApiModels;
using BooksApiData.Interfaces;
using BooksApiDtos;
using System;
using System.Linq;

namespace BooksApiData.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _publisherContext;

        public PublisherService(BookContext publisherContext)
        {
            _publisherContext = publisherContext;
        }

        public Publisher AddPublisher(PublisherDto model)
        {
            var _publisher = new Publisher()
            {
                Name = model.Name
            };
            _publisherContext.Add(_publisher);
            _publisherContext.SaveChanges();

            return _publisher;
        }

        public Publisher GetPublisherById(int id) => _publisherContext.Publishers.FirstOrDefault(x => x.Id == id);

        public PublisherAndBook GetPublisherAndBook(int id)
        {
            var _publishedBooks = _publisherContext.Publishers.Where(x => x.Id == id).Select(x => new PublisherAndBook()
            {
                PublisherName = x.Name,
                BookAuthors = x.Books.Select(n => new BookAuthor()
                {
                    BookName = n.Title,
                    BookAuthors = n.BookAuthors.Select(n => n.Author.Name).ToList()
                }).ToList()
            }).FirstOrDefault();

            return _publishedBooks;
        }

        public void DeletePublisher(int id)
        {
            var _publisher = _publisherContext.Publishers.FirstOrDefault(x => x.Id == id);
            if (_publisher != null)
            {
                _publisherContext.Publishers.Remove(_publisher);
                _publisherContext.SaveChanges();
            }
            else
            {
                throw new Exception($"The publisher with id: {id} does not exist");
            }
        }
    }
}
