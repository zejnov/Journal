using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Data.Models
{
    public class Homework
    {
        public int Id { get; set; }
        public int StudentPoints { get; set; }
        public int MaxPoints { get; set; }
        public StudentOnCourse StudentOnCourse { get; set; }

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
