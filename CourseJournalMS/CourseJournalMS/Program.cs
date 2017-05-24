using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    public class Program
    {
        public static Dictionary<int, Course> Journal = new Dictionary<int, Course>();  //main Journal of program
        public static Dictionary<int, Student> StudentsList = new Dictionary<int, Student>();  //List of students
        
        static void Main(string[] args)
        {
            new Journal().Run();
        }

        /*
        //TODO

        */

    }//class
}//namespace






