using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;
using MSJournal_Data.Repositories;

namespace MSJournal_Business.Mappers
{
    internal class CheckingFunctions
    {
        public static void CheckAttendance(Student student)
        {
            var courseRepository = new CourseRepository();
            var course = courseRepository.ActiveCourse();

            student.PresentDays = 0;
            student.StudentAttendance = 0;

            if (student.AttendanceList.Count != 0)
            {
                foreach (var day in student.AttendanceList)
                {
                    if (day.Attendance == "present")
                    {
                        student.PresentDays++;
                    }
                }
                student.StudentAttendance = 100.0 * student.PresentDays / student.AttendanceList.Count;
            }
            
            if (student.StudentAttendance >= course.PresenceThreshold)
                student.AttendanceOk = true;
            student.AttendanceOk = false;
        }


        public static void CheckHomework(Student student)
        {
            var courseRepository = new CourseRepository();
            var course = courseRepository.ActiveCourse();

            student.HomeworkPoints = 0;
            student.HomeworkMaxPoints = 0;

            foreach (var homework in student.HomeworksList)
            {
                student.HomeworkMaxPoints += homework.MaxHomeworkPoints;
                student.HomeworkPoints += homework.StudentHomeworkPoints;
            }

            student.HomeworkPerformance = 100.0 * student.HomeworkPoints / student.HomeworkMaxPoints;
            if (student.HomeworkPerformance >= course.HomeworkThreshold)
                student.HomeworksOk = true;
            student.HomeworksOk = false;


        }
    }
}
