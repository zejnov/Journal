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
        /// <summary>
        /// Generic function to get data
        /// </summary>
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
                    Console.WriteLine("\nYou didnt gave anything, try again");
                }
                catch (Exception)
                {
                    Console.Write("\nSomething went wrong, try again\n");
                }
            }
        }

        /// <summary>
        /// function to get proper PESEL
        /// </summary>
        public static long GetStudentPesel()
        {
            var pesel = GetData<long>("Provide student PESEL: ");

            var studentServices = new StudentServices();

            while (!studentServices.CheckPesel(pesel))
            {
                Console.WriteLine("You provide wrong PESEL, try again.");
                pesel = GetData<long>("Provide PESEL: ");
            }

            return pesel;
        }

        /// <summary>
        /// function to get int value in given range
        /// </summary>
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

        /// <summary>
        /// getting course data
        /// </summary>
        /// <returns>CourseDto</returns>
        public static CourseDto GetCourseData()
        {
            var courseDto = new CourseDto();
            var studentServices = new StudentServices();

            courseDto.Name = GetData<string>("Provide course name");
            courseDto.LeaderName = GetData<string>("Provide course leader name");
            courseDto.LeaderSurname = GetData<string>("Provide course leader surname");
            courseDto.StartDate = GetData<DateTime>("Provide course start date");
            courseDto.PresenceThreshold = GetIntInRange("Provide presence threshold", 0, 100);
            courseDto.HomeworkThreshold = GetIntInRange("Provide homework threshold", 0, 100);

            var maxStudentsNumber = studentServices.StudentsCount();
            courseDto.StudentsNumber = GetIntInRange("Privide students number", 0, maxStudentsNumber);
            
            return courseDto;
        }

        /// <summary>
        /// updating course data, if empty saves old parameter
        /// </summary>
        public static CourseDto UpdateCourseData(CourseDto oldCourseDto)
        {
            var courseDto = new CourseDto();

            var newName = GetData<string>("Provide course name");
            courseDto.Name = newName == "" ? oldCourseDto.Name : newName;

            var newLeaderName = GetData<string>("Provide course leader name");
            courseDto.LeaderName = newLeaderName == "" ? oldCourseDto.LeaderName : newLeaderName;

            var newLeaderSurname = GetData<string>("Provide course leader surname");
            courseDto.LeaderSurname = newLeaderSurname == "" ? oldCourseDto.LeaderSurname : newLeaderSurname;

            courseDto.PresenceThreshold = GetIntInRange("Provide presence threshold", 0, 100);
            courseDto.HomeworkThreshold = GetIntInRange("Provide homework threshold", 0, 100);
            
            return courseDto;
        }

        /// <summary>
        /// getting student data
        /// </summary>
        /// <returns>StudentDto</returns>
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

        /// <summary>
        /// updating student data, if empty saves old parameter
        /// </summary>
        public static StudentDto UpdateStudentData(StudentDto oldStudentDto)
        {
            var studentDto = new StudentDto();

            var newName = GetData<string>("Provide student name");
            studentDto.Name = newName == "" ? oldStudentDto.Name : newName;
            
            var newSurname = GetData<string>("Provide student surname");
            studentDto.Surname = newSurname == "" ? oldStudentDto.Surname : newSurname;

            studentDto.BirthDate = GetData<DateTime>("Provide student birth date");
            
            return studentDto;
        }

        /// <summary>
        /// getting student gender
        /// </summary>
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

        /// <summary>
        /// getting student homework result
        /// </summary>
        public static int GetStudentHomework(StudentDto student, int maxPoints)
        {
            return GetIntInRange($"Student {student.Name} {student.Surname} gets",0,maxPoints);
        }

        /// <summary>
        /// getting student attendance on course day
        /// </summary>
        public static string GetStudentAttendance(StudentDto student)
        {
            var enumResult = AttendanceType.none;

            do
            {
                try
                {
                    enumResult = (AttendanceType)Enum.Parse(typeof(AttendanceType),
                        GetData<string>($"Student {student.Name} {student.Surname} is"));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Bad entry, try present/absent.");
                }

            } while (enumResult == AttendanceType.none);

            return AttendanceResult(enumResult);
        }
        
        /// <summary>
        /// enums of gender
        /// </summary>
        private enum GenderType 
        {
            none,
            male,
            female,
            m,
            f,
        }

        /// <summary>
        /// enums of attendance
        /// </summary>
        private enum AttendanceType
        {
            none,
            present,
            absent,
            p,
            a,
        }

        /// <summary>
        /// enums of approval
        /// </summary>
        private enum ApprovalType
        {
            none,
            yes,
            no,
            y,
            n,
        }

        /// <summary>
        /// converting attendance to string
        /// </summary>
        private static string AttendanceResult(AttendanceType type)
        {
            if (type == AttendanceType.p || type == AttendanceType.present)
            {
                return "present";
            }
            if (type == AttendanceType.a || type == AttendanceType.absent)
            {
                return "absent";
            }
            return "";
        }

        public static bool GetApproval(string message)
        {
            var enumResult = ApprovalType.none;

            do
            {
                try
                {
                    enumResult = (ApprovalType)Enum.Parse(typeof(ApprovalType),
                        GetData<string>($"Would you like to {message}?"));
                }
                catch (Exception e)
                {
                    Console.WriteLine("Bad entry, try yes/no.");
                }

            } while (enumResult == ApprovalType.none);

            return ApprovalResult(enumResult);
        }

        private static bool ApprovalResult(ApprovalType type)
        {
            if (type == ApprovalType.y || type == ApprovalType.yes)
            {
                return true;
            }
            if (type == ApprovalType.n || type == ApprovalType.no)
            {
                return false;
            }
            return false;
        }
    }
}