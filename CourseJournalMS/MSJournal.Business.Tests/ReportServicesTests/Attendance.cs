using System;
using System.Collections.Generic;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSJournal_Business.Services;
using MSJournal_Data.Models;
using MSJournal_Data.Repository.Interfaces;

namespace MSJournal.Business.Tests.ReportServicesTests
{
    [TestClass]
    public class Attendance
    {
        [TestMethod]
        public void CourseDayServiceGetAttendance_StudentOnCourse_CourseDayList()
        {
            var courseDayRepositoryMock = new Mock<ICourseDayRepository>();
            courseDayRepositoryMock.Setup(x => x.GetAttendance(It.IsAny<StudentOnCourse>()))
                .Returns(new List<CourseDay>());

            var courseDayService = new CourseDayServices(courseDayRepositoryMock.Object);

        }
    }
}
