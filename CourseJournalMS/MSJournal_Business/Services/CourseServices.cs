using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Data.Repository;

namespace MSJournal_Business.Services
{
    class CourseServices
    {
        public static bool Add(CourseDto courseDto)
        {
            if (Exist(courseDto))
                return false;
            return new CourseRepository()
                .Add(DtoToEntity.CourseDtoToEntity(courseDto));
        }

        private static bool Exist(CourseDto courseDto)
        {
            return new CourseRepository()
                .Exist(DtoToEntity.CourseDtoToEntity(courseDto));
        }

        private static CourseDto Get(int id)
        {
            if (!Exist(new CourseDto() { Id = id }))
                return null;

            return EntityToDto.CourseEntityToDto
                (new CourseRepository().Get(id));
        }

        public static List<CourseDto> GetAll()
        {
            return new CourseRepository()
                .GetAll()
                .Select(EntityToDto.CourseEntityToDto)
                .ToList();
        }

        public static List<StudentDto> GetAllStudents(CourseDto courseDto)
        {
            return new CourseRepository()
                .GetAllStudents(DtoToEntity.CourseDtoToEntity(courseDto))
                .Select(EntityToDto.StudentEntityToDto)
                .ToList();
        }

        public static List<CourseDayDto> GetStudentAttendance(CourseDto courseDto, int id)
        {
            return new CourseRepository()
                .GetStudentAttendance(DtoToEntity.CourseDtoToEntity(courseDto), id)
                .Select(EntityToDto.CourseDayEntityToDto)
                .ToList();
        }

        public static List<HomeworkDto> GetStudentHomework(CourseDto courseDto, int id)
        {
            return new CourseRepository()
                .GetStudentHomework(DtoToEntity.CourseDtoToEntity(courseDto), id)
                .Select(EntityToDto.HomeworkEntityToDto)
                .ToList();
        }
    }
}
