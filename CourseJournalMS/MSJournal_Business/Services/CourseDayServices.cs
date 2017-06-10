using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Data.Repository;
using MSJournal_Data.Repository.Interfaces;

namespace MSJournal_Business.Services
{
    public class CourseDayServices
    {
        private ICourseDayRepository _courseDayRepository;

        public CourseDayServices()
        {
            _courseDayRepository = new CourseDayRepository();
        }

        public CourseDayServices(ICourseDayRepository courseDayRepository)
        {
            _courseDayRepository = courseDayRepository;
        }
        
        public static bool Add(CourseDayDto courseDayDto)
        {
            if (Exist(courseDayDto))
                return false;
            return new CourseDayRepository()
                .Add(DtoToEntity.CourseDayDtoToEntity(courseDayDto));
        }

        private static bool Exist(CourseDayDto courseDayDto)
        {
            return new CourseDayRepository()
                .Exist(DtoToEntity.CourseDayDtoToEntity(courseDayDto));
        }

        private static CourseDayDto Get(int id)
        {
            if (!Exist(new CourseDayDto() { Id = id }))
                return null;

            return EntityToDto.CourseDayEntityToDto
                (new CourseDayRepository().Get(id));
        }

        public static List<CourseDayDto> GetAll()
        {
            return new CourseDayRepository()
                .GetAll()
                .Select(EntityToDto.CourseDayEntityToDto)
                .ToList();
        }

        public static List<CourseDayDto> GetAttendance(StudentOnCourseDto studentOnCourseDto)
        {
            return new CourseDayRepository()
                .GetAttendance(DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseDto))
                .Select(EntityToDto.CourseDayEntityToDto)
                .ToList();
        }

        public static bool RemoveDay(CourseDayDto courseDay)
        {
            return new CourseDayRepository()
                .RemoveDay(DtoToEntity.CourseDayDtoToEntity(courseDay));
        }
        
        //********* do Moq'a **********
        public List<CourseDayDto> GetAttendanceTest(StudentOnCourseDto studentOnCourseDto)
        {
            return _courseDayRepository
                .GetAttendance(DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseDto))
                .Select(EntityToDto.CourseDayEntityToDto)
                .ToList();
        }
    }
}
