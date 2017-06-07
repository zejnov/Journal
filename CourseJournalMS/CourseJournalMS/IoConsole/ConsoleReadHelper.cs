using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Business.Services;

namespace CourseJournalMS.IoConsole
{
    internal class ConsoleReadHelper
    {
        //public static int GetInt(int minValue, int maxValue)
        //{
        //    bool parameterOk = false;
        //    int result = 0;

        //    do
        //    {
        //        try
        //        {
        //            result = Int32.Parse(Console.ReadLine());
        //            if (result >= minValue && result <= maxValue)
        //            {
        //                parameterOk = true;
        //            }
        //            else
        //            {
        //                Console.Write("Please provide number between <{0},{1}>: ", minValue, maxValue);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Console.Write("Bad data format, try again: ");
        //        }
        //    } while (!parameterOk);

        //    return result;
        //}

        public static T GetData<T>(string message)
        {
            while (true)
            {
                try
                {
                    Console.Write(message + ": ");
                    return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR! You didnt gave anything, ty again");
                }
                catch (Exception)
                {
                    Console.WriteLine();
                    Console.WriteLine("ERROR! Something went wrong, try again");
                }
            }
        }

        public static long GetStudentPesel()
        {
            var pesel = GetData<long>("Provide student PESEL: ");
            while (!StudentServices.CheckPesel(pesel))
            {
                Console.WriteLine("You provide wrong PESEL, try again.");
                pesel = GetData<long>("Provide PESEL: ");
            }

            return pesel;
        }

        public static int GetIntInRange(string message, int minValue, int maxValue)
        {
            var result = GetData<int>(message);
            while (!(result >= minValue && result <= maxValue))
            {
                Console.WriteLine("Out of range, please try again.");
                result = GetData<int>(message);
            }

            return result;
        }

        public static CourseDto GetCourseData()
        {
            var courseDto = new CourseDto();

            courseDto.Name = GetData<string>("Provide course name");
            courseDto.LeaderName = GetData<string>("Provide course leader name");
            courseDto.LeaderSurname = GetData<string>("Provide course leader surname");
            courseDto.StartDate = GetData<DateTime>("Provide course start date");
            courseDto.PresenceThreshold = GetIntInRange("Provide presence threshold", 0, 100);
            courseDto.HomeworkThreshold = GetIntInRange("Provide homework threshold", 0, 100);

            var maxStudentsNumber = StudentServices.StudentsCount();
            courseDto.StudentsNumber = GetIntInRange("Privide students number", 0, maxStudentsNumber);
            
            return courseDto;
        }

        public static StudentDto GetStudentData()
        {
            var studentDto = new StudentDto();

            studentDto.Name = GetData<string>("Provide student name");
            studentDto.Surname = GetData<string>("Provide student surname");
            studentDto.BirthDate = GetData<DateTime>("Provide student birth date");
            studentDto.Pesel = GetStudentPesel();
            studentDto.Gender = GetStudentGender();
            
            return studentDto;
        }

        private static string GetStudentGender()
        {
            var enumResult = GenderType.none;

            do
            {
                try
                {
                    enumResult = (GenderType)Enum.Parse(typeof(GenderType),
                        GetData<string>("Provide student gender"));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Bad entry, try male/female.");
                }

            } while (enumResult == GenderType.none);
            
            return enumResult.ToString();
        }

        private enum GenderType 
        {
            none,
            male,
            female,
            m,
            f,
        }
    }
}
