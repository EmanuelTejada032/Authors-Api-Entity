using Authors_Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Authors_Api.Controllers
{
    [ApiController]
    [Route("api/Authors")]
    public class AuthorController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Author>> Authors()
        {
            return new List<Author>() {
                new Author() {Id = 1, Name = "Emanuel"},
                new Author() {Id = 2, Name = "Laudy"}
            };
        }
    }
}
