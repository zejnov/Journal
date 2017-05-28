using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Business.Dtos
{
    public class CourseDto
    {
        public int Id;
        public string Name;
        public string LeaderName, LeaderSurname;
        public DateTime StartDate;
        public double HomeworkThreshold;
        public double PresenceThreshold;
        public int StudentsNumber;
        public int ClassesDays, NumberOfHomeworks;

        public List<StudentDto> CourseStudentsListDto;

        public bool CourseIsActive;
        public bool CourseIsCreated;
    }
}
