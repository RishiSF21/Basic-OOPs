using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using EBBillApplication;
namespace EBBillCalculation;

class Program{
    public static void Main(string[] args)
    {
        string option; 
        List <BillDetails> billsList = new List<BillDetails>();
        
        do{
            
            Console.WriteLine("Please select any option\n1. Register\n2. Login\n3. Exit\n");
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
            BillDetails bills = new BillDetails();

            Console.Write("Enter Username : ");
            bills.UserName = Console.ReadLine();
            
            Console.Write("Phone No. : ");
            bills.Phone = Convert.ToInt64(Console.ReadLine());
            
            Console.Write("Mail ID : ");
            bills.MailID = Console.ReadLine();

            //adding customers to the list
            billsList.Add(bills);
            Console.Clear();
            Console.WriteLine("Registration Successfull!! :-)");
            Console.WriteLine();
            Console.WriteLine($"Meter ID : {bills.MeterID}\nCustomer Name : {bills.UserName}");
            Console.WriteLine();
        }

        void Login(){
            Console.Clear();
            Console.WriteLine("->->->->->->->->->->->->->->->->->->");
            Console.Write("Meter ID -> ");
            string mID = Console.ReadLine();
            bool isValid = false;
            foreach(BillDetails eb in billsList){
                string checkUser = eb.MeterID;
                if(mID==checkUser){
                    isValid = true;
                    Console.WriteLine("Login Successful !!");
                    SubMenu(mID);
                }
            }
            if(!isValid){
                Console.WriteLine("Invalid Meter ID");
            }
            Console.WriteLine();
        }

        void SubMenu(string mID){
            Console.Clear();
            Console.WriteLine("1. Calculate Bill Amount\n2. Display Details\n3. Exit");
            string submenuOption = Console.ReadLine();
            switch(submenuOption){
                case "1":{
                    CalculateAmount(mID);
                    break;
                }
                case "2":{
                    DisplayDetails(mID);
                    break;
                }
                case "3":{
                    Exit();
                    break;
                }
            }
            Console.WriteLine();
        }

        void CalculateAmount(string mID){
            Console.Write("Enter Unit -> ");
            int unitUsed = int.Parse(Console.ReadLine());
            int price = unitUsed * 5;
            Console.Clear();
            Console.WriteLine("<-- Your Bill Generated -->");
            foreach(BillDetails eb in billsList){
                if(eb.MeterID==mID){
                    Console.Write($"Name : {eb.UserName}\nMeter ID : {eb.MeterID}\nUnits : {unitUsed}\nBill Amount : {price}\n");
                    break;
                }
            }
            //SubMenu(mID);
            Console.WriteLine();
        }

        void DisplayDetails(string mID){
            Console.Clear();
            Console.WriteLine("<-- Customer Details -->");
            foreach(BillDetails eb in billsList){
                if(eb.MeterID==mID){
                    Console.Write($"Name : {eb.UserName}\nMeter ID : {eb.MeterID}\nPhone No : {eb.Phone}\nMail ID : {eb.MailID}\n");
                    break;
                }
            }
            Console.WriteLine();
            //SubMenu(mID);
        }
        void Exit(){}
    }
}