using System;
using System.Collections.Generic;

namespace MSJournal_Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public long Pesel { get; set; }

        public int PresentDays { get; set; }
        public int CourseDays { get; set; }
        public double StudentAttendance { get; set; }
        public double HomeworkPerformance { get; set; }
        public int HomeworkPoints { get; set; }
        public int HomeworkMaxPoints { get; set; }
        public bool AttendanceOk { get; set; }
        public bool HomeworkOk { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var student = obj as Student;
            bool equal = true;

            equal &= student.Id == Id;
            equal &= student.Name == Name;
            equal &= student.Surname == Surname;
            equal &= student.BirthDate == BirthDate;
            equal &= student.Gender == Gender;
            equal &= student.Pesel == Pesel;

            return equal;
        }
    }
}
