using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseJournalMS.IoConsole;
using MSJournal_Business.Dtos;
using MSJournal_Business.Services;

namespace CourseJournalMS
{
    public class ReportHelper
    {

        public static bool GetAttendanceReport(List<StudentOnCourseDto> studentOnCourseList)
        {
            if (studentOnCourseList.Count == 0)
            {
                Console.WriteLine("\nThere where no attendance checks on this course.\n");
                return false;
            }

            Console.WriteLine("\nAttendance on course results:\n");

            var ordinal = 1;
            var studentOnCourseServices = new StudentOnCourseServices();
            var courseDayServices = new CourseDayServices();

            foreach (var student in studentOnCourseList)
            {
                studentOnCourseServices.CheckAttendance
                    (student, courseDayServices.GetAttendance(student));

                ConsoleWriteHelper.PrintStudentAttendanceResult(student, ordinal++);
            }
            return true;
        }

        public static bool GetHomeworkReport(List<StudentOnCourseDto> studentOnCourseList)
        {
            if (studentOnCourseList.Count == 0)
            {
                Console.WriteLine("\nThere where no homeworks on this course.\n");
                return false;
            }

            Console.WriteLine("\nHomework results:\n");

            var ordinal = 1;
            var studentOnCourseServices = new StudentOnCourseServices();
            var homeworkServices = new HomeworkServices();

            foreach (var student in studentOnCourseList)
            {
                studentOnCourseServices.CheckHomework
                    (student, homeworkServices.GetHomework(student));

                ConsoleWriteHelper.PrintStudentHomeworkResult(student, ordinal++);
            }
            return true;
        }

        public static bool GetCourseReport(CourseDto course)
        {
            Console.WriteLine("COURSE REPORT \n");
            ConsoleWriteHelper.PrintCourseData(course);
            return true;
        }

        public static bool IfNoCourse()
        {
            Console.WriteLine("There is no active course! Try 'change' ");
            var studentServices = new StudentServices();

            if (studentServices.StudentsCount() != 0)
            {
                Console.WriteLine("\nPrinting just avaible students list:\n");

                var studentsList = studentServices.GetAll();
                var ordinal = 1;
                foreach (var student in studentsList)
                {
                    Console.WriteLine($"{ordinal++}. {student.Name} {student.Surname} PESEL:{student.Pesel}");
                }
            }
            Console.ReadKey();
            return true;
        }
    }
}
