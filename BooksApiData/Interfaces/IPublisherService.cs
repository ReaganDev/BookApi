using BookApiModels;
using BooksApiDtos;
using System.Collections.Generic;

namespace BooksApiData.Interfaces
{
    public interface IPublisherService
    {
        Publisher AddPublisher(PublisherDto model);
        PublisherAndBook GetPublisherAndBook(int id);
        void DeletePublisher(int id);
        Publisher GetPublisherById(int id);
        ICollection<Publisher> GetAllPublishers(string sortBy);
    }
}
