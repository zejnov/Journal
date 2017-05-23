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
            /*Console.WriteLine(Course.ChoosenCourse);*/  //temp
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
        {   //warunki zakładają, że nie będzie kasowany żaden kurs w dzienniku
            SetActiveCourse(
            GetInt("Please enter the course number you wish to switch to"
                   ,0,Course.CourseCounter()));
        }
        //*******************GeTy
        public int GetInt(string message, int minValue, int maxValue)
        {
            int result = 0;
            bool parameterOk = false;
            Console.Write(message + " :");
            
            do
            {
                try
                {
                    result = Int32.Parse(Console.ReadLine());
                    if (result >= minValue && result <= maxValue)
                    {
                        parameterOk = true;
                    }
                    else
                    {
                        Console.Write("Number must be from range {0} to {1}: ", minValue, maxValue);
                    }
                }
                catch (Exception e)
                {
                    Console.Write("Bad data format, please try again: ");
                }
            } while (!parameterOk);
                    return result;
        }

        //TODO GetDouble, GetData, Get...

        //******************Basic functionality********************************
        public void CreateNewCourse()
        {
            Course course = new Course();
            Program.Journal.Add(course.Id,course);
            SetActiveCourse(course.Id);
            GetJournalData(course);
            GetStudentsData(course);
        }

        public void GetJournalData(Course course)
        {//getting basic journal data
            ClearJournalData(course);

            try
            {
                Console.WriteLine("Please provide the following fields.");
                Console.Write("Course name: ");
                course.Name = Console.ReadLine();
                Console.Write("Course leader name: ");
                course.LeaderName = Console.ReadLine();
                Console.Write("Course leader surname: ");
                course.CourseLeaderSurname = Console.ReadLine();

                bool dateOk = false;
                bool presenceOk = false;
                bool homeworkOk = false;
                bool studentsOk = false;

                do
                {
                    try
                    {
                        Console.Write("Course start date (MM/DD/YYYY): ");
                        course.StartDate = DateTime.Parse(Console.ReadLine());
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
                    course.PresenceThreshold = Double.Parse((Console.ReadLine()));
                    if (course.PresenceThreshold >= 0 && course.PresenceThreshold <= 100)
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
                    course.HomeworkThreshold = Double.Parse(Console.ReadLine());
                    if (course.HomeworkThreshold >= 0 && course.HomeworkThreshold <= 100)
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
                    course.StudentsNumber = Int32.Parse(Console.ReadLine());
                    if (course.StudentsNumber > 0)
                    {
                        studentsOk = true;
                    }
                    else
                    {
                        Console.Write("Number of students can not be negative or 0, please try again: ");
                    }

                } while (!studentsOk);

                course.SetCourseCreated();
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

        public void GetStudentsData(Course course)
        {//getting students data in order of number of students in course given
            course.CourseStudentsList.Clear();
            int i = 1;

            if (course.CourseCreatedStatus())
            {
                while (i <= course.StudentsNumber)
                {
                    i = GetPersonalStudentData(i, course.CourseStudentsList);
                }

                course.SetCourseActive();
            }


        }

        public int GetPersonalStudentData(int identifier, Dictionary<int, Student> studentsDictionary)
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

                studentsDictionary[student.OrderNumber] = student; //adding student to Dictionary
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

        public void AddDayOfCourse(Course course)
        {
            if (course.CourseIsActive())
            {
                course.NewCourseDay();   //tylko napis
                foreach (var student in course.CourseStudentsList)
                {
                    CourseDay courseDay = new CourseDay(student.Value);
                    student.Value.CourseList.Add(courseDay);
                }
                course.IncreaseClasesDaysNumber();  //statsy
            }
            else
            {
                Console.WriteLine("\nCould not add day of course if there is no course!");
            }
        }

        public void AddHomework(Course course)
        {
            if (course.CourseIsActive())
            {
                course.NewHomework();  //setting max points value
                foreach (var student in course.CourseStudentsList)
                {
                    Homework homework = new Homework(student.Value, course.MaxHomeworkPoints);
                    student.Value.HomeworksList.Add(homework);
                }
                course.IncreaseHomeworksNumber();  //some stats... lepiej z ilości w liście?
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
            SwitchCommand();
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

        public void SwitchCommand()
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
                        AddDayOfCourse(ActiveCourse());
                    }
                        break;
                    case CommandTypes.addhome:
                    {
                        AddHomework(ActiveCourse());
                    }
                        break;
                    case CommandTypes.print:
                    {
                        PrintReport(ActiveCourse());
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
            journal.ResetCourseActive();
            journal.ResetCourseCreated();
        }

        //******************Printing report starts here************************
        public void PrintReport(Course course)
        {
            Console.Clear();
            //Console.WriteLine(Course.ChoosenCourse);  /temp
            //Console.WriteLine(course.Id);

            if (course.CourseIsActive())
            {
                PrintCourseInfo(course);
                PrintAttendance(course);
                PrintHomework(course);

                //TODO drukowanie listy studentó przy braku prac i obecności
                //if (Homework.NumberOfHomeworks() == 0 && CourseDay.DaysOfCourse() == 0)
                //{
                //    PrintStudentList(course);  //prints only if no days and no homeworks
                //}
                //Console.WriteLine("\n\n");
            }
            else
            {
                Console.WriteLine("\nThere is nothing to print...");
            }

        }

        public void PrintCourseInfo(Course course)
        {
            Console.WriteLine("COURSE REPORT \n\nCourse name: {0}", course.Name);
            Console.WriteLine("Course start date: {0}.", course.StartDate);
            Console.WriteLine("Course leader: {0} {1}", course.LeaderName, course.CourseLeaderSurname);
            Console.WriteLine("Course presence threshold: {0}%", course.PresenceThreshold);
            Console.WriteLine("Course homework threshold: {0}%", course.HomeworkThreshold);
        }

        public void PrintAttendance(Course course)
        {
            Console.WriteLine("\nDuring the course, there were {0} classes.", course.NumberOfClasesDays);

            if (course.NumberOfClasesDays != 0)
            {
                foreach (var student in course.CourseStudentsList.Values)
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
                        student.Name, student.Surname, student.PresentDays, course.NumberOfClasesDays,
                        Convert.ToInt32(student.StudentAttendance));
                }
            }

        }

        public void PrintHomework(Course course)
        {
            Console.WriteLine("\nDuring the course, there were {0} homeworks.", course.NumberOfHomeworks);

            if (course.NumberOfHomeworks != 0)
            {
                foreach (var student in course.CourseStudentsList.Values)
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
