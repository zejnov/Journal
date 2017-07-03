using System.Collections.Generic;
using MSJournal_Business.Dtos;

namespace MSJournal_Business.Services.ServicesInterfaces
{
    public interface IStudentServices
    {
        bool Add(StudentDto studentDto);
        bool Exist(StudentDto studentDto);
        StudentDto Get(int id);
        List<StudentDto> GetAll();
        int StudentsCount();
        bool UpdateStudentData(StudentDto oldStudent, StudentDto newStudent);
        bool CheckPesel(long pesel);
    }
}