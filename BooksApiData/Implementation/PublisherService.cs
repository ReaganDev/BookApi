using BookApiModels;
using BooksApiCore;
using BooksApiData.Interfaces;
using BooksApiDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
            if (StringStartsWithNumber(model.Name))
            {
                throw new PublisherNameException("Publisher Name starts with number", model.Name);
            }
            var _publisher = new Publisher()
            {
                Name = model.Name
            };
            _publisherContext.Add(_publisher);
            _publisherContext.SaveChanges();

            return _publisher;
        }

        public ICollection<Publisher> GetAllPublishers(string sortBy, string search)
        {
            var _allPublishers = _publisherContext.Publishers.OrderBy(n => n.Name).ToList();

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortBy == "Desc")
                {
                    _allPublishers = _allPublishers.OrderByDescending(n => n.Name).ToList();
                }
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                _allPublishers = _allPublishers.Where(x => x.Name.Contains(search, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            return _allPublishers;
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

        private bool StringStartsWithNumber(string name)
        {
           return Regex.IsMatch(name, @"^\d");
        }
    }
}
