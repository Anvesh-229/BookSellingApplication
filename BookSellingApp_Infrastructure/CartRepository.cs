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
    public class CartRepository<T> : ICart<T> where T : Cart
    {
        static ApplicationDbContext context = new ApplicationDbContext();

        public void AddToCart(T obj)
        {
            context.CartDetails.Add(obj);
        }

        public void RemoveFromCart(int BookID, int CustomerID)
        {
            var item = context.CartDetails.FirstOrDefault(u => u.Book_Id == BookID && u.CustomerId == CustomerID);
            context.CartDetails.Remove(item);
        }

        public IEnumerable<T> ViewCart(int customerID)
        {
            IEnumerable<T> CartItems = (IEnumerable<T>)context.CartDetails.Where(u => u.CustomerId == customerID).ToList();
            return CartItems;
        }
    }
}
