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
    public class AuthorController : ControllerBase
    {
        private IAuthorsService _authorService;

        public AuthorController(IAuthorsService authorService)
        {
            _authorService =authorService;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddAuthor([FromBody] AuthorDto author)
        {
            _authorService.AddAuthor(author);
            return Ok("Author Added");
        }
    }
}
