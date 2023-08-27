using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApplication_Interfaces
{
    public interface IPurchase<T>
    {
        public void PurchaseAllCartItems(int customerId);

        public void PurchseCartItemsSeperately(int PurchasingcartId,int PurchasingCustomerId);
        
    }
}
