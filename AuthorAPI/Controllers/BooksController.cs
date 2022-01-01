using AuthorAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorAPI.Controllers
{
    [Route("controller")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBooksService BooksService;

        public BooksController(ILogger<BooksController> logger, IBooksService booksService)
        {
            _logger = logger;
            BooksService = booksService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Book>>> GetBooks()
        {
            try
            {
                IList<Book> books = await BooksService.GetBooksAsync();
                return Ok(books);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{authorId:int}")]
        public async Task<ActionResult<Book>> AddBook([FromBody] Book book, [FromRoute] int authorId)
        {
            try
            {
                book.AuthorId = authorId;
                Book added = await BooksService.AddBookAsync(book);
                return Created($"/{added.ISBN}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{isbn:int}")]
        public async Task<ActionResult> DeleteBook([FromRoute] int isbn)
        {
            try
            {
                await BooksService.DeleteBookAsync(isbn);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
