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
            bool parameterOk = false;
            MaxHomeworkPoints = _maxHomeworkPoints;
            HomeworkOrderNumber = _numberOfHomeworks + 1;

            Console.Write("{0}. {1} {2} get: ", student.OrderNumber, student.Name, student.Surname);
            do
            {
            StudentHomeworkPoints =  Int32.Parse(Console.ReadLine());
                if (StudentHomeworkPoints >= 0 && StudentHomeworkPoints <= MaxHomeworkPoints)
                {
                    parameterOk = true;
                }
                else if(StudentHomeworkPoints > MaxHomeworkPoints)
                {
                    Console.Write("Student can not get more points than max, please try again: ");
                }    
                else
                {
                    Console.Write("Bad range of number, please try again: ");
                }
            } while (!parameterOk);
        }
    
        public static void NewHomework()
        {
            bool parameterOk = false;

            Console.Write("Please enter the maximum number of points for this homework: ");
            do
            {
            _maxHomeworkPoints = Int32.Parse(Console.ReadLine());
                if (_maxHomeworkPoints > 0)
                {
                    parameterOk = true;
                }
                else
                {
                    Console.Write("Bad range of number, please try again: ");
                }
                
            } while (!parameterOk);

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
