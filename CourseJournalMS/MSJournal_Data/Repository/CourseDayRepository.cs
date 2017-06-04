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
    class CourseDayRepository : BasicRepository<CourseDay> , ICourseDayRepository
    {
        public override bool Add(CourseDay model)
        {
            throw new NotImplementedException();
        }

        public override CourseDay Get(int id)
        {
            throw new NotImplementedException();
        }

        public override List<CourseDay> GetAll()
        {
            throw new NotImplementedException();
        }

        public override bool Exist(CourseDay model)
        {
            throw new NotImplementedException();
        }
    }
}
