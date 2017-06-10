using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Data.Repository.Interfaces
{
    public interface ICourseDayRepository
    {
        bool Add(CourseDay model);
        bool Exist(CourseDay model);
        CourseDay Get(int id);
        List<CourseDay> GetAll();
        List<CourseDay> GetAttendance(StudentOnCourse model);
        bool RemoveDay(CourseDay model);
    }
}
