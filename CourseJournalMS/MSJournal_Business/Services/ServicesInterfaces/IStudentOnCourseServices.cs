using System.Collections.Generic;
using MSJournal_Business.Dtos;

namespace MSJournal_Business.Services.ServicesInterfaces
{
    public interface IStudentOnCourseServices
    {
        bool AddStudentToCourse(StudentOnCourseDto studentOnCourseDto);
        bool RemoveStudentFromCourse(StudentOnCourseDto studentOnCourseDto);
        List<StudentOnCourseDto> StudentsListOnCourse(CourseDto course);
        bool CheckAttendance(StudentOnCourseDto studentOnCourseDto, List<CourseDayDto> attendanceList);
        bool CheckHomework(StudentOnCourseDto studentOnCourseDto, List<HomeworkDto> homeworkList);
        bool Exist(StudentOnCourseDto studentOnCourseDto);
    }
}