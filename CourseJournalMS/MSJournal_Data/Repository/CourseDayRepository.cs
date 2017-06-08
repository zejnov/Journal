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
    public class CourseDayRepository : BasicRepository<CourseDay> , ICourseDayRepository
    {
        public override bool Add(CourseDay model)
        {
            return ExecuteQuery(dbContext =>
            {
                model.StudentOnCourse = dbContext.StudentOnCourseDbSet
                    .First(p => p.Course.Name == model.StudentOnCourse.Course.Name 
                         && p.Student.Pesel == model.StudentOnCourse.Student.Pesel);

                dbContext.CoruseDayDbSet.Add(model);
                return true;
            });
        }
        
        public override CourseDay Get(int id)
        {
            return ExecuteQuery(dbContext => dbContext.CoruseDayDbSet
                .First(p => p.Id == id));
        }

        public override List<CourseDay> GetAll()
        {
            return ExecuteQuery(dbContext => dbContext.CoruseDayDbSet
                .ToList());
        }

        public override bool Exist(CourseDay model)
        {
            return ExecuteQuery(dbContext =>
            {
                var data = dbContext.CoruseDayDbSet
                    .FirstOrDefault(p => p.Id == model.Id);

                return data != null;
            });
        }

        public List<CourseDay> GetAttendance(StudentOnCourse model)
        {
            return ExecuteQuery(dbContext =>
            {
                return dbContext.CoruseDayDbSet
                
                    .Where(p => p.StudentOnCourse.Course.Name == model.Course.Name
                                && p.StudentOnCourse.Student.Pesel == model.Student.Pesel)
                    .Where(p => p.StudentOnCourse.Id == model.Id)
                    .Include(p => p.StudentOnCourse)
                    .Include(p => p.StudentOnCourse.Student)
                    .Include(p => p.StudentOnCourse.Course)
                    .ToList();
            });
        }
    }
}
