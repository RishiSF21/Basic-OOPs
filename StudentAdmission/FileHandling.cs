using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class FileHandling
    {
        public static void CreateFiles()
        {
            //Creating CollegeDetails Folder
            if(!Directory.Exists("CollegeDetails"))
            {
                Directory.CreateDirectory("CollegeDetails");
            }

            //Creating Student Details File
            if(!File.Exists("CollegeDetails/StudentDetails.csv"))
            {
                File.Create("CollegeDetails/StudentDetails.csv").Close();
            }
        }

        public static void WriteCSV()
        {
            string[] studentsDetails = new string[Operations.studentList.Count];
            for (int i = 0; i < Operations.studentList.Count; i++)
            {
                studentsDetails[i] = Operations.studentList[i].StudentID+","+Operations.studentList[i].StudentName+","+Operations.studentList[i].FatherName+","+Operations.studentList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.studentList[i].Gender+","+Operations.studentList[i].Physics+","+Operations.studentList[i].Chemistry+","+Operations.studentList[i].Maths;
            }
            File.WriteAllLines("CollegeDetails/StudentDetails.csv",studentsDetails);
        }

        public static void ReadFromCSV()
        {
            string[] students = File.ReadAllLines("CollegeDetails/StudentDetails.csv");
            foreach (string line in students)
            {
                StudentDetails student1 = new StudentDetails(line);
                Operations.studentList.Add(student1);
            }
        }

    }
}