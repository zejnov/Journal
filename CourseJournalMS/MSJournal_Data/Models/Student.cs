using System;
using System.Collections.Generic;

namespace MSJournal_Data.Models
{
    public class Student
    {
        public enum GenderType
        {
            none,
            male,
            female,
        }

        public int Id;
        public string Name, Surname;
        public DateTime BirthDate;
        public GenderType Gender;
        public List<CourseDay> AttendanceList = new List<CourseDay>();  //attendance list
        public List<Homework> HomeworksList = new List<Homework>(); //homework list
        public int PresentDays;
        public double StudentAttendance, HomeworkPerformance;
        public int HomeworkPoints, HomeworkMaxPoints;

        
    }
}
