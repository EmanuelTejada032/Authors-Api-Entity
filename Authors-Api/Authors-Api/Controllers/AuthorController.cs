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
        public async Task<ActionResult<List<Author>>> Get()
        {
            return await context.Authors.Include(x => x.Books).ToListAsync();
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
