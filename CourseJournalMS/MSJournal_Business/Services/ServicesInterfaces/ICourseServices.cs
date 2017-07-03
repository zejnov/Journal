using System.Collections.Generic;
using MSJournal_Business.Dtos;

namespace MSJournal_Business.Services.ServicesInterfaces
{
    public interface ICourseServices
    {
        bool Add(CourseDto courseDto);
        bool Exist(CourseDto courseDto);
        CourseDto Get(int id);
        List<CourseDto> GetAll();
        bool UpdateCourseData(CourseDto oldModel, CourseDto newModel);
        int GetCourseCount();
        CourseDto RefreshCourse(CourseDto course);
    }
}