using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Data.Models
{
    public class StudentOnCourse
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
        public List<CourseDay> AttendanceList { get; set; } = new List<CourseDay>();    //attendance list
        public List<Homework> HomeworksList { get; set; } = new List<Homework>();       //homework list
    }
}
