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
        
        public bool Add(CourseDayDto courseDayDto)
        {
            if (Exist(courseDayDto))
                return false;
            return _courseDayRepository
                .Add(DtoToEntity.CourseDayDtoToEntity(courseDayDto));
        }

        private bool Exist(CourseDayDto courseDayDto)
        {
            return _courseDayRepository
                .Exist(DtoToEntity.CourseDayDtoToEntity(courseDayDto));
        }

        private CourseDayDto Get(int id)
        {
            if (!Exist(new CourseDayDto() { Id = id }))
                return null;

            return EntityToDto.CourseDayEntityToDto
                (_courseDayRepository.Get(id));
        }

        public List<CourseDayDto> GetAll()
        {
            return _courseDayRepository
                .GetAll()
                .Select(EntityToDto.CourseDayEntityToDto)
                .ToList();
        }

        public List<CourseDayDto> GetAttendance(StudentOnCourseDto studentOnCourseDto)
        {
            return _courseDayRepository
                .GetAttendance(DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseDto))
                .Select(EntityToDto.CourseDayEntityToDto)
                .ToList();
        }

        public bool RemoveDay(CourseDayDto courseDay)
        {
            return _courseDayRepository
                .RemoveDay(DtoToEntity.CourseDayDtoToEntity(courseDay));
        }
        
        //********* do Moq'a **********
        //public List<CourseDayDto> GetAttendanceTest(StudentOnCourseDto studentOnCourseDto)
        //{
        //    return _courseDayRepository
        //        .GetAttendance(DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseDto))
        //        .Select(EntityToDto.CourseDayEntityToDto)
        //        .ToList();
        //}
    }
}
