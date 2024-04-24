using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public class CustomerDetails
    {
        private static int c_custID = 1001;
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string City { get; set; }
        public long PhoneNo { get; set; }
        public string MailID { get; set; }
        public double WalletBalance { get; set; }
        public CustomerDetails(string name, string city, long phone, string mail, double balance){
            c_custID++;
            CustomerID = "CID"+c_custID;
            CustomerName = name;
            City = city;
            PhoneNo = phone;
            MailID = mail;
            WalletBalance = balance;
        }
    }
}