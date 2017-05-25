using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Services;
using CourseJournalMS.IoConsole;

namespace CourseJournalMS
{
    class ProgramLoop
    {
        //Journal journal = new Journal();

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
            var journal = new Journal();
            
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
                        journal.AddStudentToList();
                    }
                        break;
                    case CommandTypes.create:
                    {
                        journal.CreateNewCourse();
                    }
                        break;
                    case CommandTypes.sample:
                    {
                        journal.SampleFullData(5);
                    }
                        break;
                    case CommandTypes.change:
                    {
                        journal.ChangeActiveCourse();
                    }
                        break;

                    case CommandTypes.addday:
                    {
                        journal.AddDayOfCourse();
                    }
                        break;
                    case CommandTypes.addhome:
                    {
                        journal.AddHomework();
                    }
                        break;
                    case CommandTypes.print:
                    {
                        journal.PrintReport();
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
    }//class
}
