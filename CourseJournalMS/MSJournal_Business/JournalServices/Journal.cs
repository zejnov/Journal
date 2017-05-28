using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business.Dtos;
using MSJournal_Data;
using MSJournal_Data.Models;
using MSJournal_Data.Repositories;
using MSJournal_Business.Mappers;

namespace MSJournal_Business.JournalServices
{
    public class Journal
    {

        public CourseDto GetActiveCourse()
        {
            if (EntityToDtoMapper.CourseListEntityToDto().Count != 0)
            {
                var courseRepository = new CourseRepository();
                var course = courseRepository.ActiveCourse();

                return EntityToDtoMapper.CourseEntityModelToDto(course);
            }
            else
            {
                Console.WriteLine("There is no course in journal...");
                return null;
            }
        }

        public Dictionary<int, StudentDto> GetAllStudentsList()
        {
            return EntityToDtoMapper.StudentListEntityModelToDto();
        }

        public Dictionary<int, CourseDto> GetAllCoursesList()
        {
            return EntityToDtoMapper.CourseListEntityToDto();
        }

        public void SetActiveCourse(int id)
        {
            if (CheckIdOfCourseExist(id))
            {
                Course.ChoosenCourse = id;
            }
            else
            {
                Console.WriteLine("There is no course with that ID");
            }
        }

        public bool CheckIdOfCourseExist(int id)
        {
            var journal = new Journal();
            var keys = journal.GetAllCoursesList().Keys;

            foreach (int courseId in keys)
            {
                if (courseId == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void ChangeActiveCourse()
        {
            //warunki zakładają, że nie będzie kasowany żaden kurs w dzienniku
            var journal = new Journal();
            var coursesCount = journal.GetAllCoursesList().Count;

            SetActiveCourse(
                GetInt("Please enter the course number you wish to switch to"
                    , 0, coursesCount));
        }

        //*******************GeTy
        public int GetInt(string message, int minValue, int maxValue)
        {
            int result = 0;
            bool parameterOk = false;
            Console.Write(message + " :");

            do
            {
                try
                {
                    result = Int32.Parse(Console.ReadLine());
                    if (result >= minValue && result <= maxValue)
                    {
                        parameterOk = true;
                    }
                    else
                    {
                        Console.Write("Number must be from range {0} to {1}: ", minValue, maxValue);
                    }
                }
                catch (Exception e)
                {
                    Console.Write("Bad data format, please try again: ");
                }
            } while (!parameterOk);
            return result;
        }

        //TODO GetDouble, GetData, GetString, Get...

        //******************Basic functionality********************************
        public void CreateNewCourse()
        {
            var course = new CourseDto();
            
            var courseService = new CourseService();
            courseService.GetCourseData(course);
            course.CourseIsCreated = true;

            var journalRepository = new JournalRepository();
            var newCourse = DtoToEntityMappers.CourseDtoToEntity(course);
            newCourse.SetCourseCreated();
            journalRepository.AddCourseToJournal(newCourse);

            courseService.AddStudentsToCourseList(course);
            course.CourseIsActive = true;
            SetActiveCourse(course.Id);
        }

        public void AddStudentToList() //Ok, można dodać twarde pętle o wprowadzenie
        {
            var journal = new Journal();
            try
            {
                var student = new StudentDto();
                Console.Write("Enter student unique ID: ");
                int identifier = Int32.Parse(Console.ReadLine());

                if (!journal.GetAllStudentsList().ContainsKey(identifier))
                {
                    student.Id = identifier;
                    Console.Write("Enter {0} student name: ", identifier);
                    student.Name = Console.ReadLine();
                    Console.Write("Enter {0} student surname: ", identifier);
                    student.Surname = Console.ReadLine();
                    Console.Write("Enter {0} student birth date: ", identifier);
                    student.BirthDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter {0} student gender(male/female): ", identifier);
                    student.Gender = (StudentDto.GenderType) Enum.
                        Parse(typeof(StudentDto.GenderType), Console.ReadLine());

                    var journalRepository = new JournalRepository();
                    journalRepository.AddStudentToJournalList(DtoToEntityMappers.StudentDtoToEntity(student));
                    
                }
                else
                {
                    Console.WriteLine("Student with ID:{0}, already exist in journal.", identifier);
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Bad data format, please try again...");
            }
            catch (OverflowException e)
            {
                Console.WriteLine("It is too big for this program, sorry.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Bad data format, please try again...");
            }
        }
      
        //******************Sample data starts here****************************
        public void SampleFullData(int students)
        {
            var course = new CourseDto();
            var courseService = new CourseService();
            
            SampleYournal(course, students);

            var journalRepository = new JournalRepository();
            var newCourse = DtoToEntityMappers.CourseDtoToEntity(course);
            newCourse.SetCourseCreated();
            
            journalRepository.AddCourseToJournal(newCourse);

            SampleStudentsData(course.StudentsNumber);  //źródło Kowalskich
            courseService.AddStudentsToCourseList(course);
            
            course.CourseIsActive = true;
            Console.WriteLine("\nSample journal loaded succesfully!");
        }

        private void SampleStudentsData(int x)
        {
            int id = 0;

            for (int i = 1; i <= x; i++)
            {
                id = i;
                if (Dane.StudentsList.ContainsKey(id))
                {
                    do
                    {
                        id++;
                    } while (Dane.StudentsList.ContainsKey(id));
                }

                Student student = new Student();
                student.Id = id;
                student.Name = "Student" + id;
                student.Surname = "Kowalski" + 2 * id;
                student.BirthDate = DateTime.Parse("7/12/1984");
                student.Gender = Student.GenderType.male;

                var journalRepository = new JournalRepository();
                journalRepository.AddStudentToJournalList(student);
            }
        }

        private void SampleYournal(CourseDto course, int x)
        {
            course.Name = "Codementors";
            course.LeaderName = "Kuba";
            course.LeaderSurname = "Bulczak";
            course.StartDate = DateTime.Parse("4 / 24 / 2017");
            course.PresenceThreshold = 70;
            course.HomeworkThreshold = 80;
            course.StudentsNumber = x;
            course.CourseIsCreated = true;
        }

    }
}
