using BooksApiData.Interfaces;
using BooksApiDtos;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorsService _authorService;

        public AuthorController(IAuthorsService authorService)
        {
            _authorService =authorService;
        }

        [HttpPost]
        [Route("api/[controller]/add-author")]
        public IActionResult AddAuthor([FromBody] AuthorDto author)
        {
            _authorService.AddAuthor(author);
            return Ok("Author Added");
        }

        [HttpGet]
        [Route("api/[controller]/get-author-books/{authorId}")]

        public IActionResult GetAuthorAndBook(int authorId)
        {
            var books = _authorService.GetAuthorAndBooks(authorId);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound("Id does not belong to an author");
        }
    }
}
