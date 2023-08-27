using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApplication_Model.Models
{
    public class Purchase
    {
        public int Purchase_Id { get; set; }
        public int CartId { get; set; }
        public int Purchase_Quantity { get; set; }
        public int purchasing_CustomerId { get; set; }
    }
}
