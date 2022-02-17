using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        AuthorsService _authorsServices;

        public AuthorsController(AuthorsService authorsService)
        {
            _authorsServices = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        { 
            _authorsServices.AddAuthor(author);
            return Ok();
        }

        [HttpDelete("delete-author/{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            _authorsServices.DeleteAuthorById(id);
            return Ok();
        }
    }
}
