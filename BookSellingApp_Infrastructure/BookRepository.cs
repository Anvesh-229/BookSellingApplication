using BookSellingApplication_DataAccess.Data;
using BookSellingApplication_Interfaces;
using BookSellingApplication_Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApp_Infrastructure
{
    public class BookRepository<T> : IBook<T> where T : Book
    {
        static ApplicationDbContext context = new ApplicationDbContext();

        public void AddBook(T book)
        {
            context.Books.Add(book);
        }

        public T GetBook(int BookId)
        {
            var books = context.Books.ToList();
            foreach (var book in books)
            {
                if (book.Book_Id == BookId)
                {
                    return (T)book;
                }
            }
            throw new Exception();
        }

        public IEnumerable<T> GetBooksInCategory(int CategoryId)
        {
            IEnumerable<T> books = (IEnumerable<T>)context.Books.Where(u => u.Category_ID == CategoryId).ToList();
            return books;
        }

        public void RemoveBook(int id)
        {
            var book = context.Books.FirstOrDefault(u => u.Book_Id == id);
            context.Books.Remove(book);
        }

        public void UpdateBook(int BookId, T book)
        {

        }
    }
}
