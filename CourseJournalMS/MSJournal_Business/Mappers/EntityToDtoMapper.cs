using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Business.JournalServices;
using MSJournal_Data;
using MSJournal_Data.Models;

namespace MSJournal_Business.Mappers
{
    internal class EntityToDtoMapper
    {
        public static Dictionary<int, CourseDto> CourseListEntityToDto()
        {
            var courseList = new Dictionary<int, CourseDto>();

            foreach (var course in Dane.Journal.Values)
            {
                courseList[course.Id] = CourseEntityModelToDto(course);
            }

            return courseList;
        }

        public static Dictionary<int,StudentDto> StudentListEntityModelToDto()
        {
            var studentListDto = new Dictionary<int, StudentDto>();

            foreach (var student in Dane.StudentsList.Values)
            {
                studentListDto[student.Id] = StudentEntityModelToDto(student);
            }

            return studentListDto;

        }

        public static CourseDto CourseEntityModelToDto(Course course)
        {
            
               int classesDays = course.CourseStudentsList[0].AttendanceList.Count;
               int numberOfHomeworks = course.CourseStudentsList[0].HomeworksList.Count;
          
            return new CourseDto()
            {
                Id = course.Id,
                Name = course.Name,
                LeaderName = course.LeaderName,
                LeaderSurname = course.LeaderSurname,
                StartDate = course.StartDate,
                HomeworkThreshold = course.HomeworkThreshold,
                PresenceThreshold = course.HomeworkThreshold,

                CourseStudentsListDto = course.CourseStudentsList.Select(StudentEntityModelToDto).ToList(),
                // b=>b.StudedntEtititittiyty Resharper poprawił
                ClassesDays = classesDays,
                NumberOfHomeworks = numberOfHomeworks,
                CourseIsActive = course.CourseIsActive,
            };
        }

        public static StudentDto StudentEntityModelToDto(Student student)
        {

            if (Dane.Journal.Count != 0)  //oszukałem wiem ;)
            {
                CheckingFunctions.CheckAttendance(student);
                CheckingFunctions.CheckHomework(student);
            }
            
            return new StudentDto()
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                BirthDate = student.BirthDate,
                //Gender = student.Gender,
                PresentDays = student.PresentDays,
                StudentAttendance = student.StudentAttendance,
                AttendanceOk = student.AttendanceOk,
                HomeworkPoints = student.HomeworkPoints,
                HomeworkMaxPoints = student.HomeworkMaxPoints,
                HomeworkPerformance = student.HomeworkPerformance,
                HomeworkOk = student.HomeworksOk,
            };
        }
    }
}
