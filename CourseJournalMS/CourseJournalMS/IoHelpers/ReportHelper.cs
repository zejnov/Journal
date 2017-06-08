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
            Console.WriteLine("\nAttendance on course results:\n");

            var ordinal = 1;
            foreach (var student in studentOnCourseList)
            {
                StudentOnCourseServices.CheckAttendance
                    (student, CourseDayServices.GetAttendance(student));

                ConsoleWriteHelper.PrintStudentAttendanceResult(student, ordinal++);
            }
            return true;
        }

        public static bool GetHomeworkReport(List<StudentOnCourseDto> studentOnCourseList)
        {
            Console.WriteLine("\nHomework results:\n");

            var ordinal = 1;
            foreach (var student in studentOnCourseList)
            {
                StudentOnCourseServices.CheckHomework
                    (student, HomeworkServices.GetHomework(student));

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

            if (StudentServices.StudentsCount() != 0)
            {
                Console.WriteLine("\nPrinting just avaible students list:\n");

                var studentsList = StudentServices.GetAll();
                foreach (var student in studentsList)
                {
                    Console.WriteLine($"{student.Name} {student.Surname} PESEL:{student.Pesel}");
                }
            }
            return true;
        }
    }
}
