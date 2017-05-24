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

        public int Id;
        public string Name, Surname;
        public DateTime BirthDate;
        public GenderType Gender;
        public List<CourseDay> CourseList = new List<CourseDay>();  //attendance list
        public List<Homework> HomeworksList = new List<Homework>(); //homework list
        public int PresentDays, PassedDays;
        public double StudentAttendance, HomeworkPerformance;
        public int HomeworkPoints, HomeworkMaxPoints;

        public bool CheckStudentAttendence(Course course)
        {
            PresentDays = 0;
            PassedDays = 0;
                
            foreach (var day in CourseList)
            {
                PassedDays++;
                if (day.Attendance == CourseDay.AttendanceOnCourse.present ||
                    day.Attendance == CourseDay.AttendanceOnCourse.p)
                {
                    PresentDays++;
                }
            }
            StudentAttendance = 100 * PresentDays / PassedDays;

            if (StudentAttendance >= course.PresenceThreshold)
            return true;
            return false;
        }

        public bool CheckStudentHomework(Course course)
        {
            HomeworkMaxPoints = 0;
            HomeworkPoints = 0;

            foreach (var homework in HomeworksList)
            {
                HomeworkMaxPoints += homework.MaxHomeworkPoints;
                HomeworkPoints += homework.StudentHomeworkPoints;
            }

            HomeworkPerformance = 100 * HomeworkPoints / HomeworkMaxPoints;

            if (HomeworkPerformance >= course.HomeworkThreshold )
            return true;
            return false;
        }
    }
}
