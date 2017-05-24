using System;
using System.Security.Cryptography.X509Certificates;

namespace CourseJournalMS
{
    public class CourseDay
    {
        public enum AttendanceOnCourse
        {
            none,
            p,      //for present
            a,      //for absent
            present,
            absent,
        }

        public AttendanceOnCourse Attendance = AttendanceOnCourse.none;
        
        public CourseDay(Student student)  //creator!!
        {
            bool parameterOk = false;
            
            Console.Write("{0}. {1} {2} is: ", student.Id, student.Name, student.Surname);

            do
            {
                try
                {
                    Attendance =
                        (CourseDay.AttendanceOnCourse) Enum.Parse(typeof(CourseDay.AttendanceOnCourse),
                            Console.ReadLine());

                    if (Attendance != AttendanceOnCourse.none)
                        parameterOk = true;
                    else
                    {
                        Console.Write("Bad entry, please try again: ");
                    }
                }
                catch (ArgumentException e)
                {
                    Console.Write("Bad entry, please try p(present) or a(absent): ");
                }
                catch (FormatException e)
                {
                    Console.Write("Bad data format, please try again...");
                }
                catch (OverflowException e)
                {
                    Console.Write("It is too big for this program, sorry.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Some unexpected error occured!");
                }
            } while (!parameterOk);
        }
    }
}
