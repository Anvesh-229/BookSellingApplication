using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApplication_Interfaces
{
    public interface IBook<T>
    {
        public T GetBook(int BookId);
        public IEnumerable<T> GetBooksInCategory(int CategoryId);
        public void AddBook(T book);
        public void RemoveBook(int id);
        public void UpdateBook(int BookId, T book);
    }
}
