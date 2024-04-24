using System;
namespace StudentAdmission;

class Program{
    public static void Main(string[] args)
    {
        //Creating csv file and storing student details
        FileHandling.CreateFiles();

        //Default Data Calling
        // Operations.DefaultData();
        FileHandling.ReadFromCSV();

        //calling main menu
        Operations.MainMenu();

        FileHandling.WriteCSV();
    }
}