using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MSJournal_Data;
using MSJournal_Data.Models;

namespace MSJournal_Business.Services
{
    public class Journal
    {
        

        public Course ActiveCourse()
        {
            if (Dane.Journal.Count != 0)
            {
                return Dane.Journal[Course.ChoosenCourse];
            }
            else
            {
                Console.WriteLine("There is no course in journal");
                return null;
            }
        }  //return choosen course

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
            foreach (int courseId in Dane.Journal.Keys)
            {
                if (courseId == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void ChangeActiveCourse()
        {   //warunki zakładają, że nie będzie kasowany żaden kurs w dzienniku
            SetActiveCourse(
            GetInt("Please enter the course number you wish to switch to"
                   ,0,Course.CourseCounter()));
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
            Course course = new Course();
            Dane.Journal.Add(course.Id,course);
            SetActiveCourse(course.Id);
            GetJournalData(course);
            AddStudentsToCourse(course, Dane.StudentsList);
        }

        public void GetJournalData(Course course)
        {//getting basic journal data
            ClearJournalData(course);

            try
            {
                Console.WriteLine("Please provide the following fields.");
                Console.Write("Course name: ");
                course.Name = Console.ReadLine();
                Console.Write("Course leader name: ");
                course.LeaderName = Console.ReadLine();
                Console.Write("Course leader surname: ");
                course.CourseLeaderSurname = Console.ReadLine();

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
                    if (course.StudentsNumber > 0 && course.StudentsNumber <= Dane.StudentsList.Count)
                    {
                        studentsOk = true;
                    }
                    else
                    {
                        Console.Write("Number of students should be between <1 - {0}>: ", Dane.StudentsList.Count);
                    }

                } while (!studentsOk);

                course.SetCourseCreated();
            }//try

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

        public void AddStudentsToCourse(Course course, Dictionary<int, Student> studentsDictionary)
        {//adding students to course in order of number of students in course given
            
            int i = 1;

            if (course.CourseCreatedStatus())
            {
                while (i <= course.StudentsNumber && i <= studentsDictionary.Count)
                {     //pobieraj tak długo aż będzie dość studentów lub się skończą
                    Console.Write("Please enter student ID: ");
                    int id = Int32.Parse(Console.ReadLine());
                    //TODO użyć funkcji GetInt(message...

                    if (studentsDictionary.ContainsKey(id))
                    {
                        if (!course.CourseStudentsList.ContainsKey(id))
                        {
                            var student = studentsDictionary[id];
                            course.CourseStudentsList[student.Id] = student;  //przypisanie studenta na kurs
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Student already attend to course!");
                        }
                        }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                }
                course.SetCourseActive();  //po dodaniu wszystkich kursantów może działać
            }
        }
        
        public void AddStudentToList()
        {//getting student data
            
            try
            {
                Student student = new Student();
                Console.Write("Enter student unique ID: ");
                int identifier = Int32.Parse(Console.ReadLine());

                if (!Dane.StudentsList.ContainsKey(identifier))
                {
                    student.Id = identifier;
                    Console.Write("Enter {0} student name: ", identifier);
                    student.Name = Console.ReadLine();
                    Console.Write("Enter {0} student surname: ", identifier);
                    student.Surname = Console.ReadLine();
                    Console.Write("Enter {0} student birth date: ", identifier);
                    student.BirthDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter {0} student gender(male/female): ", identifier);
                    student.Gender = (Student.GenderType)Enum.Parse(typeof(Student.GenderType), Console.ReadLine());

                    Dane.StudentsList[student.Id] = student; //adding student to Dictionary
                }
                else
                {
                    Console.WriteLine("Student with ID:{0}, already exist in journal.",identifier);
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
                //throw;
            }
            //return identifier;
        }

        public void AddDayOfCourse()
        {
            if (Dane.Journal.Count != 0)
            {
                var course = new Course();
                course = ActiveCourse();

                if (course.CourseIsActive())
                {
                    course.NewCourseDay();   //tylko napis
                    foreach (var student in course.CourseStudentsList)
                    {
                        CourseDay courseDay = new CourseDay(student.Value);
                        student.Value.AttendanceList.Add(courseDay);
                    }
                    course.IncreaseClasesDaysNumber();  //statsy
                }
            }
            else
            {
                Console.WriteLine("Could not add day of course if there is no course!");
            }
        }

        public void AddHomework()
        {
            if (Dane.Journal.Count != 0)
            {
                var course = new Course();
                course = ActiveCourse();


                if (course.CourseIsActive())
                {
                    course.NewHomework(); //setting max points value
                    foreach (var student in course.CourseStudentsList)
                    {
                        Homework homework = new Homework(student.Value, course.MaxHomeworkPoints);
                        student.Value.HomeworksList.Add(homework);
                    }
                    course.IncreaseHomeworksNumber(); //some stats... lepiej z ilości w liście?
                }
            }
            else
            {
                Console.WriteLine("Could not add homework if there is no course!");
            }
        }

        //******************Some MAIN functions********************************
       

        public void ClearJournalData(Course course)
        {
            course.Name = "";
            course.LeaderName = "";
            course.CourseLeaderSurname = "";
            course.StartDate = DateTime.Parse("1 / 1 / 1000");
            course.PresenceThreshold = 1;
            course.HomeworkThreshold = 1;
            course.StudentsNumber = 1;

            course.CourseStudentsList.Clear();
            course.ResetCourseActive();
            course.ResetCourseCreated();
        }

        //******************Printing report starts here************************
        public void PrintReport()
        {
            Console.Clear();
            //Console.WriteLine(Course.ChoosenCourse);  /temp
            //Console.WriteLine(course.Id);
            if (Dane.Journal.Count != 0)
            {
                var course = new Course();
                course = ActiveCourse();

                if (course.CourseIsActive())
                {
                    PrintCourseInfo(course);
                    PrintAttendance(course);
                    PrintHomework(course);
                    
                    if (course.NumberOfHomeworks == 0 && course.NumberOfClasesDays == 0)
                    {
                        PrintStudentsOnCourse(course);  //prints only if no days and no homeworks
                    }
                    Console.WriteLine("\n\n");
                }
                else
                {
                    Console.WriteLine("\nThere is nothing to print...");
                }
            }
            else
            {
                Console.WriteLine("There is no course in journal...");

                if (Dane.StudentsList.Count != 0)
                {
                PrintStudentList(Dane.StudentsList);
                }
                else
                {
                    Console.WriteLine("...and there is no students added :(");
                }

            }
        }

        public void PrintCourseInfo(Course course)
        {
            Console.WriteLine("COURSE REPORT \n\nCourse name: {0}", course.Name);
            Console.WriteLine("Course start date: {0}.", course.StartDate);
            Console.WriteLine("Course leader: {0} {1}", course.LeaderName, course.CourseLeaderSurname);
            Console.WriteLine("Course presence threshold: {0}%", course.PresenceThreshold);
            Console.WriteLine("Course homework threshold: {0}%", course.HomeworkThreshold);
        }

        public bool CheckStudentAttendence(Course course, Student student)
        {
            int presentDays = 0;
            
            foreach (var day in student.AttendanceList)
            {
                if (day.Attendance == CourseDay.AttendanceOnCourse.present ||
                    day.Attendance == CourseDay.AttendanceOnCourse.p)
                {
                    presentDays++;
                }
            }
            int studentAttendance = 100 * presentDays / student.AttendanceList.Count;
            student.PresentDays = presentDays;
            student.StudentAttendance = studentAttendance;

            if (studentAttendance >= course.PresenceThreshold)
                return true;
            return false;
        }

        public void PrintAttendance(Course course)
        {
            Console.WriteLine("\nDuring the course, there were {0} classes.", course.NumberOfClasesDays);

            if (course.NumberOfClasesDays != 0)
            {
                foreach (var student in course.CourseStudentsList.Values)
                {
                    string result;
                    if (CheckStudentAttendence(ActiveCourse(), student))
                    {
                        result = "passed";
                    }
                    else
                    {
                        result = "not passed";
                    }

                    Console.WriteLine("Student {0} {1} gets {2}/{3} ({4}%) - " + result,
                        student.Name, student.Surname, student.PresentDays, student.AttendanceList.Count,
                        Convert.ToInt32(student.StudentAttendance));
                }
            }

        }

        public bool CheckStudentHomework(Course course, Student student)
        {
            int homeworkMaxPoints = 0;
            int homeworkPoints = 0;

            foreach (var homework in student.HomeworksList)
            {
                homeworkMaxPoints += homework.MaxHomeworkPoints;
                homeworkPoints += homework.StudentHomeworkPoints;
            }

            double homeworkPerformance = 100 * homeworkPoints / homeworkMaxPoints;
            student.HomeworkPoints = homeworkPoints;
            student.HomeworkMaxPoints = homeworkMaxPoints;
            student.HomeworkPerformance = homeworkPerformance;
            if (homeworkPerformance >= course.HomeworkThreshold)
                return true;
            return false;
        }

        public void PrintHomework(Course course)
        {
            Console.WriteLine("\nDuring the course, there were {0} homeworks.", course.NumberOfHomeworks);

            if (course.NumberOfHomeworks != 0)
            {
                foreach (var student in course.CourseStudentsList.Values)
                {
                    string result;
                    if (CheckStudentHomework(ActiveCourse(), student))
                    {
                        result = "passed";
                    }
                    else
                    {
                        result = "not passed";
                    }

                    Console.WriteLine("Student {0} {1} gets {2}/{3} ({4}%) - " + result,
                        student.Name, student.Surname, student.HomeworkPoints, student.HomeworkMaxPoints,
                        Convert.ToInt32(student.HomeworkPerformance));
                }
            }
        }

        public void PrintStudentList(Dictionary<int, Student> studentList)
        {
            Console.WriteLine("\nPrinting just student list:");
            foreach (var student in studentList.Values)
            {
                Console.WriteLine("{0}. {1} {2}",
                    student.Id, student.Name, student.Surname);
            }
        }

        public void PrintStudentsOnCourse(Course course)
        {
            Console.WriteLine("\n{0} students attend to this course:\n", course.StudentsNumber);
            foreach (var student in course.CourseStudentsList.Values)
            {
                Console.WriteLine("{0}. {1} {2}",
                    student.Id, student.Name, student.Surname);
            }
        }
        
        //******************Sample data starts here****************************
        public void SampleFullData(int students)
        {
            var course = new Course();
            Dane.Journal.Add(course.Id, course);
            
            SampleYournal(course, students);
            SampleStudentsData(Dane.StudentsList, course.StudentsNumber);  //źródło Kowalskich
            AddStudentsToCourse(course,Dane.StudentsList);
            course.SetCourseActive();
            Console.WriteLine("\nSample journal loaded succesfully!");
        }

        public void SampleStudentsData(Dictionary<int, Student> studentList, int x)
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

                studentList[student.Id] = student;
            }
        }

        public void SampleYournal(Course course, int x)
        {
            course.Name = "Codementors";
            course.LeaderName = "Kuba";
            course.CourseLeaderSurname = "Bulczak";
            course.StartDate = DateTime.Parse("4 / 24 / 2017");
            course.PresenceThreshold = 70;
            course.HomeworkThreshold = 80;
            course.StudentsNumber = x;
            course.SetCourseCreated();
        }

    }
}
