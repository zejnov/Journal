using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Business.Dtos
{
    public class HomeworkDto
    {
        public int Id { get; set; }
        public int StudentPoints { get; set; }
        public int MaxPoints { get; set; }
        public StudentOnCourseDto StudentOnCourse { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var homework = obj as Homework;
            bool equal = true;

            equal &= homework.Id == Id;
            equal &= homework.StudentPoints == StudentPoints;
            equal &= homework.MaxPoints == MaxPoints;
            equal &= homework.StudentOnCourse.Equals(StudentOnCourse);

            return equal;
        }
    }
}
