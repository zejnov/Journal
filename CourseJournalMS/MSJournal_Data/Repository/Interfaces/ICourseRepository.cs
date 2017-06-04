using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Models;

namespace MSJournal_Data.Repository.Interfaces
{
    interface ICourseRepository
    {
        bool Add(Course model);
        bool Exist(Course model);
        Course Get(int id);
        List<Course> GetAll();
        bool UpdateCourseData(Course oldModel, Course newModel);
    }
}
