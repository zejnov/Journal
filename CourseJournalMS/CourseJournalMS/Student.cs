using System;
using System.Collections.Generic;

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
        public List<CourseDay> CourseList = new List<CourseDay>();  //attendance list
        public List<Homework> HomeworksList = new List<Homework>(); //homework list
        public int PresentDays;
        public double StudentAttendance, HomeworkPerformance;
        public int HomeworkPoints, HomeworkMaxPoints;

        public bool CheckStudentAttendence()
        {
            PresentDays = 0;
                
            foreach (var day in CourseList)
            {
                if (day.Attendance == CourseDay.AttendanceOnCourse.present ||
                    day.Attendance == CourseDay.AttendanceOnCourse.p)
                {
                    PresentDays++;
                }
            }
            StudentAttendance = 100 * PresentDays / CourseDay.DaysOfCourse();

            if (StudentAttendance >= Program.CodementorsJournal.CoursePresenceThreshold)
            return true;
            return false;
        }

        public bool CheckStudentHomework()
        {
            HomeworkMaxPoints = 0;
            HomeworkPoints = 0;

            foreach (var homework in HomeworksList)
            {
                HomeworkMaxPoints += homework.MaxHomeworkPoints;
                HomeworkPoints += homework.StudentHomeworkPoints;
            }

            HomeworkPerformance = 100 * HomeworkPoints / HomeworkMaxPoints;

            if (HomeworkPerformance >= Program.CodementorsJournal.CourseHomeworkThreshold )
            return true;
            return false;
        }
    }
}
