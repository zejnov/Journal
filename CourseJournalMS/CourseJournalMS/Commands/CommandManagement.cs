using System;
using System.Collections.Generic;

namespace CourseJournalMS.Commands
{
    public class CommandManagement
    {

        private List<CommandTemplate> _journalCommands = new List<CommandTemplate>();
        

        private CommandTemplate GetCommand(string command)
        {
            return _journalCommands.Find(p => p.Command == command);
        }

        public bool Manage(string command)
        {
            var commandAction = GetCommand(command);

            if (commandAction != null)
                return commandAction.ExecuteCommand();

            return false;
        }

        public bool AddCommand(string command, Func<bool> action)
        {
            if (CommandExist(command))
                return false;

            _journalCommands.Add(new CommandTemplate(command, action));
            return true;
        }

        public bool CommandExist(string command)
        {
            return (GetCommand(command) != null);
        }
    }
}
