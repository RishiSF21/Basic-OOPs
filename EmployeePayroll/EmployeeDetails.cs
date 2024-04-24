using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    //Enum declarations
    public enum Location {Select, Eymard, Madhura, Karuna}
    public enum Gender {Select, Male, Female, Other}
    /// <summary>
    /// This class is for accessing employee info
    /// </summary>
    public class EmployeeDetails
    {
        private static int s_employeeID = 3000; //Read-only field
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public DateOnly DOB { get; set; }
        public long Mobile { get; set; }
        public Gender Gender { get; set; }
        public  Location Branch { get; set; }
        public string Team { get; set; }

        public EmployeeDetails(string name, DateOnly dob, long mobile, Gender gender, Location branch, string teamName){
            s_employeeID++;
            EmployeeID = "SF"+s_employeeID;
            EmployeeName = name;
            DOB = dob;
            Mobile = mobile;
            Gender = gender;
            Branch = branch;
            Team = teamName;
        }
    }
}