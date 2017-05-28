using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Data.Repositories
{
    public class CourseRepository
    {
        public Course ActiveCourse()
        {
            if (Dane.Journal.Count != 0)
            {
                return Dane.Journal[Course.ChoosenCourse];
            }
            else
            {
                Console.WriteLine("There is no course in journal");
                return null;
            }
        }

        public void AddStudentToCourseList(int id)
        {
            var student = Dane.StudentsList[id];
            ActiveCourse().CourseStudentsList.Add(student);
        }

        public void AddDayOfCourseToStudent(int studentId, CourseDay day)
        {
            ActiveCourse().CourseStudentsList[studentId].AttendanceList.Add(day);
        }

        public void AddHomeworkToStudent(int studentId, Homework homework)
        {
            ActiveCourse().CourseStudentsList[studentId].HomeworksList.Add(homework);
        }


        
    }
}
