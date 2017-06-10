using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Business.Services;
using MSJournal_Data.Models;
using MSJournal_Data.Repository.Interfaces;

namespace MSJournal.Business.Tests.ReportServicesTests
{
    [TestClass]
    public class OtherReportServices
    {
        [TestMethod]
        public void StudentOnCourseMapping_XXX_YYY()
        {
            var studentOnCourseToMap = new StudentOnCourseDto()
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

            var expectedStudentOnCourse = new StudentOnCourse()
            {
                Id = 44,
                Student = new Student()
                {
                    Id = 4,
                    Name = "Mateusz",
                    Surname = "Szwaba",
                    BirthDate = DateTime.Parse("05/01/1989"),
                    Gender = "male",
                    Pesel = 89050102345,
                },
                Course = new Course()
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

            var resultOfMapping = DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseToMap);


            Assert.IsTrue(expectedStudentOnCourse.Equals(resultOfMapping));
        }




        [TestMethod]
        public void CourseDayServiceGetAttendance_StudentOnCourse_CourseDayList()
        {
            var courseDayRepositoryMock = new Mock<ICourseDayRepository>();

            courseDayRepositoryMock.Setup(x => x.GetAttendance(It.IsAny<StudentOnCourse>()))
                .Returns(new List<CourseDay>());

            var studentOnCourseDto = new StudentOnCourseDto()
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

            var courseDayService = new CourseDayServices(courseDayRepositoryMock.Object);
            var result = courseDayService.GetAttendanceTest(studentOnCourseDto);

            var expectedResult = new List<CourseDayDto>();

            Assert.AreEqual(result.Count, expectedResult.Count);
            courseDayRepositoryMock.Verify(x => x.GetAttendance(DtoToEntity.StudentOnCourseDtoToEntity(
                studentOnCourseDto)));

        }
    }
}
