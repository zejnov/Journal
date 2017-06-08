using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;


namespace CourseJournalMS.IoConsole
{
    public class ChooseFromList
    {
        public static StudentDto StudentFromList(List<StudentDto> studentList)
        {
            int answer = 1;
            bool isAnswerCorrect = false;

            if (studentList.Count == 0)
            {
                return null;
            }

            int i = 1;
            foreach (var student in studentList)
            {
                ConsoleWriteHelper.PrintOrderedList(student, i++);
            }

            Console.WriteLine();
            Console.Write("Please, choose student number");

            while (!isAnswerCorrect)
            {
                answer = ConsoleReadHelper.GetData<int>("");
                   
                isAnswerCorrect = answer > 0 && answer <= studentList.Count;

                if (!isAnswerCorrect)
                    Console.Write("Bad entry, try again");
            }

            return studentList[answer - 1];
        }

        public static CourseDto CourseFromList(List<CourseDto> courseList)
        {
            int answer = 1;
            bool isAnswerCorrect = false;

            if (courseList.Count == 0)
            {
                return null;
            }

            int i = 1;
            foreach (var course in courseList)
            {
                ConsoleWriteHelper.PrintOrderedList(course, i++);
            }

            Console.WriteLine();
            Console.Write("Please, choose course number");

            while (!isAnswerCorrect)
            {
                answer = ConsoleReadHelper.GetData<int>("");
                isAnswerCorrect = answer > 0 && answer <= courseList.Count;

                if (!isAnswerCorrect)
                    Console.Write("Bad entry, try again");
            }

            return courseList[answer - 1];
        }

        public static StudentOnCourseDto StudentOnCourseList(List<StudentOnCourseDto> studentList)
        {
            int answer = 1;
            bool isAnswerCorrect = false;

            if (studentList.Count == 0)
            {
                return null;
            }

            int i = 1;
            foreach (var student in studentList)
            {
                ConsoleWriteHelper.PrintOrderedList(student, i++);
            }

            Console.WriteLine();
            //Console.Write("Please, choose student number:");

            while (!isAnswerCorrect)
            {
                answer = ConsoleReadHelper.GetData<int>("Please, choose student number: ");
                //answer = Int32.Parse(Console.ReadLine());
                isAnswerCorrect = answer > 0 && answer <= studentList.Count;

                if (!isAnswerCorrect)
                    Console.Write("Incorrect answer. Try again.");
            }

            return studentList[answer - 1];
        }

    }
}
