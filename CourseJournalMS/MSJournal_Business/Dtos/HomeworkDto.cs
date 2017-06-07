using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Business.Dtos
{
    public class HomeworkDto
    {
        public int Id { get; set; }
        public int StudentPoints { get; set; }
        public int MaxPoints { get; set; }
        public StudentOnCourseDto StudentOnCourse { get; set; }
    }
}
