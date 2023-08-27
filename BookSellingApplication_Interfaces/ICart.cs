using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApplication_Interfaces
{
    public interface ICart<T>
    {
        public void AddToCart(T obj);
        public void RemoveFromCart(int cartIDToBeDeleted, int CustomerID);
        public IEnumerable<T> ViewCart(int CustmerId);
    }
}
