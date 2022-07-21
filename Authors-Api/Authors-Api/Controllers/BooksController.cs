using Authors_Api.Entities;
using Authors_Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authors_Api.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly ILogger<AuthorController> logger;

        public BooksController(ApplicationDbContext context, ILogger<AuthorController> logger, IAuthorService authorService)
        {
            this.context = context;
            this.logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            logger.LogInformation("Information logger called from books");
            logger.LogDebug("Debug from Books controller get by id");
            return await context.Books.Include(x => x.Author).FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Book book)
        {
            bool authorExists = await context.Authors.AnyAsync(x => x.Id == book.AuthorId);

            if (!authorExists)
            {
                return BadRequest("Author doesn\'t exists");
            }

            context.Books.Add(book);    
            await context.SaveChangesAsync(); 
            return Ok();        
        }
    }
}
