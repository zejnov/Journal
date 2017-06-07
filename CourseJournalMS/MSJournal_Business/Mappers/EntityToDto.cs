﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Data.Models;

namespace MSJournal_Business.Mappers
{
    class EntityToDto
    {
        public static StudentDto StudentEntityToDto(Student student)
        {
            if (student == null)
            {
                return null;
            }

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Surname = student.Surname,
                Gender = student.Gender,
                BirthDate = student.BirthDate,
                Pesel = student.Pesel,
            };
        }

        public static CourseDto CourseEntityToDto(Course course)
        {
            if (course == null)
            {
                return null;
            }

            return new CourseDto()
            {
                Id = course.Id,
                Name = course.Name,
                LeaderName = course.LeaderName,
                LeaderSurname = course.LeaderSurname,
                StartDate = course.StartDate,
                HomeworkThreshold = course.HomeworkThreshold,
                PresenceThreshold = course.PresenceThreshold,
                StudentsNumber = course.StudentsNumber,

                //StudentOnCourse = course.StudentOnCourse
                //.Select(StudentOnCourseEntityToDto)
                //.ToList()

            };
        }

        public static CourseDto CourseWithoutListEntityToDto(Course course)
        {
            if (course == null)
            {
                return null;
            }

            return new CourseDto()
            {
                Id = course.Id,
                Name = course.Name,
                LeaderName = course.LeaderName,
                LeaderSurname = course.LeaderSurname,
                StartDate = course.StartDate,
                HomeworkThreshold = course.HomeworkThreshold,
                PresenceThreshold = course.PresenceThreshold,
                StudentsNumber = course.StudentsNumber,
            };
        }

        public static StudentOnCourseDto StudentOnCourseEntityToDto(StudentOnCourse studentOnCourse)
        {
            if (studentOnCourse == null)
            {
                return null;
            }

            return new StudentOnCourseDto()
            {
                Id = studentOnCourse.Id,
                Course = CourseWithoutListEntityToDto(studentOnCourse.Course),
                Student = StudentEntityToDto(studentOnCourse.Student),
                AttendanceList = studentOnCourse.AttendanceList
                    .Select(CourseDayEntityToDto)
                    .ToList(),
                HomeworksList = studentOnCourse.HomeworksList
                    .Select(HomeworkEntityToDto)
                    .ToList(),
            };
        }

        public static HomeworkDto HomeworkEntityToDto(Homework homework)
        {
            if (homework == null)
            {
                return null;
            }

            return new HomeworkDto()
            {
                Id = homework.Id,
                StudentPoints = homework.StudentPoints,
                MaxPoints = homework.MaxPoints,
            };
        }

        public static CourseDayDto CourseDayEntityToDto(CourseDay courseDay)
        {
            if (courseDay == null)
            {
                return null;
            }

            return new CourseDayDto()
            {
                Id = courseDay.Id,
                Attendance = courseDay.Attendance,
            };

        }
    }//
}
