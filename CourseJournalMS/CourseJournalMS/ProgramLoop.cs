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
       // private CourseDto _choosenCourse;

        public void Run()
        {
            SwitchCommand();
        }

        public enum CommandTypes
        {
            none,
            add,
            sample,
            create,
            change,
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
                    case CommandTypes.sample:
                    {
                        SampleFullData();
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
            }
            else
            {
                Console.WriteLine("Given course already exists in the database");
            }

        }

        private void ChangeActiveCourse()
        {
            Console.Clear();


        }

        private void SampleFullData()
        {
            Console.Clear();

        }

        

        private void AddDayOfCourse()
        {
            Console.Clear();

        }

        private void AddHomeworkToCourse()
        {
            Console.Clear();

        }

        private void PrintReport()  //
        {
            Console.Clear();

        }
    }//class
}
