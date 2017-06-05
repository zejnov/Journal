using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Data.Models;

namespace MSJournal_Business.Mappers
{
    class DtoToEntity
    {
        public static Student StudentDtoToEntity(StudentDto student)
        {
            
            return new Student
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Gender = student.Gender,
                BirthDate = student.BirthDate,
                Pesel = student.Pesel,
            };
        }

        public static Course CourseDtoToEntity(CourseDto course)
        {
            return new Course()
            {
                Id = course.Id,
                Name = course.Name,
                LeaderName = course.LeaderName,
                LeaderSurname = course.LeaderSurname,
                StartDate = course.StartDate,
                HomeworkThreshold = course.HomeworkThreshold,
                PresenceThreshold = course.PresenceThreshold,
                StudentsNumber = course.StudentsNumber,
            };
        }

        public static Homework HomeworkDtoToEntity(HomeworkDto homework)
        {
            return new Homework()
            {
                Id = homework.Id,
                Course = CourseDtoToEntity(homework.Course),
                Student = StudentDtoToEntity(homework.Student),
                StudentPoints = homework.StudentPoints,
                MaxPoints = homework.MaxPoints,
            };
        }

        public static CourseDay CourseDayDtoToEntity(CourseDayDto courseDay)
        {
            return new CourseDay()
            {
                Id = courseDay.Id,
                Course = CourseDtoToEntity(courseDay.Course),
                Student = StudentDtoToEntity(courseDay.Student),
                Attendance = courseDay.Attendance,
            };
        }
    }

}
