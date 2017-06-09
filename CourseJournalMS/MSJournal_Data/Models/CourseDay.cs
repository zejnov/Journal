using System;
using System.Security.Cryptography.X509Certificates;

namespace MSJournal_Data.Models
{
    public class CourseDay
    {
        public int Id { get; set; }
        public string Attendance { get; set; }
        public StudentOnCourse StudentOnCourse { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var courseDay = obj as CourseDay;
            bool equal = true;

            equal &= courseDay.Id == Id;
            equal &= courseDay.Attendance == Attendance;
            equal &= courseDay.StudentOnCourse.Equals(StudentOnCourse);

            return equal;
        }
    }
}
