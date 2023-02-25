namespace FinalsPart4;
class Program
{
    static int NumOption;
    static char CharOption;
    static List<string> Grades = new List<string>() { "Subject 1 ----- 0.00 ----- Unknown",
                                                      "Subject 2 ----- 0.00 ----- Unknown",
                                                      "Subject 3 ----- 0.00 ----- Unknown",
                                                      "Subject 4 ----- 0.00 ----- Unknown",
                                                      "Subject 5 ----- 0.00 ----- Unknown" };
    static List<string> viewTeacherChoices = new List<string>() {"[0] - Announcement",
                                                                 "[1] - Profile",
                                                                 "[2] - Virtual Classroom",
                                                                 "[3] - Students",
                                                                 "[4] - Grades",
                                                                 "[5] - Log out"};
    static List<string> viewStudentChoices = new List<string>() {"[0] - Announcement",
                                                                 "[1] - Profile",
                                                                 "[2] - Virtual Classroom",
                                                                 "[3] - Grades",
                                                                 "[4] - Log out"};
    static List<string> viewTeacherSubject = new List<string>() {"[1] - Subject 1"};
    static List<string> viewTeacherStudent = new List<string>() {"Student 1"};
    static List<string> Announcement = new List<string>(); //will list all the announcement created by teacher
    static List<string> TeacherAddActivity = new List<string>(); //will list all the activity created by teacher
    static List<double> TeacherEditGrades = new List<double>(); //The teacher can encode and edit grade, can also see the history of user's edited grade

    static void Main(string[] args)
    {
        MainLogo();
        Console.WriteLine("\nHello user! \nPlease enter if you're a student or teacher..");
        Console.WriteLine("\n[1] - Teacher");
        Console.WriteLine("[2] - Student");
        Console.Write(">> input: ");
        NumOption = Convert.ToInt32(Console.ReadLine());
        switch(NumOption)
        {
            case 1://for teacher
                MainLogo();
                if(getUserLogin())
                {
                    MainLogo();
                    getTeacherChoices();
                }
                else
                {
                    Console.WriteLine("Log in failed, please try again later");
                }
                break;
            case 2://for student
                MainLogo();
                if (getUserLogin())
                {
                    //code to menu
                    MainLogo();
                    getStudentChoices();
                }
                else
                {
                    Console.WriteLine("Log in failed, please try again later");
                }
                break;
            default:
                Console.WriteLine("Please enter the correct number");
                break;
        }
    }
    static void getTeacherChoices() //teacher access
    {
        Console.WriteLine("Welcome to Virtual Classroom!!!");

        Console.WriteLine("\n-----LIST-----");
        foreach (var view in viewTeacherChoices)
        {
            Console.WriteLine(view);
        }
        Console.Write("\n>> please enter the number you desire to input: ");
        NumOption = Convert.ToInt32(Console.ReadLine());

        switch (NumOption)
        {
            case 0:
                getAnnouncement();
                //do add announcement
                Console.WriteLine("Do you want to announce something?[y] or [n]");
                Console.Write(">> input: ");
                CharOption = Convert.ToChar(Console.ReadLine());
                if(CharOption == 'y')
                {
                    Console.WriteLine("\nPlease type something..\n");
                    Announcement.Add(Console.ReadLine());
                    Console.WriteLine("Successfully added...");
                }
                else if(CharOption == 'n')
                {
                    Console.WriteLine("\nThanks for answering..");
                    Console.WriteLine("No announcement added..\n");
                }
                UserReturnforTeachers();
                
                break;
            case 1:
                Console.WriteLine("\n_____PROFILE_____");
                Console.WriteLine("Teacher Email: admin");
                Console.WriteLine("Teacher Password: admin123");
                Console.WriteLine("Position: Teacher 1");
                Console.WriteLine("Complete Name: Unknown");
                //erReturnforStudent();
                UserReturnforTeachers();
                break;
            case 2:
                Console.WriteLine("\n_____VIRTUAL CLASSROOM_____");
                Console.WriteLine(">> please enter your subject: \n");
                foreach (var view in viewTeacherSubject)
                {
                    Console.WriteLine(view);
                }
                Console.Write(">> input: ");
                NumOption = Convert.ToInt32(Console.ReadLine());

                //note: use if statement then do add homework
                if (NumOption == 1)
                {
                    Console.WriteLine("\nNo Homework/Quiz for today...\n");

                    foreach (var view in TeacherAddActivity)
                    {
                        Console.WriteLine(view);
                    }

                    Console.WriteLine("\nDo you want to add one?[y] or[n]\n");
                    Console.Write(">> input: ");
                    CharOption = Convert.ToChar(Console.ReadLine());
                    if(CharOption == 'y')
                    {
                        Console.WriteLine("\nPlease type your activity here...\n");
                        TeacherAddActivity.Add(Console.ReadLine());
                        Console.WriteLine("\n Successfully added..");

                        UserReturnforTeachers();
                    }
                    else if(CharOption == 'n')
                    {
                        Console.WriteLine("\nThanks for answering..");
                        Console.WriteLine("No activity added..\n");
                        UserReturnforTeachers();
                    }

                }
                else
                {
                    Console.WriteLine("Incorrect input, please try again\n");
                    getTeacherChoices();
                }
                break;
            case 3:
                Console.WriteLine("\n_____STUDENTS_____");
                Console.WriteLine("Here's your students..\n");
                foreach (var view in viewTeacherStudent)
                {
                    Console.WriteLine(view);
                }
                UserReturnforTeachers();
                break;
            case 4:
                Console.WriteLine("\n_____GRADES_____");
                Console.WriteLine("[1] - Student 1");
                Console.Write(">> please enter your student: ");
                NumOption = Convert.ToInt32(Console.ReadLine());
                if(NumOption == 1)
                {
                    Console.WriteLine("\nHere is the grade of your student..\n");
                    foreach (var view in TeacherEditGrades)
                    {
                        Console.WriteLine("Subject 1: " + view);
                    }
                    Console.WriteLine("Do you want to edit your students grade?[y] or [n]");
                    CharOption = Convert.ToChar(Console.ReadLine());
                    if (CharOption == 'y')
                    {
                        Console.WriteLine("\nPlease enter the grades of your student..");
                        Console.Write("Subject 1: ");
                        //double subj1 = Convert.ToDouble(Console.ReadLine());wa
                        TeacherEditGrades.Add(Convert.ToDouble(Console.ReadLine()));
                        Console.WriteLine("Successsfully graded..\n");

                    }
                    else if(CharOption == 'n')
                    {
                        Console.WriteLine("Thanks for answering...");
                        Console.WriteLine("No Grade edited");
                    }
                    UserReturnforTeachers();

                }
                break;
            case 5:
                UserLogOutforTeachers();
                break;
        }
    }

