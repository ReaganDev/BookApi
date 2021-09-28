using BookApiModels;
using BooksApiDtos;

namespace BooksApiData.Interfaces
{
    public interface IPublisherService
    {
        Publisher AddPublisher(PublisherDto model);
        PublisherAndBook GetPublisherAndBook(int id);
        void DeletePublisher(int id);
        Publisher GetPublisherById(int id);
    }
}
