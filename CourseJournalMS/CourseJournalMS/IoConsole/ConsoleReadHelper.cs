using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS.IoConsole
{
    internal class ConsoleReadHelper
    {
        public static int GetInt(int minValue, int maxValue)
        {
            bool parameterOk = false;
            int result = 0;

            do
            {
                try
                {
                    result = Int32.Parse(Console.ReadLine());
                    if (result >= minValue && result <= maxValue)
                    {
                        parameterOk = true;
                    }
                    else
                    {
                        Console.Write("Please provide number between <{0},{1}>: ", minValue, maxValue);
                    }
                }
                catch (Exception e)
                {
                    Console.Write("Bad data format, try again: ");
                }
            } while (!parameterOk);

            return result;
        }
    }
}
