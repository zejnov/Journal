using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Data.Repository;

namespace MSJournal_Business.Services
{
    public class StudentOnCourseServices
    {
        public static bool AddStudentToCourse(StudentOnCourseDto studentOnCourseDto)
        {
            var canCombine = true;
                canCombine &= CourseServices.Exist(studentOnCourseDto.Course);
                canCombine &= StudentServices.Exist(studentOnCourseDto.Student);

            if (!canCombine)
                return false;

            return new StudentOnCourseRepository().AddStudentToCourse(
                DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseDto));
        }

        public static bool RemoveStudentFromCourse(StudentOnCourseDto studentOnCourseDto)
        {
            return new StudentOnCourseRepository()
               .RemoveStudentFromCourse(DtoToEntity
               .StudentOnCourseDtoToEntity(studentOnCourseDto));

        }

        public static List<StudentOnCourseDto> StudentsListOnCourse(CourseDto course)
        {
            return new StudentOnCourseRepository()
                .StudentsListOnCourse(DtoToEntity.CourseDtoToEntity(course))
                .Select(EntityToDto.StudentOnCourseEntityToDto)
                .ToList();
        }

        public static bool CheckAttendance(StudentOnCourseDto studentOnCourseDto)
        {
                //var student = courseDto.Student;
                //var attendanceList = courseDto.AttendanceList;

                //student.PresentDays = 0;
                //student.AttendanceOk = false;
                //student.StudentAttendance = 0;

                //if (attendanceList.Count != 0)
                //{
                //    foreach (var day in attendanceList)
                //    {
                //        if (day.Attendance == "present")
                //        {
                //            student.PresentDays++;
                //        }
                //    }
                //    student.StudentAttendance = 100.0d
                //                                   * student.PresentDays / studentAttendanceList.Count;
                //}

                //if (student.StudentAttendance >= courseDto.PresenceThreshold)
                //{
                //    student.AttendanceOk = true;
                //}
                //else
                //{
                //    student.AttendanceOk = false;
                //}
            

            return true;
        }
        
        public bool CheckHomework(StudentOnCourseDto studentOnCourseDto)
        {
            //foreach (var studentDto in courseDto.CourseStudentsList)
            //{
            //    var studentHomeworkList = CourseServices
            //        .GetStudentHomework(courseDto, studentDto.Id);

            //    studentDto.HomeworkPoints = 0;
            //    studentDto.HomeworkMaxPoints = 0;

            //    if (studentHomeworkList.Count != 0)
            //    {
            //        foreach (var homework in studentHomeworkList)
            //        {
            //            studentDto.HomeworkPoints += homework.StudentPoints;
            //            studentDto.HomeworkMaxPoints += homework.MaxPoints;
            //        }
            //        studentDto.HomeworkPerformance = 100.0d
            //                                         * studentDto.HomeworkPoints / studentHomeworkList.Count;
            //    }

            //    if (studentDto.HomeworkPerformance >= courseDto.HomeworkThreshold)
            //    {
            //        studentDto.HomeworkOk = true;
            //    }
            //    else
            //    {
            //        studentDto.HomeworkOk = false;
            //    }
            //}

            return true;
        }

        public static bool Exist(StudentOnCourseDto studentOnCourseDto)
        {
            return new StudentOnCourseRepository()
                .Exist(DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseDto));
        }

    }
}
