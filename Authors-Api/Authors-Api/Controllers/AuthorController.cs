using Authors_Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authors_Api.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AuthorController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        [HttpGet("listall")]
        [HttpGet("/listall")]
        public async Task<ActionResult<List<Author>>> Get()
        {
            return await context.Authors.Include(x => x.Books).ToListAsync();
        }

        [HttpGet("first")]
        public async Task<ActionResult<Author>> GetFirst()
        {
            return await context.Authors.Include(x => x.Books).FirstOrDefaultAsync();
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            var author = await context.Authors.FirstOrDefaultAsync( x => x.Id == id);
            if (author == null) return NotFound(); 
            return author;
        }


        [HttpGet("{name}")]
        public async Task<ActionResult<Author>> GetByName(string name)
        {
            var author = await context.Authors.FirstOrDefaultAsync(x => x.Name.Contains(name));
            if (author == null) return NotFound();
            return author;
        }

        [HttpGet("names/{name}")]
        public async Task<ActionResult<List<Author>>> GetAuthorsByName(string name)
        {
            var authorsList = await context.Authors.ToListAsync();
            List<Author> filteredByNameAuthors = new List<Author>();
            if(authorsList.Count > 0)
            {
                filteredByNameAuthors = authorsList.Where(x => x.Name.Contains(name)).ToList();
            }
            else
            {
                return NotFound("No authors found");
            }
            return filteredByNameAuthors;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Author author)
        {
            context.Add(author);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id , Author author)
        {
            if(author.Id != id)
            {
                return BadRequest("Url id does not match author id");
            }

            bool exists = await context.Authors.AnyAsync(x => x.Id == id);
            if (!exists)
            {
                return NotFound($"Author with id: {id} doesn\'t exists");
            }

            context.Update(author);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            bool exists = await context.Authors.AnyAsync(x => x.Id == id);
            if(!exists)
            {
                return NotFound($"Author with id { id } doesn\'t exists");
            }

            context.Remove(new Author() {Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
