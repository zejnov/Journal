using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    public class Journal
    {
        public Course ActiveCourse()
        {
            Console.WriteLine(Course.ChoosenCourse);
            //return Program.CodementorsJournal;
            return Program.Journal[Course.ChoosenCourse];
        }

        public void SetActiveCourse(int id)
        {
            if (CheckIdOfCourseExist(id))
            {
            Course.ChoosenCourse = id;
            }
            else
            {
                PrintIdError();
            }
        }

        public bool CheckIdOfCourseExist(int id)
        {
            foreach (int courseId in Program.Journal.Keys)
            {
                if (courseId == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void ChangeActiveCourse()
        {
            Console.WriteLine("Please ");
            //TODO : FINISH THIS SECTION
            
        }

        //******************Basic functionality********************************
        public void CreateNewCourse()
        {
            Course course = new Course();
            Program.Journal.Add(course.Id,course);
            SetActiveCourse(course.Id);
            GetJournalData(course);
            GetStudentsData(course);
        }

        public void GetJournalData(Course journal)
        {//getting basic journal data
            ClearJournalData(journal);

            try
            {
                Console.WriteLine("Please provide the following fields.");
                Console.Write("Course name: ");
                journal.Name = Console.ReadLine();
                Console.Write("Course leader name: ");
                journal.LeaderName = Console.ReadLine();
                Console.Write("Course leader surname: ");
                journal.CourseLeaderSurname = Console.ReadLine();

                bool dateOk = false;
                bool presenceOk = false;
                bool homeworkOk = false;
                bool studentsOk = false;

                do
                {
                    try
                    {
                        Console.Write("Course start date (MM/DD/YYYY): ");
                        journal.StartDate = DateTime.Parse(Console.ReadLine());
                        dateOk = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Bad data format, please try again: ");
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("It is too big for this program, please try again: ");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("Some unexpected error occured!");
                    }
                } while (!dateOk);




                Console.Write("Presence threshold(%): ");
                do
                {
                    journal.PresenceThreshold = Double.Parse((Console.ReadLine()));
                    if (journal.PresenceThreshold >= 0 && journal.PresenceThreshold <= 100)
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
                    journal.HomeworkThreshold = Double.Parse(Console.ReadLine());
                    if (journal.HomeworkThreshold >= 0 && journal.HomeworkThreshold <= 100)
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
                    journal.StudentsNumber = Int32.Parse(Console.ReadLine());
                    if (journal.StudentsNumber > 0)
                    {
                        studentsOk = true;
                    }
                    else
                    {
                        Console.Write("Number of students can not be negative or 0, please try again: ");
                    }

                } while (!studentsOk);

                journal.SetCourseCreated();
            }//try

            catch (ArgumentException e)
            {
                Console.WriteLine("Bad command, please try again...");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Bad data format, please try again...");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("It is too big for this program, sorry.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Unexpected error occured!");
            }

        }

        public void GetStudentsData(Course journal)
        {//getting students data in order of number of students in course given
            journal.CourseStudentsList.Clear();
            int i = 1;

            if (journal.CourseCreatedStatus())
            {
                while (i <= journal.StudentsNumber)
                {
                    i = GetPersonalStudentData(i, journal.CourseStudentsList);
                }

                journal.SetCourseActive();
            }


        }

        public int GetPersonalStudentData(int identifier, Dictionary<int, Student> journal)
        {//getting students data
            try
            {
                Student student = new Student();
                student.OrderNumber = identifier;
                Console.Write("Enter {0} student name: ", identifier);
                student.Name = Console.ReadLine();
                Console.Write("Enter {0} student surname: ", identifier);
                student.Surname = Console.ReadLine();
                Console.Write("Enter {0} student birth date: ", identifier);
                student.BirthDate = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter {0} student gender(male/female): ", identifier);
                student.Gender = (Student.GenderType)Enum.Parse(typeof(Student.GenderType), Console.ReadLine());

                journal[student.OrderNumber] = student; //adding student to Dictionary
                return ++identifier;
            }
            catch (FormatException e)
            {
                Console.WriteLine("Bad data format, please try again...");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("It is too big for this program, sorry.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Bad data format, please try again...");
                //throw;
            }
            return identifier;
        }

        public void AddDayOfCourse(Course journal)
        {
            if (journal.CourseActive())
            {
                CourseDay.NewCourseDay();
                foreach (var student in journal.CourseStudentsList)
                {
                    CourseDay courseDay = new CourseDay(student.Value);
                    student.Value.CourseList.Add(courseDay);
                }
                CourseDay.IncreaseCourseDayNumber();
            }
            else
            {
                Console.WriteLine("\nCould not add day of course if there is no course!");
            }
        }

        public void AddHomework(Course journal)
        {
            if (journal.CourseActive())
            {
                Homework.NewHomework();
                foreach (var student in journal.CourseStudentsList)
                {
                    Homework homework = new Homework(student.Value);
                    student.Value.HomeworksList.Add(homework);
                }
                Homework.IncreaseHomeworksNumber();
            }
            else
            {
                Console.WriteLine("\nCould not add homework if there is no course!");
            }
        }

        //******************Some MAIN functions********************************
        public void Run()
        {
            SampleFullData(3);
            SwitchCommand(ActiveCourse());
        }

        public enum CommandTypes
        {
            none,
            create,
            sample,
            change,
            addday,
            addhome,
            print,
            clear,
            exit,
            help,
        }

        public CommandTypes GetCommandFromUser()
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

        public void SwitchCommand(Course course)
        {
            var exit = false;

            while (!exit)
            {
                PrintMenu();

                var command = GetCommandFromUser();

                switch (command)
                {
                    #region         Command types on short list   
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
                        CreateNewCourse();
                    }
                        break;
                    case CommandTypes.sample:
                    {
                        SampleFullData(5);
                    }
                        break;
                    case CommandTypes.change:
                    {
                        ChangeActiveCourse();
                    }
                        break;

                    case CommandTypes.addday:
                    {
                        AddDayOfCourse(course);
                    }
                        break;
                    case CommandTypes.addhome:
                    {
                        AddHomework(course);
                    }
                        break;
                    case CommandTypes.print:
                    {
                        PrintReport(course);
                    }
                        break;
                    case CommandTypes.clear:
                    {
                        Console.Clear();
                    }
                        break;
                    case CommandTypes.exit:
                    {
                        exit = true;
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

            
        }

        public void ClearJournalData(Course journal)
        {
            journal.Name = "";
            journal.LeaderName = "";
            journal.CourseLeaderSurname = "";
            journal.StartDate = DateTime.Parse("1 / 1 / 1000");
            journal.PresenceThreshold = 1;
            journal.HomeworkThreshold = 1;
            journal.StudentsNumber = 1;

            journal.CourseStudentsList.Clear();
            CourseDay.ResetCoursDayNumber();
            Homework.ResetHomeworkNumber();
            journal.ResetCourseActive();
            journal.ResetCourseCreated();
        }

        //******************Printing report starts here************************
        public void PrintReport(Course journal)
        {
            Console.Clear();
            if (journal.CourseActive())
            {
                PrintCourseInfo(journal);
                PrintAttendance(journal);
                PrintHomework(journal);
                if (Homework.NumberOfHomeworks() == 0 && CourseDay.DaysOfCourse() == 0)
                {
                    PrintStudentList(journal);  //prints only if no days and no homeworks
                }
                Console.WriteLine("\n\n");
            }
            else
            {
                Console.WriteLine("\nThere is nothing to print...");
            }

        }

        public void PrintCourseInfo(Course journal)
        {
            Console.WriteLine("COURSE REPORT \n\nCourse name: {0}", journal.Name);
            Console.WriteLine("Course start date: {0}.", journal.StartDate);
            Console.WriteLine("Course leader: {0} {1}", journal.LeaderName, journal.CourseLeaderSurname);
            Console.WriteLine("Course presence threshold: {0}%", journal.PresenceThreshold);
            Console.WriteLine("Course homework threshold: {0}%", journal.HomeworkThreshold);
        }

        public void PrintAttendance(Course journal)
        {
            Console.WriteLine("\nDuring the course, there were {0} classes.", CourseDay.DaysOfCourse());

            if (CourseDay.DaysOfCourse() != 0)
            {
                foreach (var student in journal.CourseStudentsList.Values)
                {
                    string result;
                    if (student.CheckStudentAttendence(ActiveCourse()))
                    {
                        result = "passed";
                    }
                    else
                    {
                        result = "not passed";
                    }

                    Console.WriteLine("Student {0} {1} gets {2}/{3} ({4}%) - " + result,
                        student.Name, student.Surname, student.PresentDays, CourseDay.DaysOfCourse(),
                        Convert.ToInt32(student.StudentAttendance));
                }
            }

        }

        public void PrintHomework(Course journal)
        {
            Console.WriteLine("\nDuring the course, there were {0} homeworks.", Homework.NumberOfHomeworks());

            if (Homework.NumberOfHomeworks() != 0)
            {
                foreach (var student in journal.CourseStudentsList.Values)
                {
                    string result;
                    if (student.CheckStudentHomework(ActiveCourse()))
                    {
                        result = "passed";
                    }
                    else
                    {
                        result = "not passed";
                    }

                    Console.WriteLine("Student {0} {1} gets {2}/{3} ({4}%) - " + result,
                        student.Name, student.Surname, student.HomeworkPoints, student.HomeworkMaxPoints,
                        Convert.ToInt32(student.HomeworkPerformance));
                }
            }
        }

        public void PrintStudentList(Course journal)
        {
            Console.WriteLine("\n{0} students attend to this course:\n", journal.StudentsNumber);
            foreach (var student in journal.CourseStudentsList.Values)
            {
                Console.WriteLine("{0}. {1} {2}",
                    student.OrderNumber, student.Name, student.Surname);
            }
        }

        public void PrintHelp()
        {
            Console.Clear();
            Console.WriteLine("\nWELCOME TO HELP!");
            Console.WriteLine("\ncreate  - creating a new journal (removes previous data)" +
                              "\n          the course is active once all students data has been entered" +
                              "\nsample  - loading some sample journal to print report (removes previous data)" +
                              "\naddday  - adding a day of classes to course" +
                              "\naddhome - adding homework to course" +
                              "\nprint   - printing course report" +
                              "\nclear   - clearing the console" +
                              "\nexit    - exit console" +
                              "\nhelp    - is exactly where you are :)");
            Console.WriteLine("\n\nzejnov/2017\n");
        }

        public void PrintMenu()
        {
            Console.WriteLine("\n(create / sample / addday / addhome / print / clear / exit / help)");
            Console.Write("Please enter the name of the action: ");
        }

        public void PrintIdError()
        {
            Console.WriteLine("The given ID does not exist in courses collection");
        }

        //******************Sample data starts here****************************
        public void SampleFullData(int students)
        {
            var course = new Course();
            Program.Journal.Add(course.Id, course);

            //ClearJournalData(journal);     //prevent some errors

            SampleYournal(course, students);
            SampleStudentsData(course.CourseStudentsList, course.StudentsNumber);
            course.SetCourseActive();
            Console.WriteLine("\nSample journal loaded succesfully!");
        }

        public void SampleStudentsData(Dictionary<int, Student> journal, int x)
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

        public void SampleYournal(Course journal, int x)
        {
            journal.Name = "Codementors";
            journal.LeaderName = "Kuba";
            journal.CourseLeaderSurname = "Bulczak";
            journal.StartDate = DateTime.Parse("4 / 24 / 2017");
            journal.PresenceThreshold = 70;
            journal.HomeworkThreshold = 80;
            journal.StudentsNumber = x;
        }

    }
}
