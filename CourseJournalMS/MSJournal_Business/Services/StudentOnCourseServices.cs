using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Business.Services.ServicesInterfaces;
using MSJournal_Data.Repository;
using MSJournal_Data.Repository.Interfaces;

namespace MSJournal_Business.Services
{
    public class StudentOnCourseServices : IStudentOnCourseServices
    {
        private IStudentOnCourseRepository _studentOnCourseRepository;

        public StudentOnCourseServices()
        {
            _studentOnCourseRepository = new StudentOnCourseRepository();
        }

        public StudentOnCourseServices(IStudentOnCourseRepository studentOnCourseRepository)
        {
            _studentOnCourseRepository = studentOnCourseRepository;
        }

        public bool AddStudentToCourse(StudentOnCourseDto studentOnCourseDto)
        {
            var courseServices = new CourseServices();
            var studentServices = new StudentServices();

            var canCombine = true;
                canCombine &= courseServices.Exist(studentOnCourseDto.Course);
                canCombine &= studentServices.Exist(studentOnCourseDto.Student);

            if (!canCombine)
                return false;

            return _studentOnCourseRepository.AddStudentToCourse(
                DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseDto));
        }

        public bool RemoveStudentFromCourse(StudentOnCourseDto studentOnCourseDto)
        {
            return _studentOnCourseRepository
               .RemoveStudentFromCourse(DtoToEntity
               .StudentOnCourseDtoToEntity(studentOnCourseDto));
        }

        public List<StudentOnCourseDto> StudentsListOnCourse(CourseDto course)
        {
            return _studentOnCourseRepository
                .StudentsListOnCourse(DtoToEntity.CourseDtoToEntity(course))
                .Select(EntityToDto.StudentOnCourseEntityToDto)
                .ToList();
        }

        public bool CheckAttendance(StudentOnCourseDto studentOnCourseDto, List<CourseDayDto> attendanceList)
        {
            if (attendanceList.Count == 0)
            {
                return false;
            }

            studentOnCourseDto.Student.PresentDays = 0;
            studentOnCourseDto.Student.CourseDays = 0;
            studentOnCourseDto.Student.AttendanceOk = false;
            studentOnCourseDto.Student.StudentAttendance = 0;

            foreach (var entry in attendanceList)
            {
                if (entry.Attendance == "present")
                {
                    studentOnCourseDto.Student.PresentDays++;
                }
                studentOnCourseDto.Student.CourseDays++;
            }

            studentOnCourseDto.Student.StudentAttendance = 100.0d
                * studentOnCourseDto.Student.PresentDays 
                    / attendanceList.Count;

            if (studentOnCourseDto.Student.StudentAttendance 
                    >= studentOnCourseDto.Course.PresenceThreshold)
            {
                studentOnCourseDto.Student.AttendanceOk = true;
            }
            else
            {
                studentOnCourseDto.Student.AttendanceOk = false;
            }
            return true;
        }
        
        public bool CheckHomework(StudentOnCourseDto studentOnCourseDto, List<HomeworkDto> homeworkList)
        {
            if (homeworkList.Count == 0)
            {
                return false;
            }

            studentOnCourseDto.Student.HomeworkPoints = 0;
            studentOnCourseDto.Student.HomeworkMaxPoints = 0;
            
            foreach (var homework in homeworkList)
            {
                studentOnCourseDto.Student.HomeworkPoints += homework.StudentPoints;
                studentOnCourseDto.Student.HomeworkMaxPoints += homework.MaxPoints;
            }

            studentOnCourseDto.Student.HomeworkPerformance = 100.0d
                * studentOnCourseDto.Student.HomeworkPoints 
                    / studentOnCourseDto.Student.HomeworkMaxPoints;
               
            if (studentOnCourseDto.Student.HomeworkPerformance >= studentOnCourseDto.Course.HomeworkThreshold)
            {
                studentOnCourseDto.Student.HomeworkOk = true;
            }
            else
            {
                studentOnCourseDto.Student.HomeworkOk = false;
            }

            return true;
        }

        public bool Exist(StudentOnCourseDto studentOnCourseDto)
        {
            return _studentOnCourseRepository
                .Exist(DtoToEntity.StudentOnCourseDtoToEntity(studentOnCourseDto));
        }

    }
}
