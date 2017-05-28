using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Business.Dtos
{
    class CourseDayDto
    {
        public enum AttendanceOnCourse
        {
            none,
            p,      //for present
            a,      //for absent
            present,
            absent,
        }

        public AttendanceOnCourse Attendance = AttendanceOnCourse.none;
    }
}
