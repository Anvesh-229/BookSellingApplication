using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApplication_Model.Models
{
    public class Customer
    {
        public int Customer_Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public List<Cart> cartCustomers { get; set; }
    }
}
