using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Data.Repository;
using MSJournal_Data.Repository.Interfaces;

namespace MSJournal_Business.Services
{
    public class CourseServices
    {
        private ICourseRepository _courseRepository;

        public CourseServices()
        {
            _courseRepository = new CourseRepository();
        }

        public CourseServices(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public bool Add(CourseDto courseDto)
        {
            if (Exist(courseDto))
                return false;
            return _courseRepository
                .Add(DtoToEntity.CourseDtoToEntity(courseDto));
        }

        public bool Exist(CourseDto courseDto)
        {
            return _courseRepository
                .Exist(DtoToEntity.CourseDtoToEntity(courseDto));
        }
        public CourseDto Get(int id)
        {
            if (!Exist(new CourseDto() { Id = id }))
                return null;

            return EntityToDto.CourseEntityToDto
                (_courseRepository.Get(id));
        }

        public List<CourseDto> GetAll()
        {
            return _courseRepository
                .GetAll()
                .Select(EntityToDto.CourseEntityToDto)
                .ToList();
        }

        public bool UpdateCourseData(CourseDto oldModel, CourseDto newModel)
        {
            if (!Exist(oldModel))
                return false;

            return _courseRepository.UpdateCourseData(
                DtoToEntity.CourseDtoToEntity(oldModel),
                DtoToEntity.CourseDtoToEntity(newModel));
        }

        public int GetCourseCount()
        {
            return _courseRepository.GetCourseCount();
        }

        public CourseDto RefreshCourse(CourseDto course)
        {
            return EntityToDto.CourseEntityToDto(
                _courseRepository.RefreshCourse
                    (DtoToEntity.CourseDtoToEntity(course)));

        }
    }
}
