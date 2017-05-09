using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    class Student
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

        // attendance list
        public List<CourseDay> CourseList = new List<CourseDay>() ;

        public Homework StudentsHomework;
    }
}
