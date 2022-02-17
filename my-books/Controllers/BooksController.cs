using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService) //inject the booksService
        {
            _booksService = booksService; 
        }

        [HttpPost("add-book-with-authors")] // POST
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpGet("get-all-books")] // GET
        public IActionResult GetAllBooks()
        {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")] // this is how we will pass the id to the request /{varName} in this case we pass "id"
        public IActionResult GetBookById(int id) //A. variable name must match
        {
            var singleBook = _booksService.GetBookById(id);// A. with this one!
            return Ok(singleBook);
        }

        [HttpPut("update-book-by-id/{id}")] // PUT = UPDATE
        public IActionResult UpdateBookById(int id,[FromBody]BookVM book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")] // DELETE
        public IActionResult DeleteBookById(int id)
        {
            _booksService.DeleteBookById(id);
            return Ok();
        }

    }
}
