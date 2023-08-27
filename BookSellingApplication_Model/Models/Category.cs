using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApplication_Model.Models
{
    public class Category
    {
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }

        public List<Book> Books_C { get; set; }
    }
}
