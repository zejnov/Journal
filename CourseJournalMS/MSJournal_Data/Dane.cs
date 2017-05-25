using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MSJournal_Data.Models;

namespace MSJournal_Data
{
    public class Dane
    {
        public static Dictionary<int, Course> Journal = new Dictionary<int, Course>();  //main Journal of program
        public static Dictionary<int, Student> StudentsList = new Dictionary<int, Student>();  //List of students

    }
}
