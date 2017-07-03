using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseJournalMS.IoConsole;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Business.Services;
using MSJournal_Data.SaveToFileMappers;
using MSJournal_Data.SaveToFileRepository;

namespace CourseJournalMS
{
    public class ReportHelper
    {
        //klasa powinna znajdywać się raczej w serwisach, ale wtedy nie mam dostępu do console helpersów

        private readonly CourseDto _choosenCourse;
        private ReportDto _report { get; set; }

        public ReportHelper(CourseDto course)
        {
            _choosenCourse = course;
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
        public bool GenerateReport()
        {
            _report = new ReportDto();
            _report.Course = _choosenCourse;

            var studentOnCourseServices = new StudentOnCourseServices();
            var courseDayServices = new CourseDayServices();
            var homeworkServices = new HomeworkServices();
            
            var studentList = studentOnCourseServices
                .StudentsListOnCourse(_choosenCourse);

            if (studentList.Count != 0)
            {
                foreach (var student in studentList)
                {
                    studentOnCourseServices.CheckAttendance
                        (student, courseDayServices.GetAttendance(student));
                    studentOnCourseServices.CheckHomework
                        (student, homeworkServices.GetHomework(student));

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
