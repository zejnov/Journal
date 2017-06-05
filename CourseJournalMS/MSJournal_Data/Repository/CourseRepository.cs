using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;
using MSJournal_Data.Repository.Basic;
using MSJournal_Data.Repository.Interfaces;

namespace MSJournal_Data.Repository
{
    public class CourseRepository : BasicRepository<Course>, ICourseRepository
    {
        public override bool Add(Course model)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.CourseDbSet.Add(model);
                return true;
            });
        }

        public override Course Get(int id)
        {
            return ExecuteQuery(dbContext => dbContext.CourseDbSet.First(p => p.Id == id));
        }

        public override List<Course> GetAll()
        {
            return ExecuteQuery(dbContext => dbContext.CourseDbSet.ToList());
        }

        public override bool Exist(Course model)
        {
            return ExecuteQuery(dbContext =>
            {
                var data = dbContext.CourseDbSet
                    .FirstOrDefault(p => p.Name == model.Name);

                return data != null;
            });
        }

        public bool UpdateCourseData(Course oldModel, Course newModel)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.CourseDbSet.Attach(oldModel);
                oldModel.Name = newModel.Name;
                oldModel.LeaderName= newModel.LeaderName;
                oldModel.LeaderSurname = newModel.LeaderSurname;
                oldModel.HomeworkThreshold = newModel.HomeworkThreshold;
                oldModel.PresenceThreshold = newModel.PresenceThreshold;
                
                return true;
            });
        }

        public List<Student> GetAllStudents(Course model)
        {
            return ExecuteQuery(dbContext => dbContext.CourseDbSet
                .First(p => p.Id == model.Id).CourseStudentsList
                .ToList());
        }

        public List<CourseDay> GetStudentAttendance(Course model, int id)
        {
            return ExecuteQuery(dbContext => dbContext.CourseDbSet
                .First(p => p.Id == model.Id).AttendanceList
                .FindAll(x => x.Student.Id == id)
                .ToList());
        }

        public List<Homework> GetStudentHomework(Course model, int id)
        {
            return ExecuteQuery(dbContext => dbContext.CourseDbSet
                .First(p => p.Id == model.Id).HomeworksList
                .FindAll(x => x.Student.Id == id)
                .ToList());
        }

        //TODO  Delete student from list
    }
}
