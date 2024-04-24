using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePayroll
{
    public static class Operations
    {
        //Declaring global variable to hold the currently logged in user data
        static EmployeeDetails currentLoggedInEmployee;
        //Employee List
        static List<EmployeeDetails> employeeList = new List<EmployeeDetails>();

        //Attendance List
        static List<AttendanceDetails> attendanceList = new List<AttendanceDetails>();

        //Main Menu
        public static void MainMenu()
        {
            //Welcome User
            Console.WriteLine("Welcome to Employee Payroll Management");
            Console.WriteLine("<---------------------Main Menu --------------------->");
            int mainMenuOption;
            do
            {
                //Display main menu
                Console.Write("1. Employee Registration\n2. Employee Login\n3. Exit\nChoose any option to proceed : ");
                //Ask option to proceed
                mainMenuOption = int.Parse(Console.ReadLine());
                switch (mainMenuOption)
                {
                    case 1:
                        {
                            //calling Registration method
                            Console.WriteLine("<---------- Employee Registration ---------->");
                            Register();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("<---------- Employee Login ---------->");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("<---------- Application Exited Successfully ---------->");
                            //Exit();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid input.. Please Try Again..");
                            break;
                        }
                }
            } while (mainMenuOption != 3);
        }//MainMenu Ends

        //Register Method
        public static void Register()
        {
            //Get required details
            Console.Write("Enter Your Name : ");
            string name = Console.ReadLine();

            Console.Write("Date of Birth : ");
            DateOnly dob = DateOnly.ParseExact(Console.ReadLine(), "dd/mm/yyyy", null);

            Console.Write("Mobile Number : ");
            long mobile = Convert.ToInt64(Console.ReadLine());

            Console.Write("Gender : [Male / Female / Others] ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

            Console.Write("Branch : [Eymard / Madhura / Karuna] ");
            Location branch = Enum.Parse<Location>(Console.ReadLine(), true);

            Console.Write("Team Name : ");
            string teamName = Console.ReadLine();

            //create object for employee class
            EmployeeDetails employee1 = new EmployeeDetails(name, dob, mobile, gender, branch, teamName);
            //Add it to employeeList
            employeeList.Add(employee1);
            Console.Clear();
            Console.WriteLine($"Employee registration successfulluy completed\nYour Employee ID -> {employee1.EmployeeID}");
            Console.WriteLine();
        }

        //Login Method
        public static void Login()
        {
            Console.Clear();
            //Ask Employee ID
            Console.Write("Employee ID -> ");
            string loginID = Console.ReadLine().ToUpper();
            //Validate EmployeeID if it's correct then show submenu options
            bool isValid = true;
            foreach (EmployeeDetails employee in employeeList)
            {
                if (loginID.Equals(employee.EmployeeID))
                {
                    isValid = false;
                    currentLoggedInEmployee = employee;
                    Console.WriteLine("<------ Login Successful !! ------>");
                    SubMenu();
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine("Invalid Employee ID");
            }

        }//Login ends

        public static void SubMenu()
        {
            //Display Submenu and ask the user to select any option
            Console.WriteLine("<--------------- Sub-Menu --------------->\n1. Add Attendance\n2. Display Details\n3. Calculate Salary\n4. Exit");
            int submenuOption = int.Parse(Console.ReadLine());
            //do{
            switch (submenuOption)
            {
                case 1:
                    {
                        Console.WriteLine("********** Add Attendance **********");
                        AddAttendance();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("********** Display Employee Details **********");
                        DisplayDetails();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("********** Calculate Salary **********");
                        CalculateSalary();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("********** Taking Back To Mainmenu **********");
                        break;
                    }
            }
            // } while (submenuOption != 4);
        }//Submenu Ends

        public static void AddAttendance()
        {
            Console.Write("1. Add Check-In/Check-Out\n2. Back To SubMenu\n");
            string subOption = Console.ReadLine();

            switch (subOption)
            {
                case "1":
                    {
                        Console.WriteLine("<-------------------- Check In Menu -------------------->");
                        CheckIn();
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("<-------------------- Taking Back to Previous SubMenu -------------------->");
                        SubMenu();
                        break;
                    }
            }
        }//Add Attendance Ends

        //CheckIn Method
        static TimeOnly checkInTime;
        public static void CheckIn()
        {
            //Console.Clear();
            Console.Write("Enter Date of the day for Check-in time - [dd/mm/yyyy] : ");
            DateOnly checkInDate = DateOnly.ParseExact(Console.ReadLine(), "dd/mm/yyyy");
            Console.Write("Enter Check-In Time {h:mm tt} / {07:00 am} - ");
            checkInTime = TimeOnly.ParseExact(Console.ReadLine(), "h:mm tt", null, System.Globalization.DateTimeStyles.None);
            Console.Write("Do you want to Check-out [yes/no] ");
            string askCheckOut = Console.ReadLine();
            if (askCheckOut.ToLower() == "yes")
            {
                //Get Check out Date and time
                Console.Write("Enter Date of the day for Check-out time - [dd/mm/yyyy] : ");
                DateOnly checkOutDate = DateOnly.ParseExact(Console.ReadLine(), "dd/mm/yyyy");
                Console.Write("Enter Check-Out Time {h:mm tt} - ");
                var checkOutTime = TimeOnly.ParseExact(Console.ReadLine(), "h:mm tt", null, System.Globalization.DateTimeStyles.None);
                //Calculate Total Hours Wprked
                TimeSpan hoursWorked = checkOutTime - checkInTime;
                Console.WriteLine($"Check-in and Checkout Successful and today {checkOutDate} you have worked for {hoursWorked.Hours} Hours");
                //creating object for AttendanceDetails
                AttendanceDetails attendance1 = new AttendanceDetails(currentLoggedInEmployee.EmployeeID, checkOutDate, checkInTime, checkOutTime, hoursWorked);
                //adding attendance data to the list
                attendanceList.Add(attendance1);
                AddAttendance();
            }
            // else{
            //     SubMenu();
            // }
        }//CheckIn ends

        public static void DisplayDetails()
        {
            Console.WriteLine("| Employee Name | Employee ID | DoB | Mobile No | Gender | Branch | Team |");
            Console.WriteLine($"| {currentLoggedInEmployee.EmployeeName} | {currentLoggedInEmployee.EmployeeID} | {currentLoggedInEmployee.DOB} | {currentLoggedInEmployee.Mobile} | {currentLoggedInEmployee.Gender} | {currentLoggedInEmployee.Branch} | {currentLoggedInEmployee.Team} |");
            Console.WriteLine();
            SubMenu();
        }//DisplayDetails Ends

        public static void CalculateSalary()
        {
            //Show the attendance details list of current users in the current month
            Console.WriteLine($"| {"Attendance ID",-10} | {"Employee ID",-10} | {"Date",-10} | {"Check In",-10} | {"Check Out",-10} | {"Hours Worked",-10} |");
            foreach (AttendanceDetails attendance in attendanceList)
            {
                if (currentLoggedInEmployee.EmployeeID.Equals(attendance.EmployeeID))
                {
                    Console.WriteLine($"| {attendance.AttendanceID,-10} | {attendance.EmployeeID,-10} | {attendance.DateDetails,-10} | {attendance.CheckInTime,-10} | {attendance.CheckOutTime,-10} | {attendance.HoursWorked,-10} |");
                }
            }
            Console.WriteLine();
            //calculate number of hours worked for current month
            int totalWorkedHoures = 0;
            int countDays= 0;
            foreach (AttendanceDetails attendance in attendanceList)
            {
                if (currentLoggedInEmployee.EmployeeID.Equals(attendance.EmployeeID))
                {
                    //TimeSpan totalHours = 0:00 am;
                    Console.Write("Enter a month for which you want to calculate salary - [1 to 12] : ");
                    int getMonth = int.Parse(Console.ReadLine());
                    int monthInNumber = attendance.DateDetails.Month;
                    if(monthInNumber.Equals(getMonth))
                    {
                        if(attendance.HoursWorked.Hours >= 8)
                        {
                            totalWorkedHoures += attendance.HoursWorked.Hours;
                            countDays++;
                        }
                    }
                }
            }
            //working hr should be 8 and salary per day is 500
            //Display Total salary for the current month
            Console.WriteLine($"\nSalary for current month -> Rs.{countDays*500}");
        }
        public static void DefaultData()
        {
            //creating objects for EmployeeDetails
            EmployeeDetails employee01 = new EmployeeDetails("Rishi", new DateOnly(2001, 01, 21), 7397688707, Gender.Female, Location.Madhura, "Developer");
            employeeList.Add(employee01);

            //creating objects for AttendanceDetails class
            AttendanceDetails employeeAttendance1 = new AttendanceDetails(employee01.EmployeeID, new DateOnly(2022, 05, 15), new TimeOnly(09, 00), new TimeOnly(6, 10), new TimeSpan(8, 00, 40));
            attendanceList.Add(employeeAttendance1);

            //Console.WriteLine(employeeAttendance1.CheckInTime+" "+employeeAttendance1.HoursWorked);
        }
    }
}