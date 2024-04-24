using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace EmployeePayroll;

class Program{
    public static void Main(string[] args)
    {
        //calling the default method 
        Operations.DefaultData();

        //calling Main Menu
        Operations.MainMenu();

    }
}