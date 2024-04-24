using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public enum OrderStatus {Default, Ordered, Cancelled}
    public class OrderDetails
    {
        private static int s_orderID = 1000;
        public string OrderID { get;  }
        public string CustomerID { get;  }
        public string ProductID { get; }
        public double TotalPrice { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Quantity { get; set; }
        public OrderStatus Status { get; set; }

        public OrderDetails(string cID, string proID, double price, DateTime dop, int qty, OrderStatus status)
        {
            s_orderID++;
            OrderID = "OID" + s_orderID;
            CustomerID = cID;
            ProductID = proID;
            TotalPrice = price;
            PurchaseDate = dop;
            Quantity = qty;
            Status = status;
        }
    }
}