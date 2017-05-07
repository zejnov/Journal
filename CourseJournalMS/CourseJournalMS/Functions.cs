using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    class Functions
    {   
        public static void GetJournalData (Journal journal)
        {//getting basic journal data
            Console.Write("Give course name: ");
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
        
        public static void GetStudentsData(int numberOfStudents, Dictionary<int, Student> journal)
        {//getting students data in order of number of students in course given
            for (int i = 1; i <= numberOfStudents; i++)
            {
                GetPersonalStudentData(i,journal);
            }
        }
        
        public static void GetPersonalStudentData(int identifier, Dictionary<int,Student> journal)
        {//getting students data
            Student student = new Student();
            student.OrderNumber = identifier;
            Console.Write("Give " + identifier + " student name: ");
            student.Name = Console.ReadLine();
            Console.Write("Give " + identifier + " student surname: ");
            student.Surname = Console.ReadLine();
            Console.Write("Give " + identifier + " student birth date: ");
            student.BirthDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Give " + identifier + " student gender(male/female): ");
            student.Gender = (Student.GenderType) Enum.Parse(typeof(Student.GenderType), Console.ReadLine());
            
            journal[student.OrderNumber] = student;
        }

        public static void AddDayOfCourse(Journal journal)
        {
            //START HERE ********************************
            foreach (var student in journal.CourseStudentsList)
            {
                CourseDay courseDay = new CourseDay(student.Value.OrderNumber);
                student.Value.CourseList.Add(courseDay);
            }
        }

    }
}
