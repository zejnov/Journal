using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Business;
using MSJournal_Business.Dtos;
using MSJournal_Business.Mappers;
using MSJournal_Data;
using MSJournal_Data.Models;
using MSJournal_Data.Repositories;

namespace MSJournal_Business.JournalServices
{
    public class CourseService
    {
        public void AddHomeworkToCourse(int maxHomeworkPoints)
        {
            var journal = new Journal();
            var course = journal.GetActiveCourse();

            if (journal.GetAllCoursesList().Count != 0)
            {
                foreach (var student in course.CourseStudentsListDto)
                {
                    var homework = new HomeworkDto();
                    homework.MaxHomeworkPoints = maxHomeworkPoints;
                    bool parameterOk = false;
                    
                    Console.Write("{0}. {1} {2} gets: ", student.Id, student.Name, student.Surname);
                    
                    do
                    {
                        try
                        {
                            var studentHomeworkPoints = Int32.Parse(Console.ReadLine());
                            if (studentHomeworkPoints >= 0 && homework.StudentHomeworkPoints <= maxHomeworkPoints)
                            {
                                parameterOk = true;
                                homework.StudentHomeworkPoints = studentHomeworkPoints;

                                var home = DtoToEntityMappers.HomeworkDtoToEntity(homework);

                                var courseRepository = new CourseRepository();
                                courseRepository.AddHomeworkToStudent(student.Id, home);
                            }
                            else if (homework.StudentHomeworkPoints > maxHomeworkPoints)
                            {
                                Console.Write("Student can not get more points than max, please try again: ");
                            }
                            else
                            {
                                Console.Write("Bad range of number, please try again: ");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.Write("Bad data format, please try again: ");
                        }
                        
                    } while (!parameterOk);


                }

            }
            else
            {
                Console.WriteLine("Could not add homework to course if there is no course!");
            }
        }

        public void AddDayOfCourse()
        {
            var journal = new Journal();
            var course = journal.GetActiveCourse();

            if (journal.GetAllCoursesList().Count != 0)
            {
                foreach (var student in course.CourseStudentsListDto)
                {
                    var courseDay = new CourseDayDto();
                    bool parameterOk = false;

                    Console.Write("{0}. {1} {2} is: ", student.Id, student.Name, student.Surname);
                    
                    do
                    {
                        try
                        {
                            var Attendance =(CourseDayDto.AttendanceOnCourse)Enum.
                                Parse(typeof(CourseDayDto.AttendanceOnCourse),
                                    Console.ReadLine());

                            if (Attendance != CourseDayDto.AttendanceOnCourse.none)
                            {
                                parameterOk = true;
                                var day = DtoToEntityMappers.CourseDayDtoToEntity(courseDay);

                                var courseRepository = new CourseRepository();
                                courseRepository.AddDayOfCourseToStudent(student.Id, day);
                            }
                            else
                            {
                                Console.Write("Bad entry, please try again: ");
                            }
                        }


                        catch (Exception e)
                        {
                            Console.Write("Bad entry, please try p(present) or a(absent): ");
                        }

                    } while (!parameterOk);
                }
                    
            }
            else
            {
                Console.WriteLine("Could not add day of course if there is no course!");
            }
        }//

        public void AddStudentsToCourseList(CourseDto course)
        {
            var journal = new Journal();
            

            int i = 1;
            if (course.CourseIsCreated)
            {
                while (i <= course.StudentsNumber && i <= journal.GetAllStudentsList().Count)
                {
                    var parameterOk = false;
                    int id=0;

                    do
                    {
                        Console.Write("Please enter student ID: ");

                        try
                        {
                            id = Int32.Parse(Console.ReadLine());
                            parameterOk = true;
                        }
                        catch (Exception e)
                        {
                            Console.Write("Bad data format, pleasy try again: ");
                        }
                    } while (!parameterOk);

                    if (journal.GetAllStudentsList().ContainsKey(id))
                    {
                        var courseRepository = new CourseRepository();
                        var student = new Student(){Id = id};
              
                        if (!courseRepository.ActiveCourse().CourseStudentsList.Contains(student))
                        {
                            courseRepository.AddStudentToCourseList(student.Id);
                            i++;
                        }
                        else
                        {
                            Console.Write("Student already on course!");
                        }
                    }
                    else
                    {
                        Console.Write("No such ID, pleasy try again: ");
                    }
                }
            }

        }

        public void GetCourseData(CourseDto course)
        {
            //getting basic journal data

            try
            {
                Console.WriteLine("Please provide the following fields.");
                Console.Write("Course name: ");
                course.Name = Console.ReadLine();
                Console.Write("Course leader name: ");
                course.LeaderName = Console.ReadLine();
                Console.Write("Course leader surname: ");
                course.LeaderSurname = Console.ReadLine();

                bool dateOk = false;
                bool presenceOk = false;
                bool homeworkOk = false;
                bool studentsOk = false;

                do
                {
                    try
                    {
                        Console.Write("Course start date (MM/DD/YYYY): ");
                        course.StartDate = DateTime.Parse(Console.ReadLine());
                        dateOk = true;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Bad data format, please try again: ");
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("It is too big for this program, please try again: ");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        Console.WriteLine("Some unexpected error occured!");
                    }
                } while (!dateOk);

                Console.Write("Presence threshold(%): ");
                do
                {
                    course.PresenceThreshold = Double.Parse((Console.ReadLine()));
                    if (course.PresenceThreshold >= 0 && course.PresenceThreshold <= 100)
                    {
                        presenceOk = true;
                    }
                    else
                    {
                        Console.Write("Parameter out of range (0-100%), try again: ");
                    }
                } while (!presenceOk);

                Console.Write("Homework threshold(%): ");
                do
                {
                    course.HomeworkThreshold = Double.Parse(Console.ReadLine());
                    if (course.HomeworkThreshold >= 0 && course.HomeworkThreshold <= 100)
                    {
                        homeworkOk = true;
                    }
                    else
                    {
                        Console.Write("Parameter out of range (0-100%), try again: ");
                    }
                } while (!homeworkOk);

                Console.Write("Number of students: ");
                do
                {
                    course.StudentsNumber = Int32.Parse(Console.ReadLine());
                    if (course.StudentsNumber >= 0 && course.StudentsNumber <= Dane.StudentsList.Count)
                    {
                        studentsOk = true;
                    }
                    else
                    {
                        Console.Write("Number of students should be between <1 - {0}>: ", Dane.StudentsList.Count);
                    }

                } while (!studentsOk);
            } //try

            catch (ArgumentException e)
            {
                Console.WriteLine("Bad command, please try again...");
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
                Console.WriteLine(e);
                Console.WriteLine("Unexpected error occured!");
            }

        }
    }
}
