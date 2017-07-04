using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseJournalMS.Commands
{
    public class CommandTemplate
    {
        public string Command { get; private set; }
        private readonly Func<bool> _action;

        public CommandTemplate(string command, Func<bool> action)
        {
            Command = command;
           _action = action;
        }

        public bool ExecuteCommand()
        {
            return _action();
        }

    }
}