    static void MainLogo()
    {
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("VIRTUAL CLASSROOM BETA");
        Console.WriteLine("------------------------------------------\n");
    }

    static bool getUserLogin() //Method to log in
    {
        string SchoolEmail = "admin", SchoolPassword = "admin123"; //default gateway

        Console.Write(">> enter school email: ");
        string SchoolEmailInputted = Console.ReadLine();
        Console.Write(">> enter school password: ");
        string SchoolPasswordInputted = Console.ReadLine();

        bool result = SchoolEmail == SchoolEmailInputted && SchoolPassword == SchoolPasswordInputted
            ? true : false;

        return result;
    }

    static void getStudentChoices() //students access
    {
        Console.WriteLine("Welcome to Virtual Classroom!!!");

        Console.WriteLine("\n-----LIST-----");
        foreach (var view in viewStudentChoices)
        {
            Console.WriteLine(view);
        }
        Console.Write("\n>> please enter the number you desire to input: ");
        NumOption = Convert.ToInt32(Console.ReadLine());

        switch (NumOption)
        {
            case 0:
                getAnnouncement();
                UserReturnforStudent();
                break;

            case 1:
                Console.WriteLine("\n_____PROFILE_____");
                Console.WriteLine("Student Email: admin");
                Console.WriteLine("Complete Name: Unknown");
                Console.WriteLine("Course and Section: Unknown\n");

                UserReturnforStudent();
                break;

            case 2:
                getVirtualClassroom();
                UserReturnforStudent();
                break;

            case 3:
                //Console.WriteLine("\nUnder Construction...\n");
                GetGrades();
                UserReturnforStudent();
                break;
            case 4:
                UserLogOutforStudents();
                //Console.WriteLine("Log out");
                break;
            default:
                Console.WriteLine("please enter the correct number");
                break;
        }
    }
    static void getAnnouncement() //student and teacher access
    {
        Console.WriteLine("\nThere's no announcement as of the moment...");
        Console.WriteLine("This it a beta version so there's no information towards the student/teacher");
        Console.WriteLine("Please stay in touch...\n");

        foreach (var view in Announcement)
        {
            Console.WriteLine(view);
        }

        Console.WriteLine("");
    }

