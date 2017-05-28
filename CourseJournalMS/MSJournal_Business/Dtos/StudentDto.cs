using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Business.Dtos
{
    public class StudentDto
    {
        public enum GenderType
        {
            none,
            male,
            female,
        }

        public int Id;
        public string Name, Surname;
        public DateTime BirthDate;
        public GenderType Gender;
        
        public int PresentDays;
        public double StudentAttendance, HomeworkPerformance;
        public int HomeworkPoints, HomeworkMaxPoints;
        public bool AttendanceOk, HomeworkOk;
    }
}
