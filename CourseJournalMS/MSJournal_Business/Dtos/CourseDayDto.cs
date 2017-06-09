using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Business.Dtos
{
    public class CourseDayDto
    {
        public int Id { get; set; }
        public string Attendance { get; set; }
        public StudentOnCourseDto StudentOnCourse { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var courseDay = obj as CourseDayDto;
            bool equal = true;

            equal &= courseDay.Id == Id;
            equal &= courseDay.Attendance == Attendance;
            equal &= courseDay.StudentOnCourse.Equals(StudentOnCourse);

            return equal;
        }
    }
}
