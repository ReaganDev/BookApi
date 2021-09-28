using BooksApiDtos;

namespace BooksApiData.Interfaces
{
    public interface IPublisherService
    {
        void AddPublisher(PublisherDto model);
        PublisherAndBook GetPublisherAndBook(int id);
        void DeletePublisher(int id);
    }
}
