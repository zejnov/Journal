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

        public void Run()
        {
            SwitchCommand();
        }

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
                        ConsoleWriteHelper.PrintHelp();
                    }
                        break;
                    default:            //almost useless
                        Console.WriteLine("Bad command, try again");
                        break;
                }
            }
        }

        private bool AddStudent()
        {
            Console.Clear();
            var studentDto = new StudentDto();
            studentDto = ConsoleReadHelper.GetStudentData();

            var success = StudentServices.Add(studentDto);

            if (success)
            {
                Console.WriteLine("Student added to database successfully.");
            }
            else
            {
                Console.WriteLine("Given student already exists in the database");
            }
            return true;
        }

        private bool AddCourse()
        {
            Console.Clear();

            var courseDto = new CourseDto();
            courseDto = ConsoleReadHelper.GetCourseData();
            var success = CourseServices.Add(courseDto);

            if (success)
            {
                Console.WriteLine("Course added to database successfully.");
                _choosenCourse = courseDto;
            }
            else
            {
                Console.WriteLine("Given course already exists in the database");
            }
            return true;
        }

        private bool UpdateCourse()
        {
            Console.Clear();

            if (_choosenCourse == null)
            {
                Console.WriteLine("There is no active course! Try 'change' ");
                return false;
            }

            var course = new CourseDto();
            Console.WriteLine("Please provide new course data:\n");
            course = ConsoleReadHelper.UpdateCourseData();
            var success = CourseServices.UpdateCourseData(_choosenCourse, course);

            if (success)
            {
                Console.WriteLine("Course data updated successfully.");
                //_choosenCourse = course;  //todo: test it;
            }
            else
            {
                Console.WriteLine("Something goes wrong.");
            }
            
            return true;
        }

        private bool ChangeActiveCourse()
        {
            Console.Clear();
            if (CourseServices.GetCourseCount() == 0)
            {
                Console.WriteLine("You need to create course first!");
                return false;
            }

            _choosenCourse = ChooseFromList.CourseFromList(CourseServices.GetAll());
            return true;
        }

        private bool SignInStudentOnCourse()
        {
            Console.Clear();

            if (_choosenCourse == null)
            {
                Console.WriteLine("There is no active course! Try 'change' ");
                return false;
            }

            var studentOnCourse = new StudentOnCourseDto();

            studentOnCourse.Course = _choosenCourse;
            studentOnCourse.Student = ChooseFromList.StudentFromList(StudentServices.GetAll());

            if (!StudentOnCourseServices.Exist(studentOnCourse))
            {
                var success = StudentOnCourseServices.AddStudentToCourse(studentOnCourse);

                if (success)
                {
                    Console.WriteLine("Student sign in to course successfully.");
                }
                else
                {
                    Console.WriteLine("Something goes wrong...");
                }
            }
            else
            {
                Console.WriteLine("Choosen student already attend to this course.");
            }

            Console.WriteLine($"\n{studentOnCourse.Student.Pesel} attend on {studentOnCourse.Course.Name}");  //temp

            return true;
        }

        private bool SignOutStudentFromCourse()
        {
            Console.Clear();
            
            if (_choosenCourse == null)
            {
                Console.WriteLine("There is no active course! Try 'change' ");
                return false;
            }

            var studentOnCourse = new StudentOnCourseDto();

            studentOnCourse.Course = _choosenCourse;
            studentOnCourse = ChooseFromList.StudentOnCourseList(StudentOnCourseServices
                .StudentsListOnCourse(studentOnCourse.Course));

            var success = StudentOnCourseServices.RemoveStudentFromCourse(studentOnCourse);
            
            if (success)
            {
                Console.WriteLine("Student sign out from course successfully.");
            }
            else
            {
                Console.WriteLine("Something goes wrong...");
            }

            return true;
        }

        private bool UpdateStudent()
        {
            Console.Clear();

            var student = new StudentDto();
            Console.WriteLine("Please student you want update: \n");
            student = ChooseFromList.StudentFromList(StudentServices.GetAll());
            
            if (student == null)
            {
                Console.WriteLine("Something goes wrong...");
                return false;
            }

            
            Console.WriteLine("Please provide new student data:\n");
            var newStudent = new StudentDto();
            newStudent = ConsoleReadHelper.UpdateStudentData();
            var success = StudentServices.UpdateStudentData(student, newStudent);

            if (success)
            {
                Console.WriteLine("Student data updated successfully.");
            }
            else
            {
                Console.WriteLine("Something goes wrong.");
            }

            return true;

        }

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

            var studentOnCourseList = StudentOnCourseServices
                .StudentsListOnCourse(studentOnCourse.Course);

            var success = true;

            foreach (var student in studentOnCourseList)
            {
                
                var courseDay = new CourseDayDto()
                {
                    StudentOnCourse = student,
                };
                
                courseDay.Attendance = ConsoleReadHelper.GetStudentAttendance(student.Student);

                success &= CourseDayServices.Add(courseDay);
            }

            if (success)
            {
                Console.WriteLine("\nChecking attendance of all students completed succesfully!");
            }
            else
            {
                Console.WriteLine("Something goes wrong...");
            }


            return true;
        }

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

            var studentOnCourseList = StudentOnCourseServices
                .StudentsListOnCourse(studentOnCourse.Course);

            var maxHomeworkPoints = ConsoleReadHelper.GetIntInRange("Please provide homework max points", 0, 1000);

            var success = true;

            foreach (var student in studentOnCourseList)
            {

                var homework = new HomeworkDto()
                {
                    StudentOnCourse = student,
                };

                homework.MaxPoints = maxHomeworkPoints;
                homework.StudentPoints = ConsoleReadHelper.GetStudentHomework(student.Student,maxHomeworkPoints);

                success &= HomeworkServices.Add(homework);
            }

            if (success)
            {
                Console.WriteLine("\nChecking homework of all students completed succesfully!");
            }
            else
            {
                Console.WriteLine("Something goes wrong...");
            }


            return true;
        }

        private bool PrintReport()  //
        {
            Console.Clear();

            var studentOnCourse = new StudentOnCourseDto();
            studentOnCourse.Course = _choosenCourse;

            if (_choosenCourse == null)
            {
                Console.WriteLine("There is no active course! Try 'change' ");

                if (StudentServices.StudentsCount() != 0) 
                {
                    Console.WriteLine("\nPrinting just avaible students list:\n");

                    var studentsList = StudentServices.GetAll();
                    foreach (var student in studentsList)
                    {
                        Console.WriteLine($"{student.Name} {student.Surname} PESEL:{student.Pesel}");
                    }
                }
                return false;
            }

            //*******************Drukowanie raportu**********************
            
            ReportHelper.GetCourseReport(studentOnCourse.Course);

            var studentOnCourseList = StudentOnCourseServices
                .StudentsListOnCourse(studentOnCourse.Course);

            //ConsoleWriteHelper.PrintOrderedList(studentOnCourseList);
            
            ReportHelper.GetHomeworkReport(studentOnCourseList);
            ReportHelper.GetAttendanceReport(studentOnCourseList);

            

            return true;
        }

        private bool Clear()
        {
            Console.Clear();
            return true;
        }

        private void Exit()
        {
            Console.WriteLine($"\n\nYou used {_zjv} commands :) ");
            Console.WriteLine("Bye, bye!");
            Console.ReadKey();
        }

        private void Action(bool zjv)
        {
            _zjv++;
        }
    }//class
}
