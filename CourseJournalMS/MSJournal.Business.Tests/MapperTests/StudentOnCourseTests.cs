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
    public class StudentOnCourseTests
    {
        [TestMethod]
        public void StudentOnCourseMapping_ProvideValidModelDto_ReceiveProperlyMappedModel()
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


            Assert.AreEqual(expectedStudentOnCourse.Id, resultOfMapping.Id);

            Assert.AreEqual(expectedStudentOnCourse.Course.Id, resultOfMapping.Course.Id);
            Assert.AreEqual(expectedStudentOnCourse.Course.Name, resultOfMapping.Course.Name);
            Assert.AreEqual(expectedStudentOnCourse.Course.LeaderName, resultOfMapping.Course.LeaderName);
            Assert.AreEqual(expectedStudentOnCourse.Course.LeaderSurname, resultOfMapping.Course.LeaderSurname);
            Assert.AreEqual(expectedStudentOnCourse.Course.HomeworkThreshold, resultOfMapping.Course.HomeworkThreshold);
            Assert.AreEqual(expectedStudentOnCourse.Course.PresenceThreshold, resultOfMapping.Course.PresenceThreshold);
            Assert.AreEqual(expectedStudentOnCourse.Course.StartDate, resultOfMapping.Course.StartDate);
            Assert.AreEqual(expectedStudentOnCourse.Course.StudentsNumber, resultOfMapping.Course.StudentsNumber);

            Assert.AreEqual(expectedStudentOnCourse.Student.Id, resultOfMapping.Student.Id);
            Assert.AreEqual(expectedStudentOnCourse.Student.Name, resultOfMapping.Student.Name);
            Assert.AreEqual(expectedStudentOnCourse.Student.Surname, resultOfMapping.Student.Surname);
            Assert.AreEqual(expectedStudentOnCourse.Student.BirthDate, resultOfMapping.Student.BirthDate);
            Assert.AreEqual(expectedStudentOnCourse.Student.Gender, resultOfMapping.Student.Gender);
            Assert.AreEqual(expectedStudentOnCourse.Student.Pesel, resultOfMapping.Student.Pesel);
        }

        [TestMethod]
        public void StudentOnCourseMapping_ProvideValidModel_ReceiveProperlyMappedModelDto()
        {
            var studentOnCourseToMap = new StudentOnCourse()
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

            var expectedStudentOnCourse = new StudentOnCourseDto()
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

            var resultOfMapping = EntityToDto.StudentOnCourseEntityToDto(studentOnCourseToMap);


            Assert.AreEqual(expectedStudentOnCourse.Id, resultOfMapping.Id);

            Assert.AreEqual(expectedStudentOnCourse.Course.Id, resultOfMapping.Course.Id);
            Assert.AreEqual(expectedStudentOnCourse.Course.Name, resultOfMapping.Course.Name);
            Assert.AreEqual(expectedStudentOnCourse.Course.LeaderName, resultOfMapping.Course.LeaderName);
            Assert.AreEqual(expectedStudentOnCourse.Course.LeaderSurname, resultOfMapping.Course.LeaderSurname);
            Assert.AreEqual(expectedStudentOnCourse.Course.HomeworkThreshold, resultOfMapping.Course.HomeworkThreshold);
            Assert.AreEqual(expectedStudentOnCourse.Course.PresenceThreshold, resultOfMapping.Course.PresenceThreshold);
            Assert.AreEqual(expectedStudentOnCourse.Course.StartDate, resultOfMapping.Course.StartDate);
            Assert.AreEqual(expectedStudentOnCourse.Course.StudentsNumber, resultOfMapping.Course.StudentsNumber);

            Assert.AreEqual(expectedStudentOnCourse.Student.Id, resultOfMapping.Student.Id);
            Assert.AreEqual(expectedStudentOnCourse.Student.Name, resultOfMapping.Student.Name);
            Assert.AreEqual(expectedStudentOnCourse.Student.Surname, resultOfMapping.Student.Surname);
            Assert.AreEqual(expectedStudentOnCourse.Student.BirthDate, resultOfMapping.Student.BirthDate);
            Assert.AreEqual(expectedStudentOnCourse.Student.Gender, resultOfMapping.Student.Gender);
            Assert.AreEqual(expectedStudentOnCourse.Student.Pesel, resultOfMapping.Student.Pesel);
        }

        [TestMethod]
        public void StudentOnCourseMapping_ProvideNullModelDto_ReceiveNullModel()
        {
            var studentOnCourseToMap = new StudentOnCourseDto();
            studentOnCourseToMap = null;

            var expectedStudentOnCourse = new StudentOnCourse();
            expectedStudentOnCourse = null;

            var resultOfMapping = DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseToMap);
            
            Assert.AreEqual(expectedStudentOnCourse, resultOfMapping);
           
        }

        [TestMethod]
        public void StudentOnCourseMapping_ProvideNullModel_ReceiveNullModelDto()
        {
            var studentOnCourseToMap = new StudentOnCourse();
            studentOnCourseToMap = null;

            var expectedStudentOnCourse = new StudentOnCourseDto();
            expectedStudentOnCourse = null;

            var resultOfMapping = EntityToDto.StudentOnCourseEntityToDto(studentOnCourseToMap);
            
            Assert.AreEqual(expectedStudentOnCourse, resultOfMapping);
        }
    }
}
