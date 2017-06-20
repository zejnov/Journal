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
        /// <summary>
        /// main program method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            new ProgramLoop().Run();
        }        
    }
}