using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSJournal_Business.Dtos;
using MSJournal_Business.Services;
using System;
using System.Collections.Generic;

namespace MSJournal.Business.Tests.ReportServicesTests
{
    [TestClass]
    public class AttendanceForReport
    {

        [TestMethod]
        public void StudentOnCourseServicesCheckAttendance_StudentOnCourseAttendenceList_AttendanceOk()
        {
            var studentOnCourseToCheck = new StudentOnCourseDto()
            {
                Id = 44,
                Student = new StudentDto()
                {
                    Id = 4,
                    Name = "Mateusz",
                    Surname = "Szwaba",
                    BirthDate = DateTime.Parse("05/01/1989"),
                    Gender = "male",
                    Pesel = 89050102345,
                },
                Course = new CourseDto()
                {
                    Id = 7,
                    Name = "Codementors",
                    LeaderName = "Jakub",
                    LeaderSurname = "Bulczak",
                    StartDate = DateTime.Parse("04/24/2017"),
                    HomeworkThreshold = 80,
                    PresenceThreshold = 90,
                    StudentsNumber = 12,
                },
            };

            var attendanceList = new List<CourseDayDto>()
            {
                new CourseDayDto()
                {
                    Attendance = "present",
                },
                new CourseDayDto()
                {
                    Attendance = "present",
                },
            };

            var expectedCheckedStudent = new StudentOnCourseDto()
            {
                Id = 44,
                Student = new StudentDto()
                {
                    AttendanceOk = true,
                    CourseDays = 2,
                    PresentDays = 2,
                    StudentAttendance = 100,

                    Id = 4,
                    Name = "Mateusz",
                    Surname = "Szwaba",
                    BirthDate = DateTime.Parse("05/01/1989"),
                    Gender = "male",
                    Pesel = 89050102345,
                },
                Course = new CourseDto()
                {
                    Id = 7,
                    Name = "Codementors",
                    LeaderName = "Jakub",
                    LeaderSurname = "Bulczak",
                    StartDate = DateTime.Parse("04/24/2017"),
                    HomeworkThreshold = 80,
                    PresenceThreshold = 90,
                    StudentsNumber = 12,
                },
            };

            var studentOnCourseServices = new StudentOnCourseServices();
            studentOnCourseServices.CheckAttendance(studentOnCourseToCheck, attendanceList);

            Assert.AreEqual(studentOnCourseToCheck,expectedCheckedStudent);
        }

        [TestMethod]
        public void StudentOnCourseServicesCheckAttendance_StudentOnCourseAttendenceList_AttendanceNotOk()
        {
            var studentOnCourseToCheck = new StudentOnCourseDto()
            {
                Id = 44,
                Student = new StudentDto()
                {
                    Id = 4,
                    Name = "Mateusz",
                    Surname = "Szwaba",
                    BirthDate = DateTime.Parse("05/01/1989"),
                    Gender = "male",
                    Pesel = 89050102345,
                },
                Course = new CourseDto()
                {
                    Id = 7,
                    Name = "Codementors",
                    LeaderName = "Jakub",
                    LeaderSurname = "Bulczak",
                    StartDate = DateTime.Parse("04/24/2017"),
                    HomeworkThreshold = 80,
                    PresenceThreshold = 90,
                    StudentsNumber = 12,
                },
            };

            var attendanceList = new List<CourseDayDto>()
            {
                new CourseDayDto()
                {
                    Attendance = "absent",
                },
                new CourseDayDto()
                {
                    Attendance = "present",
                },
            };

            var expectedCheckedStudent = new StudentOnCourseDto()
            {
                Id = 44,
                Student = new StudentDto()
                {
                    AttendanceOk = true,
                    CourseDays = 2,
                    PresentDays = 1,
                    StudentAttendance = 50,

                    Id = 4,
                    Name = "Mateusz",
                    Surname = "Szwaba",
                    BirthDate = DateTime.Parse("05/01/1989"),
                    Gender = "male",
                    Pesel = 89050102345,
                },
                Course = new CourseDto()
                {
                    Id = 7,
                    Name = "Codementors",
                    LeaderName = "Jakub",
                    LeaderSurname = "Bulczak",
                    StartDate = DateTime.Parse("04/24/2017"),
                    HomeworkThreshold = 80,
                    PresenceThreshold = 90,
                    StudentsNumber = 12,
                },
            };

            var studentOnCourseServices = new StudentOnCourseServices();
            studentOnCourseServices.CheckAttendance(studentOnCourseToCheck, attendanceList);

            Assert.AreEqual(studentOnCourseToCheck, expectedCheckedStudent);
        }

        [TestMethod]
        public void StudentOnCourseServicesCheckAttendance_StudentOnCourseEmptyAttendenceList_False()
        {
            var studentOnCourseToCheck = new StudentOnCourseDto()
            {
                Id = 44,
                Student = new StudentDto()
                {
                    Id = 4,
                    Name = "Mateusz",
                    Surname = "Szwaba",
                    BirthDate = DateTime.Parse("05/01/1989"),
                    Gender = "male",
                    Pesel = 89050102345,
                },
                Course = new CourseDto()
                {
                    Id = 7,
                    Name = "Codementors",
                    LeaderName = "Jakub",
                    LeaderSurname = "Bulczak",
                    StartDate = DateTime.Parse("04/24/2017"),
                    HomeworkThreshold = 80,
                    PresenceThreshold = 90,
                    StudentsNumber = 12,
                },
            };

            var attendanceList = new List<CourseDayDto>()
            {
                
            };

            var studentOnCourseServices = new StudentOnCourseServices();
            var result = studentOnCourseServices.CheckAttendance(studentOnCourseToCheck, attendanceList);

            Assert.IsFalse(result);
        }
        
    }
}
