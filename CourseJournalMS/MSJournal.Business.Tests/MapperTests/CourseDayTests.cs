using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Data.Models;

namespace MSJournal.Business.Tests.MapperTests
{
    [TestClass]
    public class CourseDayTests
    {
        [TestMethod]
        public void CourseDayMapping_ProvideValidModelDto_ReceiveProperlyMappedModel()
        {
            var courseDayToMap = new CourseDayDto()
            {
                Id = 44,
                Attendance = "present",

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

            var expectedCourseDay = new CourseDay()
            {
                Id = 44,
                Attendance = "present",

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

            var resultOfMapping = DtoToEntity.CourseDayDtoToEntity(courseDayToMap);


            Assert.AreEqual(expectedCourseDay.Id, resultOfMapping.Id);
            Assert.AreEqual(expectedCourseDay.Attendance, resultOfMapping.Attendance);
            

            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.Id, resultOfMapping.StudentOnCourse.Course.Id);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.Name, resultOfMapping.StudentOnCourse.Course.Name);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.LeaderName, resultOfMapping.StudentOnCourse.Course.LeaderName);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.LeaderSurname, resultOfMapping.StudentOnCourse.Course.LeaderSurname);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.HomeworkThreshold, resultOfMapping.StudentOnCourse.Course.HomeworkThreshold);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.PresenceThreshold, resultOfMapping.StudentOnCourse.Course.PresenceThreshold);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.StartDate, resultOfMapping.StudentOnCourse.Course.StartDate);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.StudentsNumber, resultOfMapping.StudentOnCourse.Course.StudentsNumber);

            Assert.AreEqual(courseDayToMap.StudentOnCourse.Student.Id, resultOfMapping.StudentOnCourse.Student.Id);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Student.Name, resultOfMapping.StudentOnCourse.Student.Name);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Student.Surname, resultOfMapping.StudentOnCourse.Student.Surname);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Student.BirthDate, resultOfMapping.StudentOnCourse.Student.BirthDate);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Student.Gender, resultOfMapping.StudentOnCourse.Student.Gender);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Student.Pesel, resultOfMapping.StudentOnCourse.Student.Pesel);
        }

        [TestMethod]
        public void CourseDayMapping_ProvideValidModel_ReceiveProperlyMappedModelDto()
        {
            var courseDayToMap = new CourseDay()
            {
                Id = 44,
                Attendance = "present",

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

            var expectedCourseDay = new CourseDayDto()
            {
                Id = 44,
                Attendance = "present",

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

            var resultOfMapping = EntityToDto.CourseDayEntityToDto(courseDayToMap);

            Assert.AreEqual(expectedCourseDay.Id, resultOfMapping.Id);
            Assert.AreEqual(expectedCourseDay.Attendance, resultOfMapping.Attendance);
            
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.Id, resultOfMapping.StudentOnCourse.Course.Id);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.Name, resultOfMapping.StudentOnCourse.Course.Name);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.LeaderName, resultOfMapping.StudentOnCourse.Course.LeaderName);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.LeaderSurname, resultOfMapping.StudentOnCourse.Course.LeaderSurname);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.HomeworkThreshold, resultOfMapping.StudentOnCourse.Course.HomeworkThreshold);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.PresenceThreshold, resultOfMapping.StudentOnCourse.Course.PresenceThreshold);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.StartDate, resultOfMapping.StudentOnCourse.Course.StartDate);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Course.StudentsNumber, resultOfMapping.StudentOnCourse.Course.StudentsNumber);

            Assert.AreEqual(courseDayToMap.StudentOnCourse.Student.Id, resultOfMapping.StudentOnCourse.Student.Id);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Student.Name, resultOfMapping.StudentOnCourse.Student.Name);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Student.Surname, resultOfMapping.StudentOnCourse.Student.Surname);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Student.BirthDate, resultOfMapping.StudentOnCourse.Student.BirthDate);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Student.Gender, resultOfMapping.StudentOnCourse.Student.Gender);
            Assert.AreEqual(courseDayToMap.StudentOnCourse.Student.Pesel, resultOfMapping.StudentOnCourse.Student.Pesel);
        }

        [TestMethod]
        public void CourseDayMapping_ProvideNullDto_ReceiveNullModel()
        {
            var courseDayToMap = new CourseDayDto();
            courseDayToMap = null;

            var expectedCourseDay = new CourseDay();
            expectedCourseDay = null;

            var resultOfMapping = DtoToEntity.CourseDayDtoToEntity(courseDayToMap);

            Assert.AreEqual(expectedCourseDay, resultOfMapping);
        }

        [TestMethod]
        public void CourseDayMapping_ProvideNullModel_ReceiveNullModelDto()
        {
            var courseDayToMap = new CourseDay();
            courseDayToMap = null;

            var expectedCourseDay = new CourseDayDto();
            expectedCourseDay = null;

            var resultOfMapping = EntityToDto.CourseDayEntityToDto(courseDayToMap);

            Assert.AreEqual(expectedCourseDay, resultOfMapping);
        }
    }
}
