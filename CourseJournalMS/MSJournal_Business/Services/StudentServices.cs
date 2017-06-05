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
    class StudentServices
    {
        public static bool Add(StudentDto studentDto)
        {
            if (Exist(studentDto))
                return false;
            return new StudentRepository().Add(DtoToEntity.StudentDtoToEntity(studentDto));
        }

        private static bool Exist(StudentDto studentDto)
        {
           return new StudentRepository()
                .Exist(DtoToEntity.StudentDtoToEntity(studentDto));
        }

        private static StudentDto Get(int id)
        {
            if (!Exist(new StudentDto() {Id = id}))
                return null;

            return EntityToDto.StudentEntityToDto
                (new StudentRepository().Get(id));
        }

        public static List<StudentDto> GetAll()
        {
            return new StudentRepository()
                .GetAll()
                .Select(EntityToDto.StudentEntityToDto)
                .ToList();
        }

        public bool UpdateStudentData(StudentDto oldStudent, StudentDto newStudent)
        {
            if (!Exist(oldStudent))
                return false;

            return new StudentRepository()
                .UpdateStudentData(
                    DtoToEntity.StudentDtoToEntity(oldStudent),
                    DtoToEntity.StudentDtoToEntity(newStudent));
        }
    }
}
