using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApplication_Interfaces
{
    public interface iCustomer<T>
    {
        public bool Login(int customerId, string Password);
        public void Register(T customerToBeRegistered);
        public void Update(int Customer_Id, string Password);
    }
}
