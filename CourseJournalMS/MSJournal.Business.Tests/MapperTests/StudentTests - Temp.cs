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
    public class StudentTests2
    {
        //funkcjonalność_coRobisz/dane wejsciowe_spodziewany wynik
        //double nCovera
        [TestMethod] 
        public void StudentMapping_FullMappingTest_ReciveStudentOrNull()
        {
            var studentToMap = new StudentDto()
            {
                Id = 4,
                Name = "Mateusz",
                Surname = "Szwaba",
                BirthDate = DateTime.Parse("05/01/1989"),
                Gender = "male",
                Pesel = 89050102345,
            };

            var expectedStudent = new Student()
            {
                Id = 4,
                Name = "Mateusz",
                Surname = "Szwaba",
                BirthDate = DateTime.Parse("05/01/1989"),
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

        
            var studentToMap2 = new Student()
            {
                Id = 4,
                Name = "Mateusz",
                Surname = "Szwaba",
                BirthDate = DateTime.Parse("01/05/1989"),
                Gender = "male",
                Pesel = 89050102345,
            };

            var expectedStudent2 = new StudentDto()
            {
                Id = 4,
                Name = "Mateusz",
                Surname = "Szwaba",
                BirthDate = DateTime.Parse("01/05/1989"),
                Gender = "male",
                Pesel = 89050102345,
            };

            var resultOfMapping2 = EntityToDto.StudentEntityToDto(studentToMap2);

            Assert.AreEqual(expectedStudent2.Id, resultOfMapping2.Id);
            Assert.AreEqual(expectedStudent2.Name, resultOfMapping2.Name);
            Assert.AreEqual(expectedStudent2.Surname, resultOfMapping2.Surname);
            Assert.AreEqual(expectedStudent2.BirthDate, resultOfMapping2.BirthDate);
            Assert.AreEqual(expectedStudent2.Gender, resultOfMapping2.Gender);
            Assert.AreEqual(expectedStudent2.Pesel, resultOfMapping2.Pesel);

            var studentToMap3 = new Student();
            studentToMap3 = null;
            var expectedStudent3 = new StudentDto();
            expectedStudent3 = null;

            var resultOfMapping3 = EntityToDto.StudentEntityToDto(studentToMap3);

            Assert.AreEqual(expectedStudent3, resultOfMapping3);

            var studentToMap4 = new StudentDto();
            studentToMap4 = null;
            var expectedStudent4 = new Student();
            expectedStudent4 = null;

            var resultOfMapping4 = DtoToEntity.StudentDtoToEntity(studentToMap4);

            Assert.AreEqual(expectedStudent4, resultOfMapping4);
        }
    }
}

