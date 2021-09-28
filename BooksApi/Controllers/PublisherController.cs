using BooksApiData.Interfaces;
using BooksApiDtos;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private IPublisherService _publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddPublisher([FromBody] PublisherDto model)
        {
            _publisherService.AddPublisher(model);
            return Ok("Publisher Added");
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetPublisherBooks(int id)
        {
            var _books = _publisherService.GetPublisherAndBook(id);
            if (_books != null)
            {
                return Ok(_books);
            }
            return NotFound("No book found");           
        }

        [HttpDelete]
        [Route("api/[controller]")]

        public IActionResult DeletePublisher(int id)
        {
            _publisherService.DeletePublisher(id);
            return Ok("Publisher Deleted");
        }

    }
}
