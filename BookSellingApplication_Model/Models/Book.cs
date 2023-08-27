using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApplication_Model.Models
{
    public class Book
    {
        public int Book_Id { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Price { get; set; }
        public int Available_Quantity { get; set; }
        public string Password { get; set; }

        public Category CatObj { get; set; }
        public int Category_ID { get; set; }

        public List<Cart> CartItems { get; set; }
    }
}
