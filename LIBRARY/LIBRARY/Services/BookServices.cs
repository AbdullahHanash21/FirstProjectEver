using LIBRARY.data;
using LIBRARY.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY.Services
{
    public class BookServices(ApplicationDBcontext context)
    {
        public IEnumerable<Book> Get()
        {
            return context.Books.ToList();
        }
        public IEnumerable<Book> GetByid(int id)
        {
            var x = context.Books.Find(id);
            return context.Books.ToList();
        }
         public bool CreateBook(Book book)
        {
            var test = context.Set<Book_Type>().Find(book.Id_Type);
            if (test is null)return false;
            context.Set<Book>().Add(book);
            test.Num_books = test.Num_books + 1;
            context.SaveChanges();
            return true;
        }
        public IEnumerable<Book> UpdateBook(Book book)
        {
            var test = context.BookTypes.Find(book.Id_Type);
            if (test is null) return null;
            var GetData = context.Books.Find(book.Id_Book);
            if (GetData is null) return null;
            GetData.Description = book.Description;
            GetData.Title = book.Title;
            GetData.Author = book.Author;
            GetData.Id_Book = book.Id_Book;
            GetData.Id_Type = book.Id_Type;
            test.Num_books = test.Num_books + 1;
            context.SaveChanges();
            var result=context.Books.Where(d=>d.Id_Book==book.Id_Book).ToList();
            return result;
        }
        public bool DeleteBook(int id)
        {
            var GetData = context.Set<Book>().Find(id);
            if (GetData is null)return false;
            var GetTypeBook = context.BookTypes.Find(GetData.Id_Type);
            if (GetTypeBook is null)return false;
            context.Remove(GetData);
            GetTypeBook.Num_books =GetTypeBook.Num_books - 1;
            context.SaveChanges();
            return true;
        }
    }
}
