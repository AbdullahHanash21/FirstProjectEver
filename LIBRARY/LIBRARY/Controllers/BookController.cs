using LIBRARY.data;
using LIBRARY.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LIBRARY.Controllers
{
    public class BookController : ControllerBase
    {

        private readonly ApplicationDBcontext _dbcontext;
        public BookController(ApplicationDBcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var x = _dbcontext.Set<Book>().ToList();
            if (x is null) return NotFound();
            return Ok(x);
        }
        [HttpGet]
        [Route("id")]
        public ActionResult<Book> GetById(int id)
        {
            var x = _dbcontext.Set<Book>().Find(id);
            if (x is null) return NotFound();
            return Ok(x);
        }
        [HttpPost]
        [Route("")]
        public ActionResult CreateBookType([FromBody]Book book)
        {
            var test = _dbcontext.Set<Book_Type>().Find(book.Id_Type);
            if (test is null) return NotFound();
            _dbcontext.Set<Book>().Add(book);
            test.Num_books=test.Num_books+1;
            _dbcontext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [Route("")]
        public ActionResult<IEnumerable<Book>> UpdateBookType([FromBody]Book book)
        {
            var test = _dbcontext.Set<Book_Type>().Find(book.Id_Type);
            var x = _dbcontext.Set<Book>().Find(book.Id_Book);
            if (test is null|| x is null) return NotFound();
            x.Description=book.Description;
            x.Title=book.Title;
            x.Author=book.Author;
            x.Id_Book=book.Id_Book;
            x.Id_Type=book.Id_Type;
            test.Num_books=test.Num_books+1;
            _dbcontext.SaveChanges();
            return Ok(x);
        }
        [HttpDelete]
        [Route("")]
        public ActionResult DeleteBookType(int id)
        {
            var x = _dbcontext.Set<Book>().Find(id);
            if (x is null) return NotFound();
            var z = _dbcontext.Set<Book_Type>().Find(x.Id_Type);
            _dbcontext.Remove(x);
            z.Num_books=z.Num_books-1;
            _dbcontext.SaveChanges();
            return Ok(x);
        }
    }
}
