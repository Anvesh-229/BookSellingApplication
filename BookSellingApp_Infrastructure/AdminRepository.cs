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
    public class AdminRepository<T> : IAdmin<T>
    {
        static ApplicationDbContext context = new ApplicationDbContext();

        public bool Login(int ID, string password)
        {
            var isUser = false;
            var AdminsDetails = context.Admins.ToList();
            foreach (var AdminDetail in AdminsDetails)
            {
                if (AdminDetail.Admin_Id == ID && AdminDetail.Password == password)
                {
                    Console.WriteLine("Login Succesgfull!");
                    isUser = true;
                }
            }
            return isUser;
        }
    }
}
