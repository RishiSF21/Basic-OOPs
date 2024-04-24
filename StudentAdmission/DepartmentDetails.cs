using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class DepartmentDetails
    {
        // a.	DepartmentID – (AutoIncrement - DID101)
        // b.	DepartmentName
        // c.	NumberOfSeats

        private static int s_departmentID = 100; //read only field
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int NumberOfSeats { get; set; }

        //Constructor
        public DepartmentDetails(string deptName, int numberOfSeats){
            s_departmentID++;
            DepartmentID = "DID"+s_departmentID;
            DepartmentName = deptName;
            NumberOfSeats = numberOfSeats;
        }

    }
}