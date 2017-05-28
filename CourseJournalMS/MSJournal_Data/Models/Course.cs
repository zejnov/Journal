using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Data.Models
{
    public class Course
    {
        private static int _numberOfCreatedCourses = 0;
        public static int ChoosenCourse = 0;

        public int Id;
        public string Name;
        public string LeaderName, LeaderSurname;
        public DateTime StartDate;
        public double HomeworkThreshold;
        public double PresenceThreshold;
        public int StudentsNumber;

        public List<Student> CourseStudentsList = new List<Student>();
        public bool CourseIsActive;
        public bool CourseIsCreated;

        public static int CourseCounter()
        {
            return _numberOfCreatedCourses;
        }

        public void SetCourseCreated()
        {
            Id = _numberOfCreatedCourses + 1;
            CourseIsCreated = true;
            ChoosenCourse = Id;
            _numberOfCreatedCourses++;
        }
    }
}
