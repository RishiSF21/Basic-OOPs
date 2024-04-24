using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //Static class
    public static class Operations
    {
        //Local or Global object creation
        static StudentDetails currentLoggedInStudent;
        //creating lists
        public static List<StudentDetails> studentList = new List<StudentDetails>();
        static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

        //Main Menu
        public static void MainMenu(){
            Console.Clear();
            Console.WriteLine("<-------- Welcome to Syncfusion College -------->");
            //Need to show main menu
            
            int mainOption;
            do{
                Console.WriteLine("Main Menu\n1. Registration\n2. Login\n3. Departmentwise Seat Availability\n4. Exit");
                //Need to get an input from user
                Console.WriteLine("Select an option: ");
                mainOption = int.Parse(Console.ReadLine());
                //Need to create mainmenu structure
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("<-------- Student Registration -------->");
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("<-------- Student Login -------->");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("<-------- Seat Availability -------->");
                            SeatAvailability();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("<-------- Application Exited Successfully -------->");
                            Exit();
                            break;
                        }
                }
                //Need to iterate untill the option is exit.
            } while (mainOption != 4);
        } //main menu ends

        //Student Registration
        public static void Registration(){
            //Need to get required details
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your Father name: ");
            string fatherName = Console.ReadLine();

            Console.Write("Enter DOB: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(),"dd/mm/yyyy",null);

            Console.Write("Enter your gender [Male/Female]: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(),true);

            Console.Write("Enter your Physics mark: ");
            int physics = int.Parse(Console.ReadLine());

            Console.Write("Enter your Chemistry mark: ");
            int chemistry = int.Parse(Console.ReadLine());

            Console.Write("Enter your Maths mark: ");
            int maths = int.Parse(Console.ReadLine());
            //need to create an object
            StudentDetails student = new StudentDetails(name,fatherName,dob,gender,physics,chemistry,maths);
            //need to add in the list
            studentList.Add(student);
            //Need to display the confirmation message and ID
            Console.WriteLine("<-------- Student Registration Successfull -------->\nStudent ID : "+student.StudentID);
        }//student registration ends
        //student login
        public static void Login(){
            //Need to get ID as input
            Console.Clear();
            Console.Write("Enter your Student ID -> ");
            string loginID = Console.ReadLine().ToUpper();
            //Validate ID 
            bool isFound = true;
            foreach(StudentDetails student in studentList)
            {
                if(loginID.Equals(student.StudentID))
                {
                    isFound = false;
                    //Assigning current user to global variable
                    currentLoggedInStudent = student;
                    Console.WriteLine("****** Login Successfull ******");
                    SubMenu();
                    break;
                }
            }
            //If not found -> display Invalid ID
            if(isFound){
                Console.WriteLine("Invalid Student ID");
            }
        }//student login ends
        //Submenu
        public static void SubMenu()
        {
            string subChoice = "yes";
            do{
                Console.WriteLine("******** SubMenu ********");
                //Sub menu options
                Console.WriteLine("Select an option\n1. Check Eligibility\n2. Show Details\n3. Take Admission\n4. Cancel Admission\n5. Show Admission Details\n6. Exit");
                //Getting user options
                Console.Write("Enter your option - ");
                int subOption = int.Parse(Console.ReadLine());
                //Need to create sub menu structure
                switch (subOption)
                {
                    case 1:
                        {
                            Console.WriteLine("<-------- Check Eligibility -------->");
                            CheckEligibility();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("<-------- Show Details -------->");
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("<-------- Take Admission -------->");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("<-------- Cancel Admission -------->");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("<-------- Admission Details -------->");
                            AdmissionDetails();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("<-------- Taking Back to Mainmenu -------->");
                            subChoice = "no";
                            //Exit();
                            break;
                        }
                }

            }while(subChoice == "yes");
        }

        public static void CheckEligibility(){
            //Get cut off value as input
            Console.WriteLine("Enter Cutoff value: ");
            double cutOff = Convert.ToDouble(Console.ReadLine());
            //check eligible or not
             if(currentLoggedInStudent.CheckEligibility(cutOff))
             {
                Console.WriteLine("You are eligible for admission !!");
             }
             else 
             {
                Console.WriteLine("Not Eligible for admission");
             }
        }//CheckEligibility ends

        public static void ShowDetails(){
            //Need to show current student details
            Console.Clear();
            Console.WriteLine("| Student ID | Student Name | Father Name | DOB | Gender | Physics | Chemistry | Maths");
            Console.WriteLine($"| {currentLoggedInStudent.StudentID} | {currentLoggedInStudent.StudentName} | {currentLoggedInStudent.FatherName} | {currentLoggedInStudent.DOB} | {currentLoggedInStudent.Gender} | {currentLoggedInStudent.Physics} | {currentLoggedInStudent.Chemistry} | {currentLoggedInStudent.Maths}");
        }
        public static void TakeAdmission(){
            //Need to show available department details
            SeatAvailability();
            //Get dept ID from user
            Console.Write("Select anyone Department ID -> ");
            string departmetID = Console.ReadLine().ToUpper();
            //Check the Id is present or not
            bool isValid = true;
            foreach(DepartmentDetails department in departmentList){
                if(departmetID.Equals(department.DepartmentID))
                {
                    isValid = false;
                    //check the student is eligible or not
                    if(currentLoggedInStudent.CheckEligibility(75.0))
                    {
                        //check the seat availability
                        if(department.NumberOfSeats > 0)
                        {
                            //check student already taken any admission
                            bool isAdmitted = true;
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.Status.Equals(AdmissionStatus.Admitted))
                                {
                                    isAdmitted = false;
                                    Console.WriteLine("Admission took already");
                                    break;
                                }
                            }
                            if(isAdmitted)
                            {
                                //create admission object
                                AdmissionDetails admissionTaken = new AdmissionDetails(currentLoggedInStudent.StudentID, department.DepartmentID, DateTime.Now, AdmissionStatus.Admitted);
                                //Reduce seat count
                                department.NumberOfSeats--;
                                //Add to the admission list
                                admissionList.Add(admissionTaken);
                                //Display admission successfull message.
                                Console.WriteLine($"You have taken admission successfully.\nAdmission ID - {admissionTaken.AdmissionID}");
                            }
                            
                        }
                        else{
                            Console.WriteLine("Seats are not available");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You're not eligible due to low Cutoff mark");
                    }
                    break;
                }
            }
            if(isValid){
                Console.WriteLine("Invalid ID or ID not present");
            }
            
        }//Take admission ends
        public static void CancelAdmission()
        {
            //Check the student is taken any admission
            bool flag = true;
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID) && admission.Status.Equals(AdmissionStatus.Admitted))
                {
                    //cancel the admission if found
                    admission.Status = AdmissionStatus.Cancelled;
                    //Return the seat to the department
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admission.DepartmentID.Equals(department.DepartmentID))
                        {
                            department.NumberOfSeats++;
                            break;
                        }
                    }
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("You have not admission to cancel");
            }
        }//CancelAdmission ends
        public static void AdmissionDetails(){
            //Need to show current logged in student's admission details
            Console.WriteLine("| Admission ID | Student ID | Department ID | Admission Date | Admission Status");
            foreach(AdmissionDetails admission in admissionList){
                if(currentLoggedInStudent.StudentID.Equals(admission.StudentID)) 
                {
                    Console.WriteLine($"|{admission.AdmissionID}|{admission.StudentID}|{admission.DepartmentID}|{admission.AdmissionDate}|{admission.Status}");
                }
            }
            Console.WriteLine();
        }
        public static void SeatAvailability(){
            Console.WriteLine("Department ID | Department Name | Number of Seats");
            foreach(DepartmentDetails department in departmentList){
                Console.WriteLine($"| {department.DepartmentID}\t | {department.DepartmentName}\t\t | {department.NumberOfSeats} ");
            }
            Console.WriteLine();
        }//seat availability ends

        //Exit method
        public static void Exit(){

        }//exit application

        //Adding Default Data
        public static void DefaultData(){
            StudentDetails student1 = new StudentDetails("Rishi", "Padhu", new DateTime(2001,01,21),Gender.Male,98,89,78);
            StudentDetails student2 = new StudentDetails("Paru", "Raj Kumar", new DateTime(2000,12,26),Gender.Female,100,89,98);
            studentList.AddRange(new List<StudentDetails>(){student1,student2});

            DepartmentDetails department1 = new DepartmentDetails("EEE",29);
            DepartmentDetails department2 = new DepartmentDetails("CSE",29);
            DepartmentDetails department3 = new DepartmentDetails("MECH",30);
            DepartmentDetails department4 = new DepartmentDetails("ECE",30);
            departmentList.AddRange(new List<DepartmentDetails>(){department1,department2,department3,department4});

            AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID,department1.DepartmentID,new DateTime(2022,05,11),AdmissionStatus.Admitted);
            AdmissionDetails admission2 = new AdmissionDetails(student2.StudentID,student2.StudentID,new DateTime(2022,05,12),AdmissionStatus.Admitted);
            admissionList.AddRange(new List<AdmissionDetails>(){admission1,admission2});
  
        }
    }
}