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
    }
}
