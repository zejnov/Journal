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
    public class StudentTests
    {
        //funkcjonalność_coRobisz/dane wejsciowe_spodziewany wynik

        [TestMethod] 
        public void StudentMapping_ProvideValidStudentDto_ReceiveProperlyMappedStudent()
        {
            var studentToMap = new StudentDto()
            {
                Id = 4,
                Name = "Mateusz",
                Surname = "Szwaba",
                BirthDate = DateTime.Parse("01/05/1989"),
                Gender = "male",
                Pesel = 89050102345,
            };

            var expectedStudent = new Student()
            {
                Id = 4,
                Name = "Mateusz",
                Surname = "Szwaba",
                BirthDate = DateTime.Parse("01/05/1989"),
                Gender = "male",
                Pesel = 89050102345,
            };

            var resultOfMapping = DtoToEntity.StudentDtoToEntity(studentToMap);

            Assert.AreEqual(expectedStudent.Id, resultOfMapping.Id);
            Assert.AreEqual(expectedStudent.Name, resultOfMapping.Name);
            Assert.AreEqual(expectedStudent.Surname, resultOfMapping.Surname);
            Assert.AreEqual(expectedStudent.BirthDate, resultOfMapping.BirthDate);
            Assert.AreEqual(expectedStudent.Gender, resultOfMapping.Gender);
            Assert.AreEqual(expectedStudent.Pesel, resultOfMapping.Pesel);

        }

        [TestMethod]
        public void StudentMapping_ProvideNullStudentDto_ReceiveNullStudent()
        {
            var studentToMap = new StudentDto();
            var expectedStudent = new Student();
            
            var resultOfMapping = DtoToEntity.StudentDtoToEntity(studentToMap);

            Assert.AreEqual(expectedStudent.Id, resultOfMapping.Id);
            Assert.AreEqual(expectedStudent.Name, resultOfMapping.Name);
            Assert.AreEqual(expectedStudent.Surname, resultOfMapping.Surname);
            Assert.AreEqual(expectedStudent.BirthDate, resultOfMapping.BirthDate);
            Assert.AreEqual(expectedStudent.Gender, resultOfMapping.Gender);
            Assert.AreEqual(expectedStudent.Pesel, resultOfMapping.Pesel);

        }

        [TestMethod]
        public void StudentMapping_ProvideValidStudent_ReceiveProperlyMappedStudentDto()
        {
            var studentToMap = new Student()
            {
                Id = 4,
                Name = "Mateusz",
                Surname = "Szwaba",
                BirthDate = DateTime.Parse("01/05/1989"),
                Gender = "male",
                Pesel = 89050102345,
            };

            var expectedStudent = new StudentDto()
            {
                Id = 4,
                Name = "Mateusz",
                Surname = "Szwaba",
                BirthDate = DateTime.Parse("01/05/1989"),
                Gender = "male",
                Pesel = 89050102345,
            };

            var resultOfMapping = EntityToDto.StudentEntityToDto(studentToMap);

            Assert.AreEqual(expectedStudent.Id, resultOfMapping.Id);
            Assert.AreEqual(expectedStudent.Name, resultOfMapping.Name);
            Assert.AreEqual(expectedStudent.Surname, resultOfMapping.Surname);
            Assert.AreEqual(expectedStudent.BirthDate, resultOfMapping.BirthDate);
            Assert.AreEqual(expectedStudent.Gender, resultOfMapping.Gender);
            Assert.AreEqual(expectedStudent.Pesel, resultOfMapping.Pesel);

        }

        [TestMethod]
        public void StudentMapping_ProvideNullStudent_ReceiveNullStudentDto()
        {
            var studentToMap = new Student();
            var expectedStudent = new StudentDto();

            var resultOfMapping = EntityToDto.StudentEntityToDto(studentToMap);

            Assert.AreEqual(expectedStudent.Id, resultOfMapping.Id);
            Assert.AreEqual(expectedStudent.Name, resultOfMapping.Name);
            Assert.AreEqual(expectedStudent.Surname, resultOfMapping.Surname);
            Assert.AreEqual(expectedStudent.BirthDate, resultOfMapping.BirthDate);
            Assert.AreEqual(expectedStudent.Gender, resultOfMapping.Gender);
            Assert.AreEqual(expectedStudent.Pesel, resultOfMapping.Pesel);

        }
    }
}
