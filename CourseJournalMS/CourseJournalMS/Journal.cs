using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    public class Journal
    {
        public string CourseName;
        public string CourseLeaderName, CourseLeaderSurname;
        public DateTime CourseStartDate;
        public double CourseHomeworkThreshold;
        public double CoursePresenceThreshold;
        public int CourseStudentsNumber;

        public Dictionary<int,Student> CourseStudentsList = new Dictionary<int, Student>();

        //for protection to not print report of the empty journal
        private static bool _courseActive = false;
        private static bool _courseCreated = false;

        public static bool CourseActive()
        {
            return _courseActive;
        }

        public static void SetCourseActive()
        {
            _courseActive = true;
        }

        public static void ResetCourseActive()
        {
            _courseActive = false;
        }

        public static void SetCourseCreated()
        {
            _courseCreated = true;
        }

        public static void ResetCourseCreated()
        {
            _courseCreated = false;
        }

        public static bool CourseCreatedStatus()
        {
            return _courseCreated;
        }

    }
}
