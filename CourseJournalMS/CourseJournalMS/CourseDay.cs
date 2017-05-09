using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    class CourseDay
    {
        public DateTime CourseDayDate;      //add
        private int _courseDayNumber = 0;    //!?!?

        public enum AttendanceOnCourse
        {
            none,
            p,      //for present
            present,
            a,      //for absent
            absent,
        }

        public AttendanceOnCourse Attendance;

        public CourseDay(int studentOrderNumber)  //creator!!
        {
            Console.Write("Student {0} is: ", studentOrderNumber);
            Attendance = (CourseDay.AttendanceOnCourse) Enum.Parse(typeof(CourseDay.AttendanceOnCourse), Console.ReadLine());
        }
        // student.Gender = (Student.GenderType) Enum.Parse(typeof(Student.GenderType), Console.ReadLine());

        public void NewCourseDay()
        {
            _courseDayNumber++;
        }

        public int DaysOfCourse()
        {
            return _courseDayNumber;
        }

    }
}
