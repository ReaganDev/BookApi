using BookApiModels;
using BooksApiCore;
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
            catch (PublisherNameException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/[controller]/get-publisher-by-id/{id}")]
        public Publisher GetPublisherById(int id)
        {
            var _publisher = _publisherService.GetPublisherById(id);
            if (_publisher != null)
            {
               // return Ok(_publisher);
                return _publisher;
            }
           // return NotFound("Publisher Not found");
            return null;
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
