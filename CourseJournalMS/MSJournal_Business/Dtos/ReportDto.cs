using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Business.Dtos
{
    public class ReportDto
    {
        public CourseDto Course { get; set; }
        public List<StudentOnCourseDto> CourseStudentList { get; set; } = new List<StudentOnCourseDto>();


        public DateTime TimeOfGeneration { get; private set; } = new DateTime();

        public ReportDto()
        {
            TimeOfGeneration = DateTime.Now;
        }
    }
}
