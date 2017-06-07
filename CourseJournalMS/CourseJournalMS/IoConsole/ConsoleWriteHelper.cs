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
            Console.WriteLine("\nadd / sample / create / change / addday / addhome / print / clear / exit / help");
            Console.Write("Please enter the name of the action: ");
        }

        public static void PrintHelp()
        {
            Console.Clear();

            Console.WriteLine("\nWELCOME TO HELP!");
            Console.WriteLine("\nadd     - add new student to list" +
                              "\nsample  - loading some sample journal & students to print report" +
                              "\nchange  - jump to other course" +
                              "\ncreate  - creating a new journal" +
                              "\naddday  - adding a day of classes to course" +
                              "\naddhome - adding homework to course" +
                              "\nprint   - printing course report" +
                              "\nclear   - clearing the console" +
                              "\nexit    - exit console" +
                              "\nhelp    - is exactly where you are :)");
            Console.WriteLine("\n\nzejnov/2017\n");
        }

        public static void PrintIdError()
        {
            Console.WriteLine("The given ID does not exist in courses collection");
        }

        //    public static void PrintCourseReport(CourseDto course)
        //    {
        //        Console.Clear();

        //        PrintCourseInfo(course);


        //        PrintAttendance(course);
        //        PrintHomework(course);

        //        if (course.NumberOfHomeworks == 0 && course.ClassesDays == 0)
        //        {
        //            PrintStudentsOnCourseList(course);
        //        }
        //        Console.WriteLine("\n\n");
        //    }

        //    public static void PrintCourseInfo(CourseDto course)
        //    {
        //        Console.WriteLine("COURSE REPORT \n\nCourse name: {0}", course.Name);
        //        Console.WriteLine("Course start date: {0}.", course.StartDate);
        //        Console.WriteLine("Course leader: {0} {1}", course.LeaderName, course.LeaderSurname);
        //        Console.WriteLine("Course presence threshold: {0}%", course.PresenceThreshold);
        //        Console.WriteLine("Course homework threshold: {0}%", course.HomeworkThreshold);
        //    }


        //    public static void PrintAttendance(CourseDto course)
        //    {
        //        Console.WriteLine("\nDuring the course, there were {0} classes.", course.ClassesDays);

        //        if (course.ClassesDays != 0)
        //        {
        //            foreach (var student in course.CourseStudentsListDto)
        //            {
        //                string result;
        //                if (student.AttendanceOk)
        //                {
        //                    result = "passed";
        //                }
        //                else
        //                {
        //                    result = "not passed";
        //                }

        //                Console.WriteLine("Student {0} {1} gets {2}/{3} ({4}%) - " + result,
        //                    student.Name, student.Surname, student.PresentDays, course.ClassesDays,
        //                    Convert.ToInt32(student.StudentAttendance));
        //            }
        //        }
        //    }

        //    public static void PrintHomework(CourseDto course)
        //    {
        //        Console.WriteLine("\nDuring the course, there were {0} homeworks.", course.NumberOfHomeworks);

        //        if (course.NumberOfHomeworks != 0)
        //        {
        //            foreach (var student in course.CourseStudentsListDto)
        //            {
        //                string result;
        //                if (student.HomeworkOk)
        //                {
        //                    result = "passed";
        //                }
        //                else
        //                {
        //                    result = "not passed";
        //                }

        //                Console.WriteLine("Student {0} {1} gets {2}/{3} ({4}%) - " + result,
        //                    student.Name, student.Surname, student.HomeworkPoints, student.HomeworkMaxPoints,
        //                    Convert.ToInt32(student.HomeworkPerformance));
        //            }
        //        }
        //    }

        //    public static void PrintAllStudentsList()  //TODO: drukowanie z EntityToDto
        //    {
        //        var studentListDto = Dane.StudentsList; //Poddałem się z tym... :( na skróty.

        //        Console.WriteLine("\nPrinting just student list:");
        //        foreach (var student in studentListDto.Values)
        //        {
        //            Console.WriteLine("{0}. {1} {2}",
        //                student.Id, student.Name, student.Surname);
        //        }
        //    }

        //    public static void PrintStudentsOnCourseList(CourseDto course)
        //    {
        //        //var journal = new Journal();
        //        //var course = journal.GetActiveCourse();

        //        Console.WriteLine("\n{0} students attend to this course:\n", course.CourseStudentsListDto.Count);
        //        foreach (var student in course.CourseStudentsListDto)
        //        {
        //            Console.WriteLine("{0}. {1} {2}",
        //                student.Id, student.Name, student.Surname);
        //        }
        //    }

        //    public static void NewCourseDay()
        //    {
        //        Console.WriteLine("For each student please enter p(present) or a(absent):");
        //    }




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

    }






}
