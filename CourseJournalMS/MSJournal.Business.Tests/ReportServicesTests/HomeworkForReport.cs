using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSJournal_Business.Dtos;
using MSJournal_Business.Services;

namespace MSJournal.Business.Tests.ReportServicesTests
{
    [TestClass]
    public class HomeworkForReport
    {
        [TestMethod]
        public void StudentOnCourseServicesCheckHomework_StudentOnCourseHomeworkList_HomeworkOk()
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
                    HomeworkThreshold = 70,
                    PresenceThreshold = 90,
                    StudentsNumber = 12,
                },
            };

            var homeworkList = new List<HomeworkDto>()
            {
                new HomeworkDto()
                {
                    MaxPoints = 25,
                    StudentPoints = 20,
                },
                new HomeworkDto()
                {
                    MaxPoints = 25,
                    StudentPoints = 20,
                },
            };

            var expectedCheckedStudent = new StudentOnCourseDto()
            {
                Id = 44,
                Student = new StudentDto()
                {
                    HomeworkOk = true,
                    HomeworkPoints = 40,
                    HomeworkMaxPoints = 50,
                    HomeworkPerformance = 80d,

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
                    HomeworkThreshold = 70,
                    PresenceThreshold = 90,
                    StudentsNumber = 12,
                },
            };
            var studentOnCourseServices = new StudentOnCourseServices();
            
            studentOnCourseServices.CheckHomework(studentOnCourseToCheck, homeworkList);

            Assert.AreEqual(studentOnCourseToCheck, expectedCheckedStudent);
        }

        [TestMethod]
        public void StudentOnCourseServicesCheckHomework_StudentOnCourseHomeworkList_HomeworkNotOk()
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
                    HomeworkThreshold = 70,
                    PresenceThreshold = 90,
                    StudentsNumber = 12,
                },
            };

            var homeworkList = new List<HomeworkDto>()
            {
                new HomeworkDto()
                {
                    MaxPoints = 25,
                    StudentPoints = 10,
                },
                new HomeworkDto()
                {
                    MaxPoints = 25,
                    StudentPoints = 10,
                },
            };

            var expectedCheckedStudent = new StudentOnCourseDto()
            {
                Id = 44,
                Student = new StudentDto()
                {
                    HomeworkOk = false,
                    HomeworkPoints = 20,
                    HomeworkMaxPoints = 50,
                    HomeworkPerformance = 40d,

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
                    HomeworkThreshold = 70,
                    PresenceThreshold = 90,
                    StudentsNumber = 12,
                },
            };

            var studentOnCourseServices = new StudentOnCourseServices();

            studentOnCourseServices.CheckHomework(studentOnCourseToCheck, homeworkList);

            Assert.AreEqual(studentOnCourseToCheck, expectedCheckedStudent);
        }

        [TestMethod]
        public void StudentOnCourseServicesCheckHomework_StudentOnCourseEmptyHomeworkList_False()
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
                    HomeworkThreshold = 70,
                    PresenceThreshold = 90,
                    StudentsNumber = 12,
                },
            };

            var homeworkList = new List<HomeworkDto>();
            
            var studentOnCourseServices = new StudentOnCourseServices();
            var result = studentOnCourseServices.CheckHomework(studentOnCourseToCheck, homeworkList);

            Assert.IsFalse(result);
        }
        
    }
}
