using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Data.Models;

namespace MSJournal_Business.Mappers
{
    class EntityToDto
    {
        public static StudentDto StudentEntityToDto(Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Gender = student.Gender,
                BirthDate = student.BirthDate,
                Pesel = student.Pesel,
            };
        }

        public static CourseDto CourseEntityToDto(Course course)
        {
            return new CourseDto()
            {
                Id = course.Id,
                Name = course.Name,
                LeaderName = course.LeaderName,
                LeaderSurname = course.LeaderSurname,
                StartDate = course.StartDate,
                HomeworkThreshold = course.HomeworkThreshold,
                PresenceThreshold = course.PresenceThreshold,
                StudentsNumber = course.StudentsNumber,

                CourseStudentsList = course.CourseStudentsList
                    .Select(StudentEntityToDto)
                    .ToList()
            };
        }

        public static HomeworkDto HomeworkEntityToDto(Homework homework)
        {
            return new HomeworkDto()
            {
                Id = homework.Id,
                Course = CourseEntityToDto(homework.Course),
                Student = StudentEntityToDto(homework.Student),
                StudentPoints = homework.StudentPoints,
                MaxPoints = homework.MaxPoints,
            };
        }

        public static CourseDayDto CourseDayEntityToDto(CourseDay courseDay)
        {
            return new CourseDayDto()
            {
                Id = courseDay.Id,
                Course = CourseEntityToDto(courseDay.Course),
                Student = StudentEntityToDto(courseDay.Student),
                Attendance = courseDay.Attendance,
            };

        }
    }//
}
