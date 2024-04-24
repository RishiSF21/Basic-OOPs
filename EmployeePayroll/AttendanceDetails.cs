using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public class AttendanceDetails
    {
        private static int s_attendanceID = 1000; //Read-only field
        public string AttendanceID { get; }
        public string EmployeeID { get; }
        public DateOnly DateDetails { get; set; }
        public TimeOnly CheckInTime { get; set; }
        public TimeOnly CheckOutTime { get; set; }
        public TimeSpan HoursWorked { get; set; }

        public AttendanceDetails(string employeeID, DateOnly date, TimeOnly checkIn, TimeOnly checkOut, TimeSpan hours){
            s_attendanceID++; //Auto Incrementation
            AttendanceID = "AID"+s_attendanceID;
            EmployeeID = employeeID;
            DateDetails = date;
            CheckInTime = checkIn;
            CheckOutTime = checkOut;
            HoursWorked = hours;
        }
    }
}