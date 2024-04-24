using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //Enum declaration
    public enum AdmissionStatus {Select, Admitted, Cancelled}
    public class AdmissionDetails
    {
        // a.	AdmissionID – (Auto Increment ID - AID1001)
        // b.	StudentID
        // c.	DepartmentID
        // d.	AdmissionDate
        // e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)
        private static int s_admissionID = 1000;
        public string AdmissionID { get; }
        public string StudentID { get; set; }
        public string DepartmentID { get; set; }
        public DateTime AdmissionDate { get; set; }
        public AdmissionStatus Status { get; set; }

        public AdmissionDetails(string studentID, string departmentID, DateTime admissionDate, AdmissionStatus status){
            //Auto Incrementation
            s_admissionID++;
            AdmissionID = "AID"+s_admissionID;
            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            Status = status;
        }
   
    }
}