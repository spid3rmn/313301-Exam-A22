using AuthorAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        private readonly IAuthorsService AuthorsService;

        public AuthorsController(ILogger<AuthorsController> logger, IAuthorsService authorsService)
        {
            _logger = logger;
            AuthorsService = authorsService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Author>>> GetAuthors()
        {
            try
            {
                IList<Author> authors = await AuthorsService.GetAuthorsAsync();
                return Ok(authors);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor([FromBody] Author author)
        {
            try
            {
                Author added = await AuthorsService.AddAuthorAsync(author);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
