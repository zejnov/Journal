using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;
using MSJournal_Data.Repository.Basic;
using MSJournal_Data.Repository.Interfaces;

namespace MSJournal_Data.Repository
{
    public class StudentOnCourseRepository : BasicRepository<StudentOnCourse>, IStudentOnCourseRepository
    {
        public bool AddHomework(StudentOnCourse model, Homework homework)
        {
            return ExecuteQuery(dbContext =>
            {
               dbContext.HomeworkDbSet.Add(homework);

               dbContext.StudentOnCourseDbSet
                    .First(p => p.Student.Pesel == model.Student.Pesel 
                        && p.Course.Id == model.Course.Id)
                    .HomeworksList.Add(homework);

                model.HomeworksList.Add(homework); //>??
                return true;
            });
        }

        public bool AddCourseDay(StudentOnCourse model, CourseDay day)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.CoruseDayDbSet.Add(day);

                dbContext.StudentOnCourseDbSet
                    .First(p => p.Student.Pesel == model.Student.Pesel
                        && p.Course.Id == model.Course.Id)
                    .AttendanceList.Add(day);

                model.AttendanceList.Add(day);  //>??
                return true;
            });
        }
        
        public bool AddStudentToCourse(StudentOnCourse model)
        {
            return ExecuteQuery(dbContext =>
            {
                model.Student = dbContext.StudentDbSet
                    .First((p => p.Pesel == model.Student.Pesel));
                model.Course = dbContext.CourseDbSet
                    .First(p => p.Id == model.Course.Id);

                dbContext.StudentOnCourseDbSet.Add(model);

                dbContext.CourseDbSet
                .First(p=>p.Id == model.Course.Id)
                .StudentOnCourse.Add(model);
                
                return true;
            });
        }

        public bool RemoveStudentFromCourse(StudentOnCourse model)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.StudentOnCourseDbSet.Attach(model);

                dbContext.StudentOnCourseDbSet.Remove(model);

                return true;
            });
        }
        
        public List<Student> StudentsOnCourse(Course model)
        {
            return ExecuteQuery(dbContext => dbContext.StudentOnCourseDbSet
                .Include(p => p.Course.Id == model.Id)
                .Select(x => x.Student)
                .ToList());
        }

        public int StudentsOnCourseCount(Course model)
        {
            return ExecuteQuery(dbContext => dbContext.StudentOnCourseDbSet
                .Count(p => p.Id == model.Id));
        }

        public List<StudentOnCourse> GetCourseDataForReport(Course model)
        {
            return ExecuteQuery(dbContext => dbContext.StudentOnCourseDbSet
                 .Include(p => p.Student)
                 .Include(p => p.Course)
                 .Where(p => p.Course.Id == model.Id)
                 .ToList());
        }

        //Standard repo

        public override bool Add(StudentOnCourse model)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.StudentOnCourseDbSet.Add(model);
                return true;
            });
        }

        public override StudentOnCourse Get(int id)
        {
            return ExecuteQuery(dbContext => dbContext
            .StudentOnCourseDbSet
            .First(p => p.Id == id));
        }

        public override List<StudentOnCourse> GetAll()
        {
            return ExecuteQuery(dbContext => dbContext
            .StudentOnCourseDbSet.ToList());
        }

        public override bool Exist(StudentOnCourse model)
        {
            return ExecuteQuery(dbContext =>
            {
                var data = dbContext.StudentOnCourseDbSet
                    .FirstOrDefault(p => p.Student.Pesel == model.Student.Pesel && p.Course.Name == model.Course.Name);

                return data != null;
            });
        }
    }
}
