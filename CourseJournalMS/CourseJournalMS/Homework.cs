using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    class Homework
    {
        public int MaxHomeworkPoints;
        public int StudentHomeworkPoints;

        public Homework(int studentOrderNumber)
        {
            Console.Write("Student {0} get points i homework: ", studentOrderNumber);
            StudentHomeworkPoints =  Int32.Parse(Console.ReadLine());
        }
    }
}
