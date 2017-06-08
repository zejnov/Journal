using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Business.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public long Pesel { get; set; }

        public int PresentDays { get; set; }
        public int CourseDays { get; set; }
        public double StudentAttendance { get; set; }
        public double HomeworkPerformance { get; set; }
        public int HomeworkPoints { get; set; }
        public int HomeworkMaxPoints { get; set; }
        public bool AttendanceOk { get; set; }
        public bool HomeworkOk{ get; set; }
}
}
