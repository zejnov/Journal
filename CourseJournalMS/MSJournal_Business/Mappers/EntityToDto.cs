using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Data.Models;

namespace MSJournal_Business.Mappers
{
    public class EntityToDto
    {
        public static ReportDto ReportDtoToEntity(Report report)
        {
            if (report == null)
            {
                return null;
            }

            var reportDto = new ReportDto()
            {
                Course = CourseEntityToDto(report.Course),
                TimeOfGeneration = report.TimeOfGeneration,
            };

            report.CourseStudentList = new List<StudentOnCourse>();
            foreach (var entry in report.CourseStudentList)
            {
                reportDto.CourseStudentList.Add(StudentOnCourseEntityToDto(entry));
            }

            return reportDto;
        }

        public static StudentDto StudentEntityToDto(Student student)
        {
            if (student == null)
            {
                return null;
            }

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Gender = student.Gender,
                BirthDate = student.BirthDate,
                Pesel = student.Pesel,

                HomeworkPoints = student.HomeworkPoints,
                HomeworkPerformance = student.HomeworkPerformance,
                HomeworkMaxPoints = student.HomeworkMaxPoints,
                PresentDays = student.PresentDays,
                StudentAttendance = student.StudentAttendance,
                AttendanceOk = student.AttendanceOk,
                HomeworkOk = student.HomeworkOk,
                CourseDays = student.CourseDays,
            };
        }

        public static CourseDto CourseEntityToDto(Course course)
        {
            if (course == null)
            {
                return null;
            }

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
            };
        }

        public static StudentOnCourseDto StudentOnCourseEntityToDto(StudentOnCourse studentOnCourse)
        {
            if (studentOnCourse == null)
            {
                return null;
            }

            return new StudentOnCourseDto()
            {
                Id = studentOnCourse.Id,
                Course = CourseEntityToDto(studentOnCourse.Course),
                Student = StudentEntityToDto(studentOnCourse.Student),
            };
        }

        public static HomeworkDto HomeworkEntityToDto(Homework homework)
        {
            if (homework == null)
            {
                return null;
            }

            return new HomeworkDto()
            {
                Id = homework.Id,
                StudentPoints = homework.StudentPoints,
                MaxPoints = homework.MaxPoints,
                StudentOnCourse = StudentOnCourseEntityToDto(homework.StudentOnCourse),
            };
        }

        public static CourseDayDto CourseDayEntityToDto(CourseDay courseDay)
        {
            if (courseDay == null)
            {
                return null;
            }

            return new CourseDayDto()
            {
                Id = courseDay.Id,
                Attendance = courseDay.Attendance,
                StudentOnCourse = StudentOnCourseEntityToDto(courseDay.StudentOnCourse)
            };
        }
    }//
}
