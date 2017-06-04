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
    class HomeworkRepository : BasicRepository<Homework>, IHomeworkRepository
    {
        public override bool Add(Homework model)
        {
            throw new NotImplementedException();
        }

        public override Homework Get(int id)
        {
            throw new NotImplementedException();
        }

        public override List<Homework> GetAll()
        {
            throw new NotImplementedException();
        }

        public override bool Exist(Homework model)
        {
            throw new NotImplementedException();
        }
    }
}
