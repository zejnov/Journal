using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Business.Dtos
{
    public class StudentOnCourseDto
    {
        public int Id { get; set; }
        public CourseDto Course { get; set; }
        public StudentDto Student { get; set; }
        public List<CourseDayDto> AttendanceList { get; set; } = new List<CourseDayDto>();    //attendance list
        public List<HomeworkDto> HomeworksList { get; set; } = new List<HomeworkDto>();       //homework list

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var studentOnCourse = obj as StudentOnCourseDto;
            bool equal = true;

            equal &= studentOnCourse.Id == Id;
            equal &= studentOnCourse.Course.Equals(Course);
            equal &= studentOnCourse.Student.Equals(Student);

            return equal;
        }
    }
}
