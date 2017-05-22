using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    public class Course
    {
        private static int _numberOfCreatedCourses = 0;
        public static int ChoosenCourse = 0;

        public static int ActiveCourseId = 0;
        public int Id;
        public string Name;
        public string LeaderName, CourseLeaderSurname;
        public DateTime StartDate;
        public double HomeworkThreshold;
        public double PresenceThreshold;
        public int StudentsNumber;

        public Dictionary<int,Student> CourseStudentsList = new Dictionary<int, Student>();

        public Course()  //creator
        {
            Id = ++_numberOfCreatedCourses;
            ChoosenCourse = Id;
        }
        
        //for protection to not print report of the empty journal
        private bool _courseActive = false;
        private bool _courseCreated = false;

        public bool CourseActive()
        {
            return _courseActive;
        }

        public void SetCourseActive()
        {
            _courseActive = true;
        }

        public void ResetCourseActive()
        {
            _courseActive = false;
        }

        public void SetCourseCreated()
        {
            _courseCreated = true;
        }

        public void ResetCourseCreated()
        {
            _courseCreated = false;
        }

        public bool CourseCreatedStatus()
        {
            return _courseCreated;
        }

    }
}
