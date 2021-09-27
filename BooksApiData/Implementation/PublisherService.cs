using BookApiModels;
using BooksApiData.Interfaces;
using BooksApiDtos;

namespace BooksApiData.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _publisherContext;

        public PublisherService(BookContext publisherContext)
        {
            _publisherContext = publisherContext;
        }

        public void AddPublisher(PublisherDto model)
        {
            var _publisher = new Publisher()
            {
                Name = model.Name
            };
            _publisherContext.Add(_publisher);
            _publisherContext.SaveChanges();
        }
    }
}
