using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Business.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LeaderName { get; set; }
        public string LeaderSurname { get; set; }
        public DateTime StartDate { get; set; }
        public double HomeworkThreshold { get; set; }
        public double PresenceThreshold { get; set; }
        public int StudentsNumber { get; set; }

        public List<StudentOnCourseDto> StudentOnCourse { get; set; } = new List<StudentOnCourseDto>();
        

    }
}
