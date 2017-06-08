using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Data.Repository.Interfaces
{
    interface IHomeworkRepository
    {
        bool Add(Homework model);
        bool Exist(Homework model);
        Homework Get(int id);
        List<Homework> GetAll();
        List<Homework> GetHomework(StudentOnCourse model);
    }
}
