using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    public class Functions
    {
        //******************Basic functionality********************************
        public static void GetJournalData (Journal journal)
        {//getting basic journal data
            ClearJournalData(journal);

            //try
            //{
                Console.WriteLine("Please provide the following fields.");
                Console.Write("Course name: ");
                journal.CourseName = Console.ReadLine();
                Console.Write("Course leader name: ");
                journal.CourseLeaderName = Console.ReadLine();
                Console.Write("Course leader surname: ");
                journal.CourseLeaderSurname = Console.ReadLine();
                Console.Write("Course start date (MM/DD/YYYY): ");
                journal.CourseStartDate = DateTime.Parse(Console.ReadLine());

                bool presenceOk = false;
                bool homeworkOk = false;
                bool studentsOk = false;

                Console.Write("Presence threshold(%): ");
                do
                {
                    journal.CoursePresenceThreshold = Double.Parse((Console.ReadLine()));
                    if (journal.CoursePresenceThreshold >= 0 && journal.CoursePresenceThreshold <= 100)
                    {
                        presenceOk = true;
                    }
                    else
                    {
                        Console.Write("Parameter out of range (0-100%), try again: ");
                    }
                } while (!presenceOk);

                Console.Write("Homework threshold(%): ");
                do
                {
                    journal.CourseHomeworkThreshold = Double.Parse(Console.ReadLine());
                    if (journal.CourseHomeworkThreshold >= 0 && journal.CourseHomeworkThreshold <= 100)
                    {
                        homeworkOk = true;
                    }
                    else
                    {
                        Console.Write("Parameter out of range (0-100%), try again: ");
                    }
                } while (!homeworkOk);

                Console.Write("Number of students: ");
                do
                {
                    journal.CourseStudentsNumber = Int32.Parse(Console.ReadLine());
                    if (journal.CourseStudentsNumber > 0)
                    {
                        studentsOk = true;
                    }
                    else
                    {
                        Console.Write("Number of students can not be negative or 0, please try again: ");
                    }

                } while (!studentsOk);
            //}


            //catch (ArgumentException e)
            //{
            //    Console.WriteLine("Bad command, please try again...");
            //}
            //catch (FormatException e)
            //{
            //    Console.WriteLine("Bad data format, please try again...");
            //}
            //catch (OverflowException e)
            //{
            //    Console.WriteLine("It is too big for this program, sorry.");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    Console.WriteLine("Unexpected error occured!");
            //   // throw;
            //}
        }

        public static void GetStudentsData(Journal journal)
        {//getting students data in order of number of students in course given
            for (int i = 1; i <= journal.CourseStudentsNumber; i++)
            {
                GetPersonalStudentData(i,journal.CourseStudentsList);
            }
        }
        
        public static void GetPersonalStudentData(int identifier, Dictionary<int,Student> journal)
        {//getting students data
            Student student = new Student();
            student.OrderNumber = identifier;
            Console.Write("Enter {0} student name: ", identifier);
            student.Name = Console.ReadLine();
            Console.Write("Enter {0} student surname: ", identifier);
            student.Surname = Console.ReadLine();
            Console.Write("Enter {0} student birth date: ", identifier);
            student.BirthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter {0} student gender(male/female): ", identifier);
            student.Gender = (Student.GenderType) Enum.Parse(typeof(Student.GenderType), Console.ReadLine());
            
            journal[student.OrderNumber] = student;         //adding student to Dictionary
        }

        public static void AddDayOfCourse(Journal journal)
        {
            CourseDay.NewCourseDay();
            foreach (var student in journal.CourseStudentsList)
            {
                CourseDay courseDay = new CourseDay(student.Value);
                student.Value.CourseList.Add(courseDay);
            }
            CourseDay.IncreaseCourseDayNumber();
        }

        public static void AddHomework(Journal journal)
        {
            Homework.NewHomework();
            foreach (var student in journal.CourseStudentsList)
            {
                Homework homework = new Homework(student.Value);
                student.Value.HomeworksList.Add(homework);
            }
            Homework.IncreaseHomeworksNumber();
        }
        
        //******************Some MAIN functions********************************
        public enum CommandTypes
        {
            none,
            create,
            sample,
            addday,
            addhome,
            print,
            clear,
            exit,
            help,
        }

        public static CommandTypes GetCommandFromUser()
        {
            CommandTypes command = CommandTypes.none;
            bool commandOk = false;

            do
            {
                try
                {
                    command = (CommandTypes)Enum.Parse(typeof(CommandTypes), Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Write("Bad command, please try again: ");
                }

                if (command != CommandTypes.none)
                {
                    commandOk = true;
                }
            } while (!commandOk);
            return command;
        }

        public static void SwitchCommand(CommandTypes command)
        {
            switch (command)
            {
#region         Command types   
                //    none,
                //    create,
                //    sample,
                //    addday,
                //    addhome,
                //    print,
                //    clear,
                //    exit,
                //    help,
#endregion
                case CommandTypes.none:
                {
                    //nothing happens here
                }
                    break;
                case CommandTypes.create:
                {
                    GetJournalData(Program.CodementorsJournal);
                    GetStudentsData(Program.CodementorsJournal);
                }
                    break;
                case CommandTypes.sample:
                {
                    SampleFullData(Program.CodementorsJournal,5);
                }
                    break;
                case CommandTypes.addday:
                {
                    AddDayOfCourse(Program.CodementorsJournal);
                }
                    break;
                case CommandTypes.addhome:
                {
                    AddHomework(Program.CodementorsJournal);
                }
                    break;
                case CommandTypes.print:
                {
                    PrintReport(Program.CodementorsJournal);
                }
                    break;
                case CommandTypes.clear:
                {
                    Console.Clear();   
                }
                    break;
                case CommandTypes.exit:
                {
                    Program.Working = false;
                    Console.WriteLine("Bye, bye!");  
                    Console.ReadKey();
                }
                    break;
                case CommandTypes.help:
                {
                    PrintHelp();
                }
                    break;
                default:            //almost useless
                    Console.WriteLine("Bad command, try again");
                    break;
            }
        }

        public static void ClearJournalData(Journal journal)
        {
            journal.CourseName = "";
            journal.CourseLeaderName = "";
            journal.CourseLeaderSurname = "";
            journal.CourseStartDate = DateTime.Parse("1 / 1 / 1000");
            journal.CoursePresenceThreshold = 1;
            journal.CourseHomeworkThreshold = 1;
            journal.CourseStudentsNumber = 1;
        }

        //******************Printing report starts here************************
        public static void PrintReport(Journal journal)
        {   
            Console.Clear();
            PrintCourseInfo(journal);
            PrintAttendance(journal);
            PrintHomework(journal);
            if (Homework.NumberOfHomeworks() == 0 && CourseDay.DaysOfCourse() == 0)
            {
                PrintStudentList(journal);  //prints only if no days and no homeworks
            }
            Console.WriteLine("\n\n");
        }

        public static void PrintCourseInfo(Journal journal)
        {
            Console.WriteLine("COURSE REPORT \n\nCourse name: {0}", journal.CourseName);
            Console.WriteLine("Course start date: {0}.", journal.CourseStartDate);
            Console.WriteLine("Course leader: {0} {1}", journal.CourseLeaderName, journal.CourseLeaderSurname);
            Console.WriteLine("Course presence threshold: {0}%", journal.CoursePresenceThreshold);
            Console.WriteLine("Course homework threshold: {0}%", journal.CourseHomeworkThreshold);
        }

        public static void PrintAttendance(Journal journal)
        {
            Console.WriteLine("\nDuring the course, there were {0} classes.", CourseDay.DaysOfCourse());

            if (CourseDay.DaysOfCourse() != 0)
            {
                foreach (var student in journal.CourseStudentsList.Values)
                {
                    if (student.CheckStudentAttendence())
                    {
                        Console.WriteLine("Student {0} {1} gets {2}/{3} ({4}%) - passed",
                            student.Name, student.Surname, student.PresentDays, CourseDay.DaysOfCourse(), 
                            Convert.ToInt32(student.StudentAttendance));
                    }
                    else
                    {
                        Console.WriteLine("Student {0} {1} gets {2}/{3} ({4}%) - not passed",
                            student.Name, student.Surname, student.PresentDays, CourseDay.DaysOfCourse(), 
                            Convert.ToInt32(student.StudentAttendance));
                    }
                }
            }

        }

        public static void PrintHomework(Journal journal)
        {
            Console.WriteLine("\nDuring the course, there were {0} homeworks.", Homework.NumberOfHomeworks());

            if (Homework.NumberOfHomeworks() != 0)
            {
                foreach (var student in journal.CourseStudentsList.Values)
                {
                    if (student.CheckStudentHomework())
                    {
                        Console.WriteLine("Student {0} {1} gets {2}/{3} ({4}%) - passed",
                            student.Name, student.Surname, student.HomeworkPoints, student.HomeworkMaxPoints, 
                            Convert.ToInt32(student.HomeworkPerformance));
                    }
                    else
                    {
                        Console.WriteLine("Student {0} {1} gets {2}/{3} ({4}%) - not passed",
                            student.Name, student.Surname, student.HomeworkPoints, student.HomeworkMaxPoints, 
                            Convert.ToInt32(student.HomeworkPerformance));
                    }
                }
            }
        }

        public static void PrintStudentList(Journal journal)
        {
            Console.WriteLine("\n{0} students attend to this course:\n", journal.CourseStudentsNumber);
            foreach (var student in journal.CourseStudentsList.Values)
            {
                Console.WriteLine("{0}. {1} {2}",
                    student.OrderNumber,student.Name,student.Surname);
            }
        }

        public static void PrintHelp()
        {
            Console.WriteLine("\n      HELP!");
            Console.WriteLine("\ncreate  - creating a new journal" +
                              "\nsample  - loading some sample journal to print report" +
                              "\naddday  - adding a day of classes to course" +
                              "\naddhome - adding homework to course" +
                              "\nprint   - printing course report" +
                              "\nclear   - clearing the console" +
                              "\nexit    - exit console" +
                              "\nhelp    - is exactly where you are :)");
            Console.WriteLine("\n\n\nzejnov/2017\n\n");
        }

        //******************Sample data starts here****************************
        public static void SampleFullData(Journal journal, int students)
        {
            journal.CourseStudentsList.Clear();     //prevent some errors
            SampleYournal(journal, students);
            SampleStudentsData(journal.CourseStudentsList,journal.CourseStudentsNumber);
        }

        public static void SampleStudentsData(Dictionary<int, Student> journal, int x)
        {

            for (int i = 1; i <= x; i++)
            {
                Student student = new Student();
                student.OrderNumber = i;
                student.Name = "Student" + i;
                student.Surname = "Kowalski" + 2 * i;
                student.BirthDate = DateTime.Parse("7/12/1984");
                student.Gender = Student.GenderType.male;
                
                journal[student.OrderNumber] = student;
            }
        }

        public static void SampleYournal(Journal journal, int x)
        {
            journal.CourseName = "Codementors";
            journal.CourseLeaderName = "Kuba";
            journal.CourseLeaderSurname = "Bulczak";
            journal.CourseStartDate = DateTime.Parse("4 / 24 / 2017");
            journal.CoursePresenceThreshold = 70;
            journal.CourseHomeworkThreshold = 80;
            journal.CourseStudentsNumber = x;
        }

    }
}
