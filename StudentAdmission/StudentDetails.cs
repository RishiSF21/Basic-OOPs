using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //Enum Declaration
    public enum Gender {Select, Male, Female, Others}
    public class StudentDetails
    {
        private static int s_studentID = 3000; //read only
        public string StudentID { get; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }

        //Constructor
        public StudentDetails(string name, string fatherName, DateTime dob, Gender gender, int physics, int chemistry, int maths){
            //Auto increment
            s_studentID++;
            StudentID = "SF"+s_studentID; 
            StudentName = name;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        } 

        public StudentDetails(string list){
            string[] values = list.Split(",");
            StudentID = values[0];
            s_studentID = int.Parse(values[0].Remove(0,2));
            StudentName = values[1];
            FatherName = values[2];
            DOB = DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            Gender = Enum.Parse<Gender>(values[4],true);
            Physics = int.Parse(values[5]);
            Chemistry = int.Parse(values[6]);
            Maths = int.Parse(values[7]);
        } 

        //methods
        public double Average(){
            int sum = Physics + Chemistry + Maths;
            double average = (double) sum/3;
            return average;
        }

        public bool CheckEligibility(double cutOff){
            if(Average() >= cutOff){
                return true;
            }
            return false;
        }

    }
}