    static void getVirtualClassroom() //student access
    {
        Console.WriteLine("\n_____VIRTUAL CLASSROOM_____");
        Yearlevel();

        Console.Write(">> input: ");
        NumOption = Convert.ToInt32(Console.ReadLine());
        switch (NumOption)
        {
            case 1:
                Semester();
                if (NumOption == 1 || NumOption == 2)
                {
                    List<string> SemVirtualClass = new List<string>() { "Subject 1 ----- 00:00 to 00:00 ----- Teacher 1", "Subject 2 ----- 00:00 to 00:00 ----- Teacher 2", "Subject 3 ----- 00:00 to 00:00 ----- Teacher 3", "Subject 4 ----- 00:00 to 00:00 ----- Teacher 4", "Subject 5 ----- 00:00 to 00:00 ----- Teacher 5" };
                    Console.WriteLine("\nHello user! here is your schedule for this semester...");
                    foreach (var view in SemVirtualClass)
                    {
                        Console.WriteLine(view);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter the correct number..\nPlease try again...");
                }
                break;
            case 2:
                Semester();
                if (NumOption == 1 || NumOption == 2)
                {
                    List<string> SemVirtualClass = new List<string>() { "Subject 1 ----- 00:00 to 00:00 ----- Teacher 1", "Subject 2 ----- 00:00 to 00:00 ----- Teacher 2", "Subject 3 ----- 00:00 to 00:00 ----- Teacher 3", "Subject 4 ----- 00:00 to 00:00 ----- Teacher 4", "Subject 5 ----- 00:00 to 00:00 ----- Teacher 5" };
                    Console.WriteLine("\nHello user! here is your schedule for this semester...");
                    foreach (var view in SemVirtualClass)
                    {
                        Console.WriteLine(view);
                    }
                }
                else
                {
                    Console.WriteLine("Please enter the correct number..\nPlease try again...");
                }
                break;
            case 3:
                UserNotEnrolled();
                break;
            case 4:
                UserNotEnrolled();
                break;
        }
    }

    static void GetGrades() //student access
    {
        Console.WriteLine("\n_____VIRTUAL GRADES_____");
        Yearlevel();

        Console.Write(">> input: ");
        NumOption = Convert.ToInt32(Console.ReadLine());

        if (NumOption == 1 || NumOption == 2)
        {
            Console.WriteLine("\nHello user! here is your grades...");
            foreach (var viewGrades in Grades)
            {
                Console.WriteLine(viewGrades);
            }
        }
        else if (NumOption == 3 || NumOption == 4)
        {
            Console.WriteLine("\nWARNING: ERROR \nYou're still not in this year level");
        }
    }

    static void Yearlevel() // student access
    {
        Console.WriteLine(">> please choose a year level");
        Console.WriteLine("[1] - First Year");
        Console.WriteLine("[2] - Second Year");
        Console.WriteLine("[3] - Third Year");
        Console.WriteLine("[4] - Fourth Year");
    }

    static int UserNotEnrolled() //student access
    {
        if (NumOption == 3 || NumOption == 4) Console.WriteLine("\nWARNING: ERROR \nYou're still not in this year level");

        return NumOption;
    }
     
    static int Semester() //student access
    {
        Console.WriteLine("\nPlease Choose a Semester");
        Console.WriteLine("[1] - First Semester");
        Console.WriteLine("[2] - Second Semester");
        Console.Write(">> input: ");
        NumOption = Convert.ToInt32(Console.ReadLine());

        return NumOption;
    }

    static void UserReturnforStudent() //student access
    {
        Console.WriteLine("\n>> do you want to return? [y] or [n]");
        Console.Write(">> input: ");
        CharOption = Convert.ToChar(Console.ReadLine());
        if (CharOption == 'y' || CharOption == 'Y')
        {
            getStudentChoices();
        }
        else if (CharOption == 'n' || CharOption == 'N')
        {
            Console.WriteLine("\nPlease stay here\n");
            UserReturnforStudent();
        }
        else
        {
            Console.WriteLine("\nPlease enter 'yes' or 'no' only...");
            UserReturnforStudent();
        }

    }

    static void UserLogOutforStudents() //student access
    {
        Console.WriteLine("\n>> are you sure you want to log out? [y] or [n]");
        Console.Write(">> input: ");
        CharOption = Convert.ToChar(Console.ReadLine());
        if (CharOption == 'y' || CharOption == 'Y')
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("System Log out");
        }
        else if (CharOption == 'n' || CharOption == 'N')
        {
            getStudentChoices();
            
        }
        else
        {
            Console.WriteLine("Please enter 'y' or 'n' only..");
            UserLogOutforStudents();
        }

    }

    static void UserReturnforTeachers()
    {
        Console.WriteLine("\n>> do you want to return? [y] or [n]");
        Console.Write(">> input: ");
        CharOption = Convert.ToChar(Console.ReadLine());
        if (CharOption == 'y' || CharOption == 'Y')
        {
            getTeacherChoices();
        }
        else if (CharOption == 'n' || CharOption == 'N')
        {
            Console.WriteLine("\nPlease stay here\n");
            //UserReturnforStudent();
            UserReturnforTeachers();
        }
        else
        {
            Console.WriteLine("\nPlease enter 'yes' or 'no' only...");
            //UserReturnforStudent();
            UserLogOutforTeachers();
        }
    } //teacher access

    static void UserLogOutforTeachers()
    {
        Console.WriteLine("\n>> are you sure you want to log out? [y] or [n]");
        Console.Write(">> input: ");
        CharOption = Convert.ToChar(Console.ReadLine());
        if (CharOption == 'y' || CharOption == 'Y')
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("System Log out");
        }
        else if (CharOption == 'n' || CharOption == 'N')
        {
            getTeacherChoices();

        }
        else
        {
            Console.WriteLine("Please enter 'y' or 'n' only..");
            UserLogOutforTeachers();
        }
    } //teacher access
}