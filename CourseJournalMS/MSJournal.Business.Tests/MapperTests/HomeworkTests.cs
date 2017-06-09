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
    public class HomeworkTests
    {
        [TestMethod]
        public void HomeworkMapping_ProvideValidModelDto_ReceiveProperlyMappedModel()
        {
            var homeworkToMap = new HomeworkDto()
            {
                Id = 44,
                StudentPoints = 33,
                MaxPoints = 50,
                StudentOnCourse = new StudentOnCourseDto()
                {
                    Id = 7,
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
                },
            };

            var expectedHomework = new Homework()
            {
                Id = 44,
                StudentPoints = 33,
                MaxPoints = 50,
                StudentOnCourse = new StudentOnCourse()
                {
                    Id = 7,
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
                },
            };

            ////////////////////////////
            
            var resultOfMapping = DtoToEntity.HomeworkDtoToEntity(homeworkToMap);


            Assert.AreEqual(expectedHomework.Id, resultOfMapping.Id);
            Assert.AreEqual(expectedHomework.StudentPoints, resultOfMapping.StudentPoints);
            Assert.AreEqual(expectedHomework.MaxPoints, resultOfMapping.MaxPoints);

            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.Id, resultOfMapping.StudentOnCourse.Course.Id);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.Name, resultOfMapping.StudentOnCourse.Course.Name);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.LeaderName, resultOfMapping.StudentOnCourse.Course.LeaderName);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.LeaderSurname, resultOfMapping.StudentOnCourse.Course.LeaderSurname);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.HomeworkThreshold, resultOfMapping.StudentOnCourse.Course.HomeworkThreshold);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.PresenceThreshold, resultOfMapping.StudentOnCourse.Course.PresenceThreshold);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.StartDate, resultOfMapping.StudentOnCourse.Course.StartDate);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.StudentsNumber, resultOfMapping.StudentOnCourse.Course.StudentsNumber);

            Assert.AreEqual(homeworkToMap.StudentOnCourse.Student.Id, resultOfMapping.StudentOnCourse.Student.Id);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Student.Name, resultOfMapping.StudentOnCourse.Student.Name);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Student.Surname, resultOfMapping.StudentOnCourse.Student.Surname);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Student.BirthDate, resultOfMapping.StudentOnCourse.Student.BirthDate);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Student.Gender, resultOfMapping.StudentOnCourse.Student.Gender);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Student.Pesel, resultOfMapping.StudentOnCourse.Student.Pesel);
        }

        [TestMethod]
        public void HomeworkMapping_ProvideValidModel_ReceiveProperlyMappedModelDto()
        {
            var homeworkToMap = new Homework()
            {
                Id = 44,
                StudentPoints = 33,
                MaxPoints = 50,
                StudentOnCourse = new StudentOnCourse()
                {
                    Id = 7,
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
                },
            };

            var expectedHomework = new HomeworkDto()
            {
                Id = 44,
                StudentPoints = 33,
                MaxPoints = 50,
                StudentOnCourse = new StudentOnCourseDto()
                {
                    Id = 7,
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
                },
            };

            ////////////////////////////

            var resultOfMapping = EntityToDto.HomeworkEntityToDto(homeworkToMap);
            
            Assert.AreEqual(expectedHomework.Id, resultOfMapping.Id);
            Assert.AreEqual(expectedHomework.StudentPoints, resultOfMapping.StudentPoints);
            Assert.AreEqual(expectedHomework.MaxPoints, resultOfMapping.MaxPoints);

            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.Id, resultOfMapping.StudentOnCourse.Course.Id);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.Name, resultOfMapping.StudentOnCourse.Course.Name);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.LeaderName, resultOfMapping.StudentOnCourse.Course.LeaderName);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.LeaderSurname, resultOfMapping.StudentOnCourse.Course.LeaderSurname);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.HomeworkThreshold, resultOfMapping.StudentOnCourse.Course.HomeworkThreshold);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.PresenceThreshold, resultOfMapping.StudentOnCourse.Course.PresenceThreshold);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.StartDate, resultOfMapping.StudentOnCourse.Course.StartDate);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Course.StudentsNumber, resultOfMapping.StudentOnCourse.Course.StudentsNumber);

            Assert.AreEqual(homeworkToMap.StudentOnCourse.Student.Id, resultOfMapping.StudentOnCourse.Student.Id);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Student.Name, resultOfMapping.StudentOnCourse.Student.Name);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Student.Surname, resultOfMapping.StudentOnCourse.Student.Surname);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Student.BirthDate, resultOfMapping.StudentOnCourse.Student.BirthDate);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Student.Gender, resultOfMapping.StudentOnCourse.Student.Gender);
            Assert.AreEqual(homeworkToMap.StudentOnCourse.Student.Pesel, resultOfMapping.StudentOnCourse.Student.Pesel);
        }

        [TestMethod]
        public void HomeworkMapping_ProvideNullDto_ReceiveNullModel()
        {
            var homeworkToMap = new HomeworkDto();
            homeworkToMap = null;

            var expectedHomework = new Homework();
            expectedHomework = null;

            var resultOfMapping = DtoToEntity.HomeworkDtoToEntity(homeworkToMap);

            Assert.AreEqual(expectedHomework, resultOfMapping);
            }

        [TestMethod]
        public void HomeworkMapping_ProvideNullModel_ReceiveNullModelDto()
        {
            var homeworkToMap = new Homework();
            homeworkToMap = null;

            var expectedHomework = new HomeworkDto();
            expectedHomework = null;
            
            var resultOfMapping = EntityToDto.HomeworkEntityToDto(homeworkToMap);

            Assert.AreEqual(expectedHomework, resultOfMapping);
        }
    }
}
