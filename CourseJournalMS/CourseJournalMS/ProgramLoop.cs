using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CourseJournalMS.IoConsole;
using MSJournal_Business.Dtos;
using MSJournal_Business.Services;
using MSJournal_Data;
using MSJournal_Data.Models;

namespace CourseJournalMS
{
    class ProgramLoop
    {
        private int _zjv = 0;
        private CourseDto _choosenCourse;

        /// <summary>
        /// running an app
        /// </summary>
        public void Run()
        {
            SwitchCommand();
        }

        /// <summary>
        /// command types used in app
        /// </summary>
        public enum CommandTypes
        {
            none,
            add,        //student
            create,     //course
            update,
            signin,     //student on course
            signout,    //student from ourse
            updatestudent,
            change,     //switch active course
            addday,
            addhome,
            print,
            clear,
            exit,
            help,
        }

        /// <summary>
        /// getting command from user
        /// </summary>
        /// <returns>command</returns>
        public CommandTypes GetCommandFromUser()
        {
            CommandTypes command = CommandTypes.none;
            bool commandOk = false;

            do
            {
                try
                {
                    command = (CommandTypes)Enum.Parse(typeof(CommandTypes), Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.Write("Bad command, please try again: ");
                }

                if (command != CommandTypes.none)
                {
                    commandOk = true;
                }
            } while (!commandOk);

            return command;
        }

        /// <summary>
        /// main function switching given command
        /// </summary>
        public void SwitchCommand()
        {
            var exit = false;
            
            while (!exit)
            {  
                
                ConsoleWriteHelper.PrintMenu();

                var command = GetCommandFromUser();
                
                switch (command)
                {
                    #region         Command types on short list   
                    //    none,
                    //add,
                    //sample,
                    //create,
                    //change,
                    //addday,
                    //addhome,
                    //print,
                    //clear,
                    //exit,
                    //help,
                    #endregion
                    case CommandTypes.none:
                    {
                        //nothing happens here
                    }
                        break;
                    case CommandTypes.add:
                    {
                        Action(AddStudent());
                    }
                        break;
                    case CommandTypes.create:
                    {
                        Action(AddCourse());
                    }
                        break;
                    case CommandTypes.update:
                    {
                        Action(UpdateCourse());
                    }
                        break;
                    case CommandTypes.signin:
                    {
                        Action(SignInStudentOnCourse());
                    }
                        break;
                    case CommandTypes.signout:
                    {
                        Action(SignOutStudentFromCourse());
                    }
                        break;
                    case CommandTypes.updatestudent:
                    {
                        Action(UpdateStudent());
                    }
                        break;
                    case CommandTypes.change:
                    {
                        Action(ChangeActiveCourse());
                    }
                        break;

                    case CommandTypes.addday:
                    {
                         Action(AddDayOfCourse());
                    }
                        break;
                    case CommandTypes.addhome:
                    {
                         Action(AddHomeworkToCourse());
                    }
                        break;
                    case CommandTypes.print:
                    {
                        Action(PrintReport());
                    }
                        break;
                    case CommandTypes.clear:
                    {
                        Action(Clear());
                    }
                        break;
                    case CommandTypes.exit:
                    {
                        exit = true;
                        Exit();
                    }
                        break;
                    case CommandTypes.help:
                    {
                        Action(ConsoleWriteHelper.PrintHelp());
                    }
                        break;
                    default:            //almost useless
                        Console.WriteLine("Bad command, try again");
                        break;
                }
            }
        }

        /// <summary>
        /// adding student to student list
        /// </summary>
        /// <returns></returns>
        private bool AddStudent()
        {
            Console.Clear();
            var studentDto = new StudentDto();
            var studentServices = new StudentServices();

            studentDto = ConsoleReadHelper.GetStudentData();

            var success = studentServices.Add(studentDto);

            if (success)
            {
                Console.WriteLine("\nStudent added to database successfully.");
            }
            else
            {
                Console.WriteLine("\nGiven student already exists in the database");
            }

            Console.ReadKey();
            return true;
        }

        /// <summary>
        /// adding course to journal
        /// </summary>
        /// <returns></returns>
        private bool AddCourse()
        {
            Console.Clear();

            var courseDto = new CourseDto();
            var courseServices = new CourseServices();

            courseDto = ConsoleReadHelper.GetCourseData();
            var success = courseServices.Add(courseDto);

            if (success)
            {
                Console.WriteLine("\nCourse added to database successfully.");
                ReloadCourse(courseDto);
            }
            else
            {
                Console.WriteLine("\nGiven course already exists in the database");
            }

            Console.ReadKey();
            return true;
        }

        /// <summary>
        /// updating course data
        /// </summary>
        /// <returns></returns>
        private bool UpdateCourse()
        {
            Console.Clear();

            if (_choosenCourse == null)
            {
                Console.WriteLine("There is no active course! Try 'change' ");
                return false;
            }

            var course = new CourseDto();
            var courseServices = new CourseServices();

            Console.WriteLine("Please provide new course data:\n");
            course = ConsoleReadHelper.UpdateCourseData(_choosenCourse);
            var success = courseServices.UpdateCourseData(_choosenCourse, course);

            if (success)
            {
                Console.WriteLine("\nCourse data updated successfully");
                ReloadCourse(course);
            }
            else
            {
                Console.WriteLine("\nSomething goes wrong...");
            }

            Console.ReadKey();
            return true;
        }

        /// <summary>
        /// changing active course, choose from list
        /// </summary>
        /// <returns></returns>
        private bool ChangeActiveCourse()
        {
            Console.Clear();
            var courseServices = new CourseServices();

            if (courseServices.GetCourseCount() == 0)
            {
                Console.WriteLine("You need to create course first!");
                return true;
            }

            _choosenCourse = ChooseFromList.CourseFromList(courseServices.GetAll());
            return true;
        }

        /// <summary>
        /// sign in student on course, choosen from lists
        /// </summary>
        /// <returns></returns>
        private bool SignInStudentOnCourse()
        {
            Console.Clear();

            if (_choosenCourse == null)
            {
                Console.WriteLine("There is no active course! Try 'change' ");
                return false;
            }

            var studentOnCourse = new StudentOnCourseDto();
            var studentServices = new StudentServices();
            var studentOnCourseServices = new StudentOnCourseServices();

            studentOnCourse.Course = _choosenCourse;
            studentOnCourse.Student = ChooseFromList.StudentFromList(studentServices.GetAll());

            if (!studentOnCourseServices.Exist(studentOnCourse))
            {
                var success = studentOnCourseServices.AddStudentToCourse(studentOnCourse);

                if (success)
                {
                    Console.WriteLine("\nStudent sign in to course successfully.");
                }
                else
                {
                    Console.WriteLine("\nSomething goes wrong...");
                }
            }
            else
            {
                Console.WriteLine("\nChoosen student already attend to this course.");
            }

            Console.ReadKey();
            return true;
        }

        /// <summary>
        /// sign out student from ACTIVE course, choosen from lists
        /// </summary>
        /// <returns></returns>
        private bool SignOutStudentFromCourse()
        {
            Console.Clear();
            
            if (_choosenCourse == null)
            {
                Console.WriteLine("There is no active course! Try 'change' ");
                return false;
            }

            var studentOnCourse = new StudentOnCourseDto();
            var studentOnCourseServices = new StudentOnCourseServices();
            var homeworkServices = new HomeworkServices();
            var courseDayServices = new CourseDayServices();


            studentOnCourse.Course = _choosenCourse;
            studentOnCourse = ChooseFromList.StudentOnCourseList(studentOnCourseServices
                .StudentsListOnCourse(studentOnCourse.Course));

            //************deleting all 'references'***********
            var success = true;
            var homeworkList = homeworkServices.GetHomework(studentOnCourse);
            var attendanceList = courseDayServices.GetAttendance(studentOnCourse);

            if (homeworkList.Count != 0)
            {
                foreach (var homework in homeworkList)
                {
                    success &= homeworkServices.RemoveHomework(homework);
                }
            }

            if (attendanceList.Count != 0)
            {
                foreach (var day in attendanceList)
                {
                    success &= courseDayServices.RemoveDay(day);
                }
            }

            //deleting literally 'student on course'
            success &= studentOnCourseServices.RemoveStudentFromCourse(studentOnCourse);
            
            if (success)
            {
                Console.WriteLine("Student sign out from course successfully.");
            }
            else
            {
                Console.WriteLine("Something goes wrong...");
            }

            Console.ReadKey();
            return true;
        }

        /// <summary>
        /// update student data, choosen from list
        /// </summary>
        /// <returns></returns>
        private bool UpdateStudent()
        {
            Console.Clear();

            var student = new StudentDto();
            var studentServices = new StudentServices();

            Console.WriteLine("Please choose student you want update: \n");
            student = ChooseFromList.StudentFromList(studentServices.GetAll());
            
            if (student == null)
            {
                Console.WriteLine("Something goes wrong...");
                return false;
            }
            
            Console.WriteLine("Please provide new student data:\n");
            var newStudent = new StudentDto();
            newStudent = ConsoleReadHelper.UpdateStudentData(student);
            var success = studentServices.UpdateStudentData(student, newStudent);

            if (success)
            {
                Console.WriteLine("\nStudent data updated successfully.");
            }
            else
            {
                Console.WriteLine("\nSomething goes wrong.");
            }

            Console.ReadKey();
            return true;

        }

        /// <summary>
        /// add day of course - check attendance on active course
        /// </summary>
        /// <returns></returns>
        private bool AddDayOfCourse()
        {
            Console.Clear();
            
            if (_choosenCourse == null)
            {
                Console.WriteLine("There is no active course! Try 'change' ");
                return false;
            }

            var studentOnCourse = new StudentOnCourseDto();
            studentOnCourse.Course = _choosenCourse;

            var studentOnCourseServices = new StudentOnCourseServices();
            var studentOnCourseList = studentOnCourseServices
                .StudentsListOnCourse(studentOnCourse.Course);

            var success = true;
            var courseDayServices = new CourseDayServices();

            foreach (var student in studentOnCourseList)
            {
                
                var courseDay = new CourseDayDto()
                {
                    StudentOnCourse = student,
                };
                
                courseDay.Attendance = ConsoleReadHelper.GetStudentAttendance(student.Student);

                success &= courseDayServices.Add(courseDay);
            }

            if (success)
            {
                Console.WriteLine("\nChecking attendance of all students completed succesfully!");
            }
            else
            {
                Console.WriteLine("\nSomething goes wrong...");
            }

            Console.ReadKey();
            return true;
        }

        /// <summary>
        /// add homework on course - check students results
        /// </summary>
        /// <returns></returns>
        private bool AddHomeworkToCourse()
        {
            Console.Clear();

            if (_choosenCourse == null)
            {
                Console.WriteLine("There is no active course! Try 'change' ");
                return false;
            }

            var studentOnCourse = new StudentOnCourseDto();
            studentOnCourse.Course = _choosenCourse;

            var studentOnCourseServices = new StudentOnCourseServices();
            var studentOnCourseList = studentOnCourseServices
                .StudentsListOnCourse(studentOnCourse.Course);

            var maxHomeworkPoints = ConsoleReadHelper.GetIntInRange("Please provide max homework points", 0, 1000);

            var success = true;
            var homeworkServices = new HomeworkServices();

            foreach (var student in studentOnCourseList)
            {

                var homework = new HomeworkDto()
                {
                    StudentOnCourse = student,
                };

                homework.MaxPoints = maxHomeworkPoints;
                homework.StudentPoints = ConsoleReadHelper.GetStudentHomework(student.Student,maxHomeworkPoints);

                success &= homeworkServices.Add(homework);
            }

            if (success)
            {
                Console.WriteLine("\nChecking homework of all students completed succesfully!");
            }
            else
            {
                Console.WriteLine("\nSomething goes wrong...");
            }

            Console.ReadKey();
            return true;
        }

        /// <summary>
        /// printing active course report
        /// </summary>
        /// <returns></returns>
        private bool PrintReport()
        {
            Console.Clear();

            if (_choosenCourse == null)
            {
                ReportHelper.IfNoCourse();
                return false;
            }

            //*******************Drukowanie raportu**********************
            var printOk = true;
            printOk &= ReportHelper.GetCourseReport(_choosenCourse);

            var studentOnCourseServices = new StudentOnCourseServices();
            var studentOnCourseList = studentOnCourseServices
                .StudentsListOnCourse(_choosenCourse);

            //ConsoleWriteHelper.PrintOrderedList(studentOnCourseList);
            if (studentOnCourseList.Count != 0)
            {
                printOk &= ReportHelper.GetHomeworkReport(studentOnCourseList);
                printOk &= ReportHelper.GetAttendanceReport(studentOnCourseList);
            }
            else
            {
                Console.WriteLine("\nThere are no students on this course");
            }

            Console.WriteLine(printOk ? "\nReport generated and printed successfully!" : "\nSomething goes wrong...");
            Console.ReadKey();

            return true;
        }

        /// <summary>
        /// clear the console
        /// </summary>
        /// <returns></returns>
        private bool Clear()
        {
            Console.Clear();
            return true;
        }

        /// <summary>
        /// exit the app
        /// </summary>
        private void Exit()
        {
            Console.WriteLine($"\n\nYou used {++_zjv} commands :)");
            Console.WriteLine($"Bye, bye {Environment.UserName}");
            Console.ReadKey();
        }

        /// <summary>
        /// action counter
        /// </summary>
        private void Action(bool zjv)
        {
            _zjv++;
        }

        /// <summary>
        /// reload course data from database
        /// </summary>
        private void ReloadCourse()
        {
            var courseServices = new CourseServices();
            _choosenCourse = courseServices.RefreshCourse(_choosenCourse);
        }

        /// <summary>
        /// reload course from database
        /// </summary>
        /// <param name="course">course to be set as active</param>
        private void ReloadCourse(CourseDto course)
        {
            var courseServices = new CourseServices();
            _choosenCourse = courseServices.RefreshCourse(course);
        }
    }//class
}
