using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public class ProductDetails
    {
        private static int p_prodID = 100;
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int AvailableStock { get; set; }
        public double PricePerQty { get; set; }
        public int ShippingDuration { get; set; }

        public ProductDetails(){
            p_prodID++;
            ProductID = "PID"+p_prodID;
        }
    }
}