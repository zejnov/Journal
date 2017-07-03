using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data.Repository;
using MSJournal_Data.Repository.Interfaces;
using Ninject.Modules;

namespace MSJournal_Business.Modules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICourseDayRepository>().To<CourseDayRepository>();
            Bind<ICourseRepository>().To<CourseRepository>();
            Bind<IHomeworkRepository>().To<HomeworkRepository>();
            Bind<IStudentOnCourseRepository>().To<StudentOnCourseRepository>();
            Bind<IStudentRepository>().To<StudentRepository>();
        }
    }
}