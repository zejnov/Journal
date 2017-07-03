using System.Collections.Generic;
using MSJournal_Business.Dtos;

namespace MSJournal_Business.Services.ServicesInterfaces
{
    public interface IHomeworkServices
    {
        bool Add(HomeworkDto homeworkDto);
        List<HomeworkDto> GetAll();
        List<HomeworkDto> GetHomework(StudentOnCourseDto studentOnCourseDto);
        bool RemoveHomework(HomeworkDto homework);
    }
}