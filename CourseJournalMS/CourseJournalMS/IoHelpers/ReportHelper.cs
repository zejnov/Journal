using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseJournalMS.IoConsole;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Business.Services;
using MSJournal_Business.Services.ServicesInterfaces;
using MSJournal_Data.SaveToFileMappers;
using MSJournal_Data.SaveToFileRepository;
using Ninject;

namespace CourseJournalMS
{
    public class ReportHelper
    {
        //klasa powinna znajdywać się raczej w serwisach, ale wtedy nie mam dostępu do console helpersów

        private CourseDto _choosenCourse;
        private ReportDto _report { get; set; }

        private readonly ICourseDayServices _courseDayServices;
        private readonly IHomeworkServices _homeworkServices;
        private readonly IStudentOnCourseServices _studentOnCourseServices;

        [Inject]
        public ReportHelper(ICourseDayServices courseDayServices,
            IHomeworkServices homeworkServices, IStudentOnCourseServices studentOnCourseServices)
        {
            _courseDayServices = courseDayServices;
            _homeworkServices = homeworkServices;
            _studentOnCourseServices = studentOnCourseServices;
        }

        public ReportDto GetGeneratedReport()
        {
            return _report;
        }

        public bool ExportReportToFile()
        {
            if (ExportToFile())
            {
                var repository = new JsonFilesRepository(new JsonMapper());

                string filePath = @"c:\pliki\";
                string fileName = $"{_report.Course.Name }_report.json";

                repository.SaveToFile($"{filePath}{fileName}", DtoToEntity.ReportDtoToEntity(_report));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ExportReportToFile(ReportDto report)
        {
            if (ExportToFile())
            {
                var repository = new JsonFilesRepository(new JsonMapper());

                string filePath = @"c:\pliki\";
                string fileName = $"{report.Course.Name }_report.json";

                repository.SaveToFile($"{filePath}{fileName}", DtoToEntity.ReportDtoToEntity(report));
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// asking user if to export
        /// </summary>
        /// <returns></returns>
        private bool ExportToFile()
        {
           return ConsoleReadHelper.GetApproval("export report to file");
        }

        /// <summary>
        /// generating report for choosen course
        /// </summary>
        /// <returns></returns>
        public bool GenerateReport(CourseDto course)
        {
            _choosenCourse = course;

            _report = new ReportDto();
            _report.Course = _choosenCourse;

           var studentList = _studentOnCourseServices
                .StudentsListOnCourse(_choosenCourse);

            if (studentList.Count != 0)
            {
                foreach (var student in studentList)
                {
                    _studentOnCourseServices.CheckAttendance
                        (student, _courseDayServices.GetAttendance(student));
                    _studentOnCourseServices.CheckHomework
                        (student, _homeworkServices.GetHomework(student));

                    _report.CourseStudentList.Add(student);
                }
            }

            return true;
        }

        /// <summary>
        /// printing generated report
        /// </summary>
        /// <returns></returns>
        public bool PrintReport()
        {
            Console.WriteLine("COURSE REPORT \n");
            ConsoleWriteHelper.PrintCourseData(_choosenCourse);
            ConsoleWriteHelper.PrintResults(_report.CourseStudentList);
            Console.WriteLine($"\nTimestamp of generation: {_report.TimeOfGeneration}");
            

            return true;
        }
        
        /// <summary>
        /// printing course basic data
        /// </summary>
        /// <param name="course">course to print</param>
        public bool GetCourseReport()
        {
            Console.WriteLine("COURSE REPORT \n");
            ConsoleWriteHelper.PrintCourseData(_choosenCourse);
            return true;
        }

        /// <summary>
        /// printing students list in journal
        /// </summary>
        public bool IfNoCourse()
        {
            Console.WriteLine("There is no active course! Try 'change' ");
            var studentServices = new StudentServices();

            if (studentServices.StudentsCount() != 0)
            {
                Console.WriteLine("\nPrinting just avaible students list:\n");

                var studentsList = studentServices.GetAll();
                var ordinal = 1;
                foreach (var student in studentsList)
                {
                    Console.WriteLine($"{ordinal++}. {student.Name} {student.Surname} PESEL:{student.Pesel}");
                }
            }
            Console.ReadKey();
            return true;
        }
    }
}
