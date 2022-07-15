using Authors_Api.Entities;
using Authors_Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authors_Api.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IAuthorService service;

        public AuthorController(ApplicationDbContext context, IAuthorService service )
        {
            this.context = context;
            this.service = service;
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
        public async Task<ActionResult<Author>> GetByName([FromRoute]string name)
        {
            var author = await context.Authors.FirstOrDefaultAsync(x => x.Name.Contains(name));
            if (author == null) return NotFound();
            return author;
        }


        [HttpGet("{name}/{secondParam=person}")]
        public async Task<ActionResult<Author>> GetByName(string name, string secondParam)
        {
            var author = await context.Authors.FirstOrDefaultAsync(x => x.Name.Contains(name));
            if (author == null) return NotFound();
            return author;
        }

        [HttpGet("names/{name}")]
        public async Task<ActionResult<List<Author>>> GetAuthorsByName(string name)
        {
            var authorsList = await context.Authors.Where(x => x.Name.Contains(name)).ToListAsync();
            if (authorsList.Count > 0)
            {
                return authorsList;
            }
            else
            {
                return NotFound("No authors found");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Author author)
        {
            bool authorNameExists = await context.Authors.AnyAsync( x => x.Name == author.Name);
            if (authorNameExists)
            {
                return BadRequest($"there is an author with the name {author.Name}");
            }
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
