using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Business.Modules;
using Ninject;

namespace CourseJournalMS
{
    public class Program
    {
        private IKernel _container = new StandardKernel(new ServicesModule(), new RepositoriesModule());
        
        /// <summary>
        /// main program method
        /// </summary>
        public static void Main(string[] args)
        {
            new Program().Execute();
        }

        /// <summary>
        /// using container and starting program loop
        /// </summary>
        public void Execute()
        {
            var journal = _container.Get<ProgramLoop>();
            journal.ReportGenerated += SomeText;
            journal.ReportGenerated += ExportReportToJsonFile;
            journal.ReportGenerated += SomeText;

            journal.Run();
        }

        private void SomeText(object sender, ReportDto args)
        {
            Console.WriteLine("Działa event?!");
        }

        private void ExportReportToJsonFile(object sender, ReportDto args)
        {
            var report = _container.Get<ReportHelper>();
            report.ExportReportToFile(args);
        }
    }
}