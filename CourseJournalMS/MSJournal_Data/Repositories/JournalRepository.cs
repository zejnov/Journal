using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Data.Repositories
{
    public class JournalRepository
    {
        public void AddStudentToJournalList(Student student)
        {
            Dane.StudentsList[student.Id] = student;
        }


        public void AddCourseToJournal(Course course)
        {
            Dane.Journal[course.Id] = course;
        }
    }
}
