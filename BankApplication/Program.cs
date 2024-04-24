using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace BankApplication;

class Program {
    public static void Main(string[] args)
    {
        string option; 
        List <CustomerDetails> customerList = new List<CustomerDetails>();

        do{
            
            Console.WriteLine("Welcome to HDFC!!");
            Console.WriteLine("How can I help you..\n1. Register\n2. Login\n3. Exit\n");
            Console.WriteLine("--------------------------------");
            option = Console.ReadLine();
            
            switch(option){
                case "1":{
                    Register();
                    break;
                }
                case "2":{
                    Login();
                    break;
                }
                case "3":{
                    Exit();
                    break;
                }
                default:{
                    Console.WriteLine("Invalid input.. Please Try Again..");
                    break;
                }
        }
        }while(option!="3");

        void Register(){
            CustomerDetails customer01 = new CustomerDetails();
            //customer name
            Console.Write("Enter Your Name : ");
            customer01.CustomerName = Console.ReadLine();
            //mobile number
            Console.Write("Enter Your Mobile Number : ");
            customer01.PhoneNo = Convert.ToInt64(Console.ReadLine());
            //mail id
            Console.Write("Enter Your Mail ID : ");
            customer01.MailId = Console.ReadLine();
            //date of birth
            Console.Write("Enter Your DOB : ");
            customer01.Dob = DateTime.ParseExact(Console.ReadLine(),"dd/mm/yyyy",null);
            //Balance
            // Console.Write("Enter Amount : ");
            // customer01.Balance = Convert.ToDouble(Console.ReadLine());

            //adding customers to the list
            customerList.Add(customer01);
            Console.Clear();
            Console.WriteLine("Registration Successfull!! :-)");
            // foreach(CustomerDetails cust in customerList){
            //     Console.WriteLine();
            //     Console.WriteLine($"Your Customer ID : {cust.CustomerID}\nName : {cust.CustomerName}");
            //     Console.WriteLine();
            // }
            Console.WriteLine($"Your Customer ID : {customer01.CustomerID}\nName : {customer01.CustomerName}");
        }

        void Login(){
            Console.Clear();
            Console.WriteLine("->->->->->->->->->->->->->->->->->->");
            Console.Write("Enter Customer ID -> ");
            string cID = Console.ReadLine();
            bool isValid = false;
            foreach(CustomerDetails cust in customerList){
                string checkUser = cust.CustomerID;
                if(cID==checkUser){
                    isValid = true;
                    Console.WriteLine("Login Successful...");
                    SubMenu();
                }
            }
            if(!isValid){
                Console.WriteLine("Invalid Customer ID..Please try again..");
            }

        }

        void SubMenu(){
            Console.Clear();
            Console.WriteLine("1. Deposit\n2. Withdraw\n3. Check Balance\n4. Exit");
            string submenuOption = Console.ReadLine();
            switch(submenuOption){
                case "1":{
                    Deposit();
                    break;
                }
                case "2":{
                    Withdraw();
                    break;
                }
                case "3":{
                    CheckBalance();
                    break;
                }
                case "4":{
                    Exit();
                    break;
                }
            }
        }

        void Deposit(){
            Console.Write("Enter Deposit Amount - ");
            double depositAmt = Convert.ToDouble(Console.ReadLine());
            CustomerDetails.Balance += depositAmt;
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
            Console.WriteLine(depositAmt+" credited to your balance");
            Console.WriteLine();
            Console.WriteLine("Current Balance - "+CustomerDetails.Balance);
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
            Exit();
        }

        void Withdraw(){
            Console.Write("Enter Withdraw Amount - ");
            double withdrawAmt = Convert.ToDouble(Console.ReadLine());
            CustomerDetails.Balance -= withdrawAmt;
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
            Console.WriteLine("Cash withdraw successfull !!");
            Console.WriteLine();
            Console.WriteLine("Current Balance - "+CustomerDetails.Balance);
            Console.WriteLine("----------------------------------");
            Console.WriteLine();
            Exit();
        }
        
        void CheckBalance(){
            Console.Clear();
            Console.WriteLine("Current Balance -"+CustomerDetails.Balance);
        }

        void Exit(){
            
        }
        
    }
}