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
    public class CustomerRepository<T> : iCustomer<T> where T : Customer
    {
        static ApplicationDbContext context = new ApplicationDbContext();
        public bool Login(int customerId, string Password)
        {
            var isUser = false;
            var CustomersLoginDetails = context.Customers.ToList();
            foreach (var customerDetails in CustomersLoginDetails)
            {
                if (customerDetails.Customer_Id == customerId && customerDetails.Password == Password)
                {
                    Console.WriteLine("Login Succesgfull!");
                    isUser = true;
                }
            }
            return isUser;
        }

        public void Register(T customerToBeRegistered)
        {
            context.Customers.Add(customerToBeRegistered);
            context.SaveChanges();
        }

        public void Update(int Category_Id, string Password)
        {
            var customersList = context.Customers.ToList();
            var customer_details = context.Customers.Find(Category_Id);
            customer_details.Password = Password;
            context.SaveChanges();
        }
    }
}
