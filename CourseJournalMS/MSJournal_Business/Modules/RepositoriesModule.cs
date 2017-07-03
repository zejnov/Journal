using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Services;
using MSJournal_Business.Services.ServicesInterfaces;
using Ninject.Modules;


namespace MSJournal_Business.Modules
{
    public class RepositoriesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICourseDayServices>().To<CourseDayServices>();
            Bind<ICourseServices>().To<CourseServices>();
            Bind<IHomeworkServices>().To<HomeworkServices>();
            Bind<IStudentOnCourseServices>().To<StudentOnCourseServices>();
            Bind<IStudentServices>().To<StudentServices>();
        }
    }
}
