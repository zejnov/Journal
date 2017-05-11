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
        public static void GetJournalData (Journal journal)
        {//getting basic journal data
            Console.WriteLine("Please provide the following fields.");
            Console.Write("Course name: ");
            journal.CourseName = Console.ReadLine();
            Console.Write("Course leader name: ");
            journal.CourseLeaderName = Console.ReadLine();
            Console.Write("Course leader surname: ");
            journal.CourseLeaderSurname = Console.ReadLine();
            Console.Write("Course start date (MM/DD/YYYY): ");
            journal.CourseStartDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Presence threshold(%): ");
            journal.CoursePresenceThreshold = Double.Parse((Console.ReadLine()));
            Console.Write("Homework threshold(%): ");
            journal.CourseHomeworkThreshold = Double.Parse(Console.ReadLine());
            Console.Write("Number of students: ");
            journal.CourseStudentsNumber = Int32.Parse(Console.ReadLine());
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

        //******************Sample data starts here****************************
        public static void SampleFullData(Journal journal, int students)
        {
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
