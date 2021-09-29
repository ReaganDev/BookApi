using BooksApiData.Interfaces;
using BooksApiDtos;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [Route("api/[controller]/add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherDto model)
        {
            try
            {
            var newPublisher = _publisherService.AddPublisher(model);
            return Created(nameof(AddPublisher), newPublisher);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/[controller]/get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);
            if (publisher != null)
            {
                return Ok(publisher);
            }

            return NotFound("Publisher does not exist");
        }


        [HttpGet]
        [Route("api/[controller]/get-publisher-books")]
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
        [Route("api/[controller]/delete-publisher")]

        public IActionResult DeletePublisher(int id)
        {
            try
            {             
                _publisherService.DeletePublisher(id);
                return Ok("Publisher Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
