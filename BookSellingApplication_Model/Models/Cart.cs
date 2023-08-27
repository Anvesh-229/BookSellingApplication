using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApplication_Model.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Book_Id { get; set; }
        public string Title { get; set; }
        public string Quantity { get; set; }
        public int CustomerId { get; set; }
        public Book BookObj { get; set; }
        public Customer CustomerObj { get; set; }
        //public List<purchase> purchsasecart { get; set; }
    }
}
