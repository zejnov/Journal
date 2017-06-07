using System;
using System.Security.Cryptography.X509Certificates;

namespace MSJournal_Data.Models
{
    public class CourseDay
    {
        public int Id { get; set; }
        public string Attendance { get; set; }
        public StudentOnCourse StudentOnCourse { get; set; }
    }
}
