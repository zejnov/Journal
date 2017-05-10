using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    public class Student
    {
        public enum GenderType
        {
            none,
            male,
            female,
        }

        public int OrderNumber;
        public string Name, Surname;
        public DateTime BirthDate;
        public GenderType Gender;
        public List<CourseDay> CourseList = new List<CourseDay>(); // attendance list
        public List<Homework> HomeworksList = new List<Homework>(); //homework list
    }
}
