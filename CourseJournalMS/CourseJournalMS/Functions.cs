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
            Console.Write("Course start date: ");
            journal.CourseStartDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Presence threshold: ");
            journal.CoursePresenceThreshold = Double.Parse((Console.ReadLine()));
            Console.Write("Homework threshold: ");
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
            
            journal[student.OrderNumber] = student;
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

        public static void PrintReport(Journal journal)
        {   
            Console.Clear();
            Console.WriteLine("{0} COURSE REPORT",journal.CourseName);
            Console.WriteLine("Course start date: {0}.", journal.CourseStartDate);
            Console.WriteLine("Course leader: {0} {1}", journal.CourseLeaderName, journal.CourseLeaderSurname);
            Console.WriteLine("Course presence threshold {0}", journal.CoursePresenceThreshold);
            Console.WriteLine("Course homework threshold {0}", journal.CourseHomeworkThreshold);
           // Console.WriteLine("{0}", journal);

            foreach (var student in journal.CourseStudentsList)
            {
                CheckAttendance(student.Value);
            }

            foreach (var student in journal.CourseStudentsList)
            {
                CheckHomework(student.Value);
            }


        }

        public static void CheckAttendance(Student student)
        {   Console.WriteLine(CourseDay.DaysOfCourse());
            foreach (var day in student.CourseList)
            {
                if (day.Attendance == CourseDay.AttendanceOnCourse.present || day.Attendance == CourseDay.AttendanceOnCourse.p)
                {
                    
                }
            }
        }

        public static void CheckHomework(Student student)
        {

        }

        //******************Sample data starts here**************************
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
            journal.CoursePresenceThreshold = 80;
            journal.CourseHomeworkThreshold = 60;
            journal.CourseStudentsNumber = x;
        }

    }
}
