using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS
{
    public class Course
    {
        private static int _numberOfCreatedCourses = 0;
        public static int ChoosenCourse = 0;

        //public static int ActiveCourseId = 0;
        public int Id;
        public string Name;
        public string LeaderName, CourseLeaderSurname;
        public DateTime StartDate;
        public double HomeworkThreshold;
        public double PresenceThreshold;
        public int StudentsNumber;

        public Dictionary<int,Student> CourseStudentsList = new Dictionary<int, Student>();

        public Course()  //creator
        {
            Id = ++_numberOfCreatedCourses;
            ChoosenCourse = Id;
        }

        public static int CourseCounter()
        {
            return _numberOfCreatedCourses;
        }

        //for protection to not print report of the empty journal
        private bool _courseActive = false;
        private bool _courseCreated = false;

        public bool CourseIsActive()
        {
            return _courseActive;
        }

        public void SetCourseActive()
        {
            _courseActive = true;
        }

        public void ResetCourseActive()
        {
            _courseActive = false;
        }

        public void SetCourseCreated()
        {
            _courseCreated = true;
        }

        public void ResetCourseCreated()
        {
            _courseCreated = false;
        }

        public bool CourseCreatedStatus()
        {
            return _courseCreated;
        }


        //********Homework********
        public int MaxHomeworkPoints = 0;
        public int NumberOfHomeworks = 0;
        public int NumberOfClasesDays = 0;

        public void NewHomework()
        {
            bool parameterOk = false;

            Console.Write("Please enter the maximum number of points for this homework: ");
            do
            {
                try
                {
                    MaxHomeworkPoints = Int32.Parse(Console.ReadLine());
                    if (MaxHomeworkPoints > 0)
                    {
                        parameterOk = true;
                    }
                    else
                    {
                        Console.Write("Bad range of number, please try again: ");
                    }
                }
                catch (FormatException e)
                {
                    Console.Write("Bad data format, please try again: ");
                }
                catch (OverflowException e)
                {
                    Console.Write("It is too big for this program, please try again: ");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("Some unexpected error occured!");
                }
            } while (!parameterOk);

            Console.WriteLine("For each student please enter the number of points earned: ");
        }

        public void IncreaseHomeworksNumber()
        {
            NumberOfHomeworks++;
        }

        public void IncreaseClasesDaysNumber()
        {
            NumberOfClasesDays++;
        }
        
        public void NewCourseDay()
        {
            Console.WriteLine("For each student please enter p(present) or a(absent):");
        }


    }
}
