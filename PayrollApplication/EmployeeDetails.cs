using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollApplication
{   
    public enum Location {Select, EymardComplex, MathuraTowers}
    public enum Gender {Select, Male, Female, Other}
    public class EmployeeDetails
    {
        public static int WorkingDays { get; set; }
        private static int e_employeeID = 1001;
        public string EmployeeID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public  Location WorkLocation { get; set; }
        public string Teamname { get; set; }
        public DateTime DOJ { get; set; }
        public int LeaveTaken { get; set; }
        public Gender Gender { get; set; }

        public EmployeeDetails(){
            e_employeeID++;
            EmployeeID = "SF"+e_employeeID;
        }
    }
}