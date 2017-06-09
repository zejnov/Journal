using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Business.Services;
using MSJournal_Data.Models;

namespace MSJournal.Business.Tests.MapperTests
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void CourseMapping_ProvideValidCourseDto_ReceiveProperlyMappedCourse()
        {
            var courseToMap = new CourseDto()
            {
                Id = 7,
                Name = "Codementors",
                LeaderName = "Jakub",
                LeaderSurname = "Bulczak",
                StartDate = DateTime.Parse("04/24/2017"),
                HomeworkThreshold = 80,
                PresenceThreshold = 90,
                StudentsNumber = 12,
            };

            var expectedCourse = new Course()
            {
                Id = 7,
                Name = "Codementors",
                LeaderName = "Jakub",
                LeaderSurname = "Bulczak",
                StartDate = DateTime.Parse("04/24/2017"),
                HomeworkThreshold = 80,
                PresenceThreshold = 90,
                StudentsNumber = 12,
            };

            var resultOfMapping = DtoToEntity.CourseDtoToEntity(courseToMap);

            Assert.AreEqual(expectedCourse.Id, resultOfMapping.Id);
            Assert.AreEqual(expectedCourse.Name, resultOfMapping.Name);
            Assert.AreEqual(expectedCourse.LeaderName, resultOfMapping.LeaderName);
            Assert.AreEqual(expectedCourse.LeaderSurname, resultOfMapping.LeaderSurname);
            Assert.AreEqual(expectedCourse.StartDate, resultOfMapping.StartDate);
            Assert.AreEqual(expectedCourse.HomeworkThreshold, resultOfMapping.HomeworkThreshold);
            Assert.AreEqual(expectedCourse.PresenceThreshold, resultOfMapping.PresenceThreshold);
            Assert.AreEqual(expectedCourse.StudentsNumber, resultOfMapping.StudentsNumber);
        }

        [TestMethod]
        public void CourseMapping_ProvideNullCourseDto_ReceiveNullCourse()
        {
            var courseToMap = new CourseDto();
            var expectedCourse = new Course();

            var resultOfMapping = DtoToEntity.CourseDtoToEntity(courseToMap);

            Assert.AreEqual(expectedCourse.Id, resultOfMapping.Id);
            Assert.AreEqual(expectedCourse.Name, resultOfMapping.Name);
            Assert.AreEqual(expectedCourse.LeaderName, resultOfMapping.LeaderName);
            Assert.AreEqual(expectedCourse.LeaderSurname, resultOfMapping.LeaderSurname);
            Assert.AreEqual(expectedCourse.StartDate, resultOfMapping.StartDate);
            Assert.AreEqual(expectedCourse.HomeworkThreshold, resultOfMapping.HomeworkThreshold);
            Assert.AreEqual(expectedCourse.PresenceThreshold, resultOfMapping.PresenceThreshold);
            Assert.AreEqual(expectedCourse.StudentsNumber, resultOfMapping.StudentsNumber);
        }

        [TestMethod]
        public void CourseMapping_ProvideValidCourse_ReceiveProperlyMappedCourseDto()
        {
            var courseToMap = new Course()
            {
                Id = 7,
                Name = "Codementors",
                LeaderName = "Jakub",
                LeaderSurname = "Bulczak",
                StartDate = DateTime.Parse("04/24/2017"),
                HomeworkThreshold = 80,
                PresenceThreshold = 90,
                StudentsNumber = 12,
            };

            var expectedCourse = new CourseDto()
            {
                Id = 7,
                Name = "Codementors",
                LeaderName = "Jakub",
                LeaderSurname = "Bulczak",
                StartDate = DateTime.Parse("04/24/2017"),
                HomeworkThreshold = 80,
                PresenceThreshold = 90,
                StudentsNumber = 12,
            };

            var resultOfMapping = EntityToDto.CourseEntityToDto(courseToMap);

            Assert.AreEqual(expectedCourse.Id, resultOfMapping.Id);
            Assert.AreEqual(expectedCourse.Name, resultOfMapping.Name);
            Assert.AreEqual(expectedCourse.LeaderName, resultOfMapping.LeaderName);
            Assert.AreEqual(expectedCourse.LeaderSurname, resultOfMapping.LeaderSurname);
            Assert.AreEqual(expectedCourse.StartDate, resultOfMapping.StartDate);
            Assert.AreEqual(expectedCourse.HomeworkThreshold, resultOfMapping.HomeworkThreshold);
            Assert.AreEqual(expectedCourse.PresenceThreshold, resultOfMapping.PresenceThreshold);
            Assert.AreEqual(expectedCourse.StudentsNumber, resultOfMapping.StudentsNumber);
        }

        [TestMethod]
        public void CourseMapping_ProvideNullCourse_ReceiveNullCourseDto()
        {
            var courseToMap = new Course();
            var expectedCourse = new CourseDto();

            var resultOfMapping = EntityToDto.CourseEntityToDto(courseToMap);

            Assert.AreEqual(expectedCourse.Id, resultOfMapping.Id);
            Assert.AreEqual(expectedCourse.Name, resultOfMapping.Name);
            Assert.AreEqual(expectedCourse.LeaderName, resultOfMapping.LeaderName);
            Assert.AreEqual(expectedCourse.LeaderSurname, resultOfMapping.LeaderSurname);
            Assert.AreEqual(expectedCourse.StartDate, resultOfMapping.StartDate);
            Assert.AreEqual(expectedCourse.HomeworkThreshold, resultOfMapping.HomeworkThreshold);
            Assert.AreEqual(expectedCourse.PresenceThreshold, resultOfMapping.PresenceThreshold);
            Assert.AreEqual(expectedCourse.StudentsNumber, resultOfMapping.StudentsNumber);
        }

    }
}
