using System.Collections.Generic;
using MSJournal_Business.Dtos;

namespace MSJournal_Business.Services.ServicesInterfaces
{
    public interface ICourseDayServices
    {
        bool Add(CourseDayDto courseDayDto);
        List<CourseDayDto> GetAll();
        List<CourseDayDto> GetAttendance(StudentOnCourseDto studentOnCourseDto);
        bool RemoveDay(CourseDayDto courseDay);
    }
}