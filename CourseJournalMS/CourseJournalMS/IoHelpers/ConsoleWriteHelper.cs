using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Data;
using MSJournal_Data.Models;

namespace CourseJournalMS.IoConsole
{
    internal class ConsoleWriteHelper
    {

        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Avaible commands:");
            Console.WriteLine("/add     /create     /update     /signin     /signout    /updatestudent " +
                            "\n/change  /addday     /addhome    /print      /clear      /exit   /help");
            Console.Write("Please enter the name of the action: ");
        }
        
        public static bool PrintHelp()
        {
            int i = 1;
            
            Console.Clear();
            Console.WriteLine("WELCOME TO HELP!");
            Console.WriteLine($"\n{i++}. /add           - Add new student" +
                              $"\n{i++}. /create        - Create new course" +
                              $"\n{i++}. /update        - Update course data" +
                              $"\n{i++}. /signin        - Sign in student to course" +
                              $"\n{i++}. /signout       - Sign out student from course" +
                              $"\n{i++}. /updatestudent - Update student data" +
                              $"\n{i++}. /change        - Change active course" +
                              $"\n{i++}. /addday        - Check attendance for active course " +
                              $"\n{i++}. /addhome       - Add homework to active course" +
                              $"\n{i++}. /print         - PRINTING COURSE REPORT" +
                              $"\n{i++}. /clear         - clear your console" +
                              $"\n{i++}. /exit          - exit program" +
                              $"\n{i++}. /help          - prints this menu");
            
            Console.WriteLine("\n^Tip^ You can use numbers instead of commands as follows");
            Console.WriteLine("\n\nzejnov/2017\n");
            Console.ReadKey();
            Console.Clear();
            return true;
        }

        public static void PrintIdError()
        {
            Console.WriteLine("The given ID does not exist in courses collection");
        }

        public static void PrintCourseData(CourseDto course)
        {
            Console.WriteLine($"Course name: {course.Name}");
            Console.WriteLine($"Leader: {course.LeaderName} {course.LeaderSurname}");
            Console.WriteLine($"Start date: {course.StartDate.Day}/{course.StartDate.Month}/{course.StartDate.Year}.");
            Console.WriteLine($"Presence threshold: {course.PresenceThreshold}%");
            Console.WriteLine($"Homework threshold: {course.HomeworkThreshold}%");
        }

        public static void PrintOrderedList(StudentDto student, int ordinal)
        {
            Console.WriteLine($"{ordinal}. {student.Name} {student.Surname} {student.Pesel}");
        }

        public static void PrintOrderedList(CourseDto course, int ordinal)
        {
            Console.WriteLine($"{ordinal}. {course.Name} lead by {course.LeaderName} {course.LeaderSurname}");
        }

        public static void PrintOrderedList(StudentOnCourseDto student, int ordinal)
        {
            Console.WriteLine($"{ordinal}. {student.Student.Name} {student.Student.Surname} {student.Student.Pesel}");
        }

        public static void PrintOrderedList(List<StudentOnCourseDto> studentOnCourseList)
        {
            var ordinal = 1;

            foreach (var student in studentOnCourseList)
            {
                Console.WriteLine($"{ordinal++}. {student.Student.Name} {student.Student.Surname}, PESEL: {student.Student.Pesel}");
            }
        }

        public static void PrintHomeworkList(List<StudentOnCourseDto> studentOnCourseList)
        {
            var ordinal = 1;

            foreach (var student in studentOnCourseList)
            {
                Console.WriteLine($"{ordinal++}. {student.Student.Name} {student.Student.Surname}, PESEL: {student.Student.Pesel}");
            }
        }

        public static void PrintStudentAttendanceResult(StudentOnCourseDto student, int ordinal)
        {
            var result = student.Student.AttendanceOk ? "passed" : "not passed";

            Console.WriteLine($"{ordinal}. {student.Student.Name} {student.Student.Surname} result:" +
                              $" {student.Student.PresentDays}/{student.Student.CourseDays} =" +
                              $" {Convert.ToInt32(student.Student.StudentAttendance)}% - {result}");
        }

        public static void PrintStudentHomeworkResult(StudentOnCourseDto student, int ordinal)
        {
            var result = student.Student.HomeworkOk ? "passed" : "not passed";

            Console.WriteLine($"{ordinal}. {student.Student.Name} {student.Student.Surname} result:" +
                              $" {student.Student.HomeworkPoints}/{student.Student.HomeworkMaxPoints} =" +
                              $" {Convert.ToInt32(student.Student.HomeworkPerformance)}% - {result}");
        }

        public static void HelloWorld()
        {
            Console.WriteLine($"Hello {Environment.UserName} in course journal :) \n\n\nPress any key to start");
            Console.ReadKey();
        }
    }






}
