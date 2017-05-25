using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS.IoConsole
{
    internal class ConsoleWriteHelper
    {

        public static void PrintMenu()
        {
            Console.WriteLine("\nadd / sample / create / change / addday / addhome / print / clear / exit / help");
            Console.Write("Please enter the name of the action: ");
        }

        public static void PrintHelp()
        {
            Console.Clear();
            
            Console.WriteLine("\nWELCOME TO HELP!");
            Console.WriteLine("\nadd     - add new student to list" +
                              "\nsample  - loading some sample journal & students to print report" +
                              "\nchange  - jump to other course" +
                              "\ncreate  - creating a new journal" +
                              "\naddday  - adding a day of classes to course" +
                              "\naddhome - adding homework to course" +
                              "\nprint   - printing course report" +
                              "\nclear   - clearing the console" +
                              "\nexit    - exit console" +
                              "\nhelp    - is exactly where you are :)");
            Console.WriteLine("\n\nzejnov/2017\n");
        }

        public static void PrintIdError()
        {
            Console.WriteLine("The given ID does not exist in courses collection");
        }









    }






}
