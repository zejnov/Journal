using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Business.Dtos
{
    public class HomeworkDto
    {
        public int Id { get; set; }
        public CourseDto Course { get; set; }
        public StudentDto Student { get; set; }
        public int StudentPoints { get; set; }
        public int MaxPoints { get; set; }
    }
}
