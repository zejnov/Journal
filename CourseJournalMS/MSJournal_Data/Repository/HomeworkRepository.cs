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
    public class HomeworkRepository : BasicRepository<Homework>, IHomeworkRepository
    {
        public override bool Add(Homework model)
        {
            return ExecuteQuery(dbContext =>
            {
                model.StudentOnCourse = dbContext.StudentOnCourseDbSet
                    .First((p => p.Course.Name == model.StudentOnCourse.Course.Name
                         && p.Student.Pesel == model.StudentOnCourse.Student.Pesel));

                dbContext.HomeworkDbSet.Add(model);
                
                return true;
            });
        }

        public override Homework Get(int id)
        {
            return ExecuteQuery(dbContext => dbContext.HomeworkDbSet
            .First(p => p.Id == id));
        }

        public override List<Homework> GetAll()
        {
            return ExecuteQuery(dbContext => dbContext.HomeworkDbSet
            .ToList());
        }

        public override bool Exist(Homework model)
        {
            return ExecuteQuery(dbContext =>
            {
                var data = dbContext.HomeworkDbSet
                    .FirstOrDefault(p => p.Id == model.Id);

                return data != null;
            });
        }
    }
}
