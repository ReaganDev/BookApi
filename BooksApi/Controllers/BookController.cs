using BooksApiData;
using BooksApiDtos;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BookController : ControllerBase
    {
        private  IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetBookById(string id)
        {
            var book = _bookService.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest("Book Not Found");
        }


        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddBook([FromBody]BookDto book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]

        public IActionResult UpdateBook(string id, [FromBody] BookDto book)
        {
            var updatedBook = _bookService.UpdateBook(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult DeleteBookById(string id)
        {
            _bookService.DeleteBookById(id);
            return Ok();
        }

    }
}
