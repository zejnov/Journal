using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Business.Dtos
{
    public class CourseDayDto
    {
        public int Id { get; set; }
        public string Attendance { get; set; }
    }
}
