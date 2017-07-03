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



        public DateTime TimeOfGeneration { get; private set; }

        public ReportDto()
        {
            TimeOfGeneration = DateTime.Now;
        }
    }
}
