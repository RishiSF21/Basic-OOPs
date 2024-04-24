using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApplication
{
    public enum Gender {Select, Male, Female, Other};
    public class CustomerDetails
    {
        public static double Balance {get; set;}
        private static int c_customerID = 4633;
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        //public double Balance { get; set; }
        public Gender gender { get; set; }
        public long PhoneNo {get ; set;}
        public string MailId { get; set; }
        public DateTime Dob { get; set; }

        public CustomerDetails(){
            c_customerID++;
            CustomerID = "SF"+c_customerID;
            Balance = 21500.00;
        }
    }
}