using LIBRARY.data;
using LIBRARY.Entities;
using LIBRARY.Services;
using Microsoft.AspNetCore.Mvc;

namespace LIBRARY.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController(BookServices bookservices) : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var result = bookservices.Get();
            if (result is null) return NotFound();
            return Ok(result);
        }
        [HttpGet]
        [Route("id")]
        public ActionResult<Book> GetById(int id)
        {
            var result = bookservices.GetByid(id);
            if (result is null) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        [Route("")]
        public ActionResult CreateBook([FromBody]Book book)
        {
            var result=bookservices.CreateBook(book);
            if (!result)return NotFound("The type of book is not exists");
            return Ok();
        }
        [HttpPut]
        [Route("")]
        public ActionResult<IEnumerable<Book>> UpdateBook([FromBody]Book book)
        {
            var result=bookservices.UpdateBook(book);
            if (result is null) return NotFound("The book is not exists");
            return Ok(result);
        }
        [HttpDelete]
        [Route("")]
        public ActionResult DeleteBook(int id)
        {
            var result = bookservices.DeleteBook(id);
            if (!result) return NotFound();
            return Ok();
        }
    }
}
