using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;
using System;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        PublishersService _publishersService;

        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpPost("add-publisher")]
        public IActionResult addPublisher([FromBody] PublisherVM publisher) 
        {
            var newPublisher = _publishersService.addPublisher(publisher);
            return Created(nameof(addPublisher), newPublisher);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisher(int id)
        {

            try // Exception handling
            {
                _publishersService.DeletePublisherById(id);
                return Ok();
            }
            catch (Exception ex) // Try and use specific exception types e.g. ArithmeticException when division by 0 occurs
            {
                return BadRequest(ex.Message);
                
            }
        }

        [HttpGet("get-publisher-data/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var response = _publishersService.GetPublisherData(id);
            return Ok(response);
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var response = _publishersService.getPublisherById(id);
            if (response != null)
            {
                return Ok(response);
            }
            else { 
                return NotFound();
            }
        }
    }
}
