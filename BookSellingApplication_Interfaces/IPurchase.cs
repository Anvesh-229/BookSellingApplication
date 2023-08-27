﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApplication_Interfaces
{
    public interface IPurchase<T>
    {
        public void PurchaseCartItems(int customerId);
        public void AddItems(int customerId);
        public void RemoveItems(int customerId);
    }
}
