using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Data.Models
{
    public class Report
    {
        //TODO: z zachowaniem odpowiedniej warstwy
        public Course Course { get; set; }
        public List<StudentOnCourse> CourseStudentList { get; set; } = new List<StudentOnCourse>();


        public DateTime TimeOfGeneration { get; set; } = new DateTime();
    }
}
