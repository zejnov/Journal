using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Data.Models;

namespace MSJournal_Business.Mappers
{
    internal class DtoToEntityMappers
    {
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
                CourseIsActive = course.CourseIsActive,
                CourseIsCreated = course.CourseIsCreated,
            };
        }

        public static CourseDay CourseDayDtoToEntity(CourseDayDto courseDay)
        {
            var result = "";
            var attendance = courseDay.Attendance;
            if (attendance == CourseDayDto.AttendanceOnCourse.a ||
                attendance == CourseDayDto.AttendanceOnCourse.absent)
            {
                result = "absent";
            }
            else if (attendance == CourseDayDto.AttendanceOnCourse.p ||
                     attendance == CourseDayDto.AttendanceOnCourse.present)
                 {
                    result = "present";
                 }


            return new CourseDay()
            {
                Attendance = result, 
            };
        }

        public static Homework HomeworkDtoToEntity(HomeworkDto homework)
        {
            return new Homework()
            {
                MaxHomeworkPoints = homework.MaxHomeworkPoints,
                StudentHomeworkPoints = homework.StudentHomeworkPoints,
            };
        }

        public static Student StudentDtoToEntity(StudentDto student)
        {
            
            return new Student
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                //Gender = student.Gender,
                BirthDate = student.BirthDate,

            };
        }
    }
}
