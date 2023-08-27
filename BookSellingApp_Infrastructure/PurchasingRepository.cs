using BookSellingApplication_DataAccess.Data;
using BookSellingApplication_Interfaces;
using BookSellingApplication_Model.Models;
using Microsoft.AspNetCore.Http.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApp_Infrastructure
{
    public class PurchasingRepository<T> : IPurchase<T> where T : class
    {
        static ApplicationDbContext context = new ApplicationDbContext();
        public void PurchaseAllCartItems(int customerId)
        {
            int totalamount = 0;
            var TotalCart = context.CartDetails.Where(u => u.CustomerId == customerId).ToList();
            foreach (var item in TotalCart)
            {
                var bookPriceDetails = context.Books.Where(u => u.Book_Id == item.Book_Id).ToList();
                foreach (var item1 in bookPriceDetails)
                {
                    totalamount = totalamount + (int.Parse(item.Quantity)) * item1.Price ;
                    var available = item1.Available_Quantity;
                    item1.Available_Quantity = available - int.Parse(item.Quantity);
                }
            }
            Console.WriteLine("Your Total Amount for this purchase is {0}",totalamount);
            Console.WriteLine(@"Pease check your amount and select the below options
1.Order
2.Cancel");
            var choice6= int.Parse(Console.ReadLine());
            if(choice6 == 1)
            {
                Console.WriteLine("Your order is purchased successfully");
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Your order is cancelled successfully");
            }
        }

        public void PurchseCartItemsSeperately(int PurchasingcartId, int PurchasingCustomerId)
        {
            int totalAmount = 0;
            var SeperateCart = context.CartDetails.Where(u => u.CustomerId == PurchasingCustomerId && u.Id == PurchasingcartId).ToList();
            foreach (var item in SeperateCart)
            {
                var bookPriceDetails = context.Books.Where(u => u.Book_Id == item.Book_Id).ToList();
                foreach (var item1 in bookPriceDetails)
                {
                    totalAmount = totalAmount + (int.Parse(item.Quantity)) * item1.Price;
                    var available = item1.Available_Quantity;
                    item1.Available_Quantity = available - int.Parse(item.Quantity);
                }
                totalAmount = totalAmount + int.Parse(item.Quantity);
            }
            Console.WriteLine("Your Total Amount for this purchase is {0}", totalAmount);
            Console.WriteLine(@"Pease check your amount and select the below options
1.Order
2.Cancel");
            var choice7 = int.Parse(Console.ReadLine());
            if (choice7 == 1)
            {
                Console.WriteLine("Your order is purchased successfully");
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Your order is cancelled successfully");
            }
        }
    }
}
