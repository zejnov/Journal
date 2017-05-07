using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    class CourseDay
    {
        public DateTime CourseDayDate;  //add
        public int CourseDayNumber = 0; //!?!?

        public enum Attendance
        {
            none,
            p, //present
            a, //absent
        }

        public Attendance attendance;

        public CourseDay(int studentOrderNumber)  //creator!!
        {
            CourseDayNumber++;

            Console.Write("Student {0} is: ", studentOrderNumber);
            attendance = (CourseDay.Attendance) Enum.Parse(typeof(CourseDay.Attendance), Console.ReadLine());
        }
       // student.Gender = (Student.GenderType) Enum.Parse(typeof(Student.GenderType), Console.ReadLine());

    }
}
