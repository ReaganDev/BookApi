using BooksApiData.Implementation;
using BooksApiData.Interfaces;
using BooksApiDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
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
    }
}
