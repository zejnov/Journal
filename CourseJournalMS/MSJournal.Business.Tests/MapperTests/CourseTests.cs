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

            Assert.IsTrue(resultOfMapping.Equals(expectedCourse));
        }

        [TestMethod]
        public void CourseMapping_ProvideNullCourseDto_ReceiveNullCourse()
        {
            var courseToMap = new CourseDto();
            courseToMap = null;

            var expectedCourse = new Course();
            expectedCourse = null;

            var resultOfMapping = DtoToEntity.CourseDtoToEntity(courseToMap);

            Assert.IsTrue(resultOfMapping.Equals(expectedCourse));
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

            Assert.IsTrue(resultOfMapping.Equals(expectedCourse));
        }

        [TestMethod]
        public void CourseMapping_ProvideNullCourse_ReceiveNullCourseDto()
        {
            var courseToMap = new Course();
            courseToMap = null;
            var expectedCourse = new CourseDto();
            expectedCourse = null;

            var resultOfMapping = EntityToDto.CourseEntityToDto(courseToMap);

            Assert.IsTrue(resultOfMapping.Equals(expectedCourse));
        }

    }
}
