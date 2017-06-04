using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MSJournal_Business.JournalServices;
using CourseJournalMS.IoConsole;
using MSJournal_Business.Dtos;
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
                        AddStudentToList();
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

        private void AddStudentToList()
        {
            var journal = new Journal();
            journal.AddStudentToList();
        }

        private void ChangeActiveCourse()
        {
            var journal = new Journal();
            journal.ChangeActiveCourse();
        }

        private void SampleFullData()
        {
            var journal = new Journal();
            journal.SampleFullData(5);
        }
        
        private void AddCourse()
        {
            var journal = new Journal();
            journal.CreateNewCourse();
        }

        private void AddDayOfCourse()
        {
            ConsoleWriteHelper.NewCourseDay();

            var courseService = new CourseService();
            courseService.AddDayOfCourse();
        }

        private void AddHomeworkToCourse()
        {
            Console.Write("Please provide the homework max points: ");
            var max = ConsoleReadHelper.GetInt(0, 1000);

            var courseService = new CourseService();
            courseService.AddHomeworkToCourse(max);
        }

        private void PrintReport()  //
        {
            var journal = new Journal();
            
            if (journal.GetAllCoursesList().Count != 0)
            {
                ConsoleWriteHelper.PrintCourseReport(journal.GetActiveCourse());
            }
            else
            {
                Console.WriteLine("There is no course in journal...");

                if (journal.GetAllStudentsList().Count != 0)
                {
                    ConsoleWriteHelper.PrintAllStudentsList();   
                }
                else
                {
                Console.WriteLine("...and there is no students added :(");

                }
            }

        }
    }//class
}
