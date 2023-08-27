using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApplication_Interfaces
{
    public interface IAdmin<T>
    {
        public bool Login(int Id, string password);
    }
}
