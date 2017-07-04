using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;

namespace CourseJournalMS.Events
{
    class JournalDelegates
    {
        public delegate void ReportGeneratedEventHandler(object sender, ReportDto args);
    }
}
