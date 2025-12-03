using LIBRARY.data;
using LIBRARY.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace LIBRARY.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Book_TypeController : ControllerBase
    {
        private readonly ApplicationDBcontext _dbcontext;
        public Book_TypeController(ApplicationDBcontext dbcontext)
        {
            _dbcontext=dbcontext;
        }
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Book_Type>> Get() {
            var x=_dbcontext.Set<Book_Type>().ToList();
            if (x is null)return NotFound();
            return Ok(x);
        }
        [HttpGet]
        [Route("id")]
        public ActionResult<Book_Type> GetById(int id)
        {
            var x=_dbcontext.Set<Book_Type>().Find(id);
            if (x is null)return NotFound();
            return Ok(x);
        }
        [HttpPost]
        [Route("")]
        public ActionResult CreateBookType(Book_Type bookType) 
        {
            _dbcontext.Set<Book_Type>().Add(bookType);
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [Route("")]
        public ActionResult<IEnumerable<Book_Type>> UpdateBookType(Book_Type bookType)
        {
            var x = _dbcontext.Set<Book_Type>().Find(bookType.Id_Type);
            if (x is null)return NotFound();
            x.Name_Type=bookType.Name_Type;
            x.Num_books=bookType.Num_books;
            _dbcontext.SaveChanges();
            return Ok(x);
        }
        [HttpDelete]
        [Route("")]
        public ActionResult DeleteBookType(int id)
        {
            var x = _dbcontext.Set<Book_Type>().Find(id);
            if (x is null) return NotFound();
            _dbcontext.Remove(x);
            _dbcontext.SaveChanges();
            return Ok(x);
        }
    }
}
