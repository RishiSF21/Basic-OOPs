using System;
using System.Collections.Generic;
namespace PayrollApplication;

class Program{
    public static void Main(string[] args)
    {
        string option; 
        List <EmployeeDetails> employeeList = new List<EmployeeDetails>();
        
        do{
            
            Console.WriteLine("Welcome to Syncfusion Payroll Management Portal!!");
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
            EmployeeDetails employee01 = new EmployeeDetails();

            Console.Write("Enter Your Name : ");
            employee01.Name = Console.ReadLine();
            
            Console.Write("Role : ");
            employee01.Role = Console.ReadLine();
            
            Console.Write("Work Location : ");
            Location workLocation = Enum.Parse<Location>(Console.ReadLine(),true);
            //date of joining
            Console.Write("Team Name : ");
            employee01.Teamname = Console.ReadLine();

            Console.Write("Date of Joining : ");
            employee01.DOJ = DateTime.ParseExact(Console.ReadLine(),"dd/mm/yyyy",null);
           
            Console.Write("Number of Working Days for [current month] : ");
            EmployeeDetails.WorkingDays = int.Parse(Console.ReadLine());

            Console.Write("Leave Taken [in Days] : ");
            employee01.LeaveTaken = int.Parse(Console.ReadLine());

            Console.Write("Gender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);

            //adding employees to the list
            employeeList.Add(employee01);
            Console.Clear();
            Console.WriteLine("Registration Successfull!! :-)");
            foreach(EmployeeDetails emp in employeeList){
                Console.WriteLine();
                Console.WriteLine($"Employee ID : {emp.EmployeeID}\nName : {emp.Name}");
                Console.WriteLine();
            }
        }
        void Login(){
            Console.Clear();
            Console.WriteLine("->->->->->->->->->->->->->->->->->->");
            Console.Write("Enter Employee ID -> ");
            string eID = Console.ReadLine();
            bool isValid = false;
            foreach(EmployeeDetails emp in employeeList){
                string checkUser = emp.EmployeeID;
                if(eID==checkUser){
                    isValid = true;
                    Console.WriteLine("Login Successful...");
                    SubMenu();
                }
            }
            if(!isValid){
                Console.WriteLine("Invalid User ID");
            }
        }

        void SubMenu(){
            Console.Clear();
            Console.WriteLine("1. Calculate Salary\n2. Display Details\n3. Exit");
            string submenuOption = Console.ReadLine();
            switch(submenuOption){
                case "1":{
                    CalculateSalary();
                    break;
                }
                case "2":{
                    DisplayDetails();
                    break;
                }
                case "3":{
                    Exit();
                    break;
                }
            }
        }

        void CalculateSalary(){
            Console.WriteLine("Your salary for this month : "+EmployeeDetails.WorkingDays*500);
        }

        void DisplayDetails(){
            Console.Clear();
            foreach(EmployeeDetails emp in employeeList){
                Console.WriteLine($"Name : {emp.Name}\nEmployee ID : {emp.EmployeeID}\nRole : {emp.Role}\nTeam Name : {emp.Teamname}\nDate of Joining : {emp.DOJ}\nWorking Days : {EmployeeDetails.WorkingDays}\nLeave Taken : {emp.LeaveTaken}");
            }
            Console.WriteLine();
        }
        void Exit(){}
    }
}