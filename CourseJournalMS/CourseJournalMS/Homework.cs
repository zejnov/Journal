using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    public class Homework
    {
        private static int _maxHomeworkPoints = 0;
        private static int _numberOfHomeworks = 0;

        public int StudentHomeworkPoints;
        public int MaxHomeworkPoints;
        public int HomeworkOrderNumber;

        public Homework(Student student)    //creator!
        {
            Console.Write("{0}. {1} {2} get: ", student.OrderNumber, student.Name, student.Surname);
            StudentHomeworkPoints =  Int32.Parse(Console.ReadLine());
            MaxHomeworkPoints = _maxHomeworkPoints;
            HomeworkOrderNumber = ++_numberOfHomeworks;
        }
    
        public static void NewHomework()
        {
            Console.Write("Please enter the maximum number of points for this homework: ");
            _maxHomeworkPoints = Int32.Parse(Console.ReadLine());
            Console.WriteLine("For each student please enter the number of points earned: ");
        }

        public static void IncreaseHomeworksNumber()
        {
            _numberOfHomeworks++;
        }

        public static int NumberOfHomeworks()
        {
        return _numberOfHomeworks;
        }
    }
}
