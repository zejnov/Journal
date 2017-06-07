using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CourseJournalMS.IoConsole;
using MSJournal_Business.Dtos;
using MSJournal_Business.Services;
using MSJournal_Data;

namespace CourseJournalMS
{
    class ProgramLoop
    {
        //Journal journal = new Journal();
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
                        AddStudent();
                    }
                        break;
                    case CommandTypes.create:
                    {
                        AddCourse();
                    }
                        break;
                    case CommandTypes.update:
                    {
                        UpdateCourse();
                    }
                        break;
                    case CommandTypes.signin:
                    {
                        SignInStudentOnCourse();
                    }
                        break;
                    case CommandTypes.signout:
                    {
                        SignOutStudentFromCourse();
                    }
                        break;
                    case CommandTypes.updatestudent:
                    {
                        UpdateStudent();
                    }
                        break;
                    case CommandTypes.change:
                    {
                        ChangeActiveCourse();
                    }
                        break;

                    case CommandTypes.addday:
                    {
                         AddDayOfCourse();
                    }
                        break;
                    case CommandTypes.addhome:
                    {
                         AddHomeworkToCourse();
                    }
                        break;
                    case CommandTypes.print:
                    {
                        PrintReport();
                    }
                        break;
                    case CommandTypes.clear:
                    {
                        Console.Clear();
                    }
                        break;
                    case CommandTypes.exit:
                    {
                        exit = true;
                        Console.WriteLine("Bye, bye!");
                        Console.ReadKey();
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

        private void AddStudent()
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
        }

        private void AddCourse()
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
            }
            else
            {
                Console.WriteLine("Something goes wrong.");
            }
            
            return true;
        }

        private void ChangeActiveCourse()
        {
            Console.Clear();
            _choosenCourse = ChooseFromList.CourseFromList(CourseServices.GetAll());

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
                .GetCourseDataForReport(studentOnCourse.Course));

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

        private void AddDayOfCourse()
        {
            Console.Clear();
            //todo
        }

        private void AddHomeworkToCourse()
        {
            Console.Clear();
            //todo
        }

        private bool PrintReport()  //
        {
            Console.Clear();

            var studentOnCourse = new StudentOnCourseDto();
            
            studentOnCourse.Course = _choosenCourse;
            if (_choosenCourse == null)
            {
                Console.WriteLine("There is no active course! Try 'change' ");
                return false;
            }

            Console.WriteLine($"On {studentOnCourse.Course.Name} attends:");

            var studentOnCourseList = StudentOnCourseServices
                .GetCourseDataForReport(studentOnCourse.Course);
            
            foreach (var student in studentOnCourseList)
            {
                if (student.Course.Id == _choosenCourse.Id)
                {
                    Console.WriteLine($"{student.Student.Pesel}");
                }
            }

            return true;
        }
    }//class
}
