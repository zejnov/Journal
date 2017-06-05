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
    public class StudentRepository : BasicRepository<Student>, IStudentRepository
    {
        public override bool Add(Student model)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.StudentDbSet.Add(model);
                return true;
            });
        }

        public override Student Get(int id)
        {
            return ExecuteQuery(dbContext => dbContext
                .StudentDbSet.First(p => p.Id == id));
        }

        public override List<Student> GetAll()
        {
            return ExecuteQuery(dbContext => dbContext.StudentDbSet.ToList());
        }

        public override bool Exist(Student model)
        {   
            return ExecuteQuery(dbContext =>
            {
                var data = dbContext.StudentDbSet
                    .FirstOrDefault(p => p.Pesel == model.Pesel);

                return data != null;
            });
        }

        public bool UpdateStudentData(Student oldModel, Student newModel)
        {
            return ExecuteQuery(dbContext =>
            {
                dbContext.StudentDbSet.Attach(oldModel);
                oldModel.Name = newModel.Name;
                oldModel.Surname = newModel.Surname;

                return true;
            });
        }
    }
}
