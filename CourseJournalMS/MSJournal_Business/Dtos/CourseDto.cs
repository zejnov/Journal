using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<StudentDto> CourseStudentsList { get; set; } = new List<StudentDto>();
        public List<CourseDayDto> AttendanceList { get; set; } = new List<CourseDayDto>();  //attendance list
        public List<HomeworkDto> HomeworksList { get; set; } = new List<HomeworkDto>(); //homework list

        //public bool CourseIsActive { get; set; }
        //public bool CourseIsCreated { get; set; }

    }
}
