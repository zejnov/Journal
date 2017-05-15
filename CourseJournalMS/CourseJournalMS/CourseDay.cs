using System;
using System.Security.Cryptography.X509Certificates;

namespace CourseJournalMS
{
    public class CourseDay
    {
        private static DateTime _courseDayDate;      //add
        private static int _courseDayNumber = 0;     //!?!?

        public enum AttendanceOnCourse
        {
            none,
            p,      //for present
            present,
            a,      //for absent
            absent,
        }

        public AttendanceOnCourse Attendance = AttendanceOnCourse.none;
        public DateTime DayOfClasses;
        public int DayOrderNumber;

        public CourseDay(Student student)  //creator!!
        {
            bool parameterOk = false;

            DayOrderNumber = _courseDayNumber + 1;
            DayOfClasses = _courseDayDate;
            Console.Write("{0}. {1} {2} is: ", student.OrderNumber, student.Name, student.Surname);

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

        public static void NewCourseDay()
        {
            bool parameterOk = false;

            do
            {
                try
                {
                    Console.Write("Please enter date of course day: ");
                    _courseDayDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("For each student please enter p(present) or a(absent):");
                    parameterOk = true;
                }

                catch (FormatException e)
                {
                    Console.WriteLine("Bad data format, please try again...");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("It is too big for this program, sorry.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Some unexpected error occured!");
                }
            } while (!parameterOk);
        }

        public static void IncreaseCourseDayNumber()
        {
            _courseDayNumber++;
        }

        public static int DaysOfCourse()
        {
            return _courseDayNumber;
        }

        public static void ResetCoursDayNumber()
        {
            _courseDayNumber = 0;
        }

    }
}
