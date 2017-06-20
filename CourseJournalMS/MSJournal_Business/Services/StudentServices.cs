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
    public class StudentServices
    {
        private IStudentRepository _studentRepository;

        public StudentServices()
        {
            _studentRepository = new StudentRepository();
        }

        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public bool Add(StudentDto studentDto)
        {
            if (Exist(studentDto))
                return false;
            return _studentRepository.Add(DtoToEntity.StudentDtoToEntity(studentDto));
        }

        public bool Exist(StudentDto studentDto)
        {
           return _studentRepository
                .Exist(DtoToEntity.StudentDtoToEntity(studentDto));
        }

        public StudentDto Get(int id)
        {
            if (!Exist(new StudentDto() {Id = id}))
                return null;

            return EntityToDto.StudentEntityToDto
                (_studentRepository.Get(id));
        }

        public List<StudentDto> GetAll()
        {
            return _studentRepository
                .GetAll()
                .Select(EntityToDto.StudentEntityToDto)
                .ToList();
        }

        public int StudentsCount()
        {
            return _studentRepository.StudentsCount();
        }

        public bool UpdateStudentData(StudentDto oldStudent, StudentDto newStudent)
        {
            if (!Exist(oldStudent))
                return false;

            return _studentRepository.UpdateStudentData(
                DtoToEntity.StudentDtoToEntity(oldStudent),
                DtoToEntity.StudentDtoToEntity(newStudent));
        }

        public bool CheckPesel(long pesel)
        {
            return pesel.ToString().Length == 11;
        }
    }
}
