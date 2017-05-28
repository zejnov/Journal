using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Data.Models
{
    public class Homework
    {
        public int StudentHomeworkPoints;
        public int MaxHomeworkPoints;
        
        //public Homework(Student student, int maxHomeworkPoints)    //creator!
        //{
        //    bool parameterOk = false;
        //    MaxHomeworkPoints = maxHomeworkPoints;
            
        //    Console.Write("{0}. {1} {2} get: ", student.Id, student.Name, student.Surname);
        //    do
        //    {
        //        try
        //        {
        //            StudentHomeworkPoints = Int32.Parse(Console.ReadLine());
        //            if (StudentHomeworkPoints >= 0 && StudentHomeworkPoints <= MaxHomeworkPoints)
        //            {
        //                parameterOk = true;
        //            }
        //            else if (StudentHomeworkPoints > MaxHomeworkPoints)
        //            {
        //                Console.Write("Student can not get more points than max, please try again: ");
        //            }
        //            else
        //            {
        //                Console.Write("Bad range of number, please try again: ");
        //            }
        //        }
        //        catch (FormatException e)
        //        {
        //            Console.WriteLine("Bad data format, please try again...");
        //        }
        //        catch (OverflowException e)
        //        {
        //            Console.WriteLine("It is too big for this program, sorry.");
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            Console.WriteLine("Some unexpected error occured!");
        //        }

        //    } while (!parameterOk);
        //}
        
    }
}
