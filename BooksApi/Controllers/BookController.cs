using BooksApiData;
using BooksApiDtos;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]

    public class BookController : ControllerBase
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("api/[controller]/get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet]
        [Route("api/[controller]/get-books-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }
            return BadRequest("Book Not Found");
        }       

        [HttpPost]
        [Route("api/[controller]/add-book")]
        public IActionResult AddBook([FromBody] BookDto book)
        {
            _bookService.AddBook(book);
            return Ok();
        }

        [HttpPut]
        [Route("api/[controller]/update-book/{id}")]

        public IActionResult UpdateBook(int id, [FromBody] BookDto book)
        {
            var updatedBook = _bookService.UpdateBook(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult DeleteBookById(int id)
        {
            _bookService.DeleteBookById(id);
            return Ok();
        }

    }
}
