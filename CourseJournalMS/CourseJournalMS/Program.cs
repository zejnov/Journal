using System;
using System.Security.Cryptography.X509Certificates;

namespace CourseJournalMS
{
    class Program:Functions   
    {
        private static Journal _CodementorsJournal = new Journal();
        
        static void Main(string[] args)
        {
        // Creatin new Journal and getting data 
            //GetJournalData(_CodementorsJournal);
            SampleYournal(_CodementorsJournal);         //temp

            GetStudentsData(_CodementorsJournal.CourseStudentsNumber,_CodementorsJournal.CourseStudentsList);
        //**************************************
        // Add a new day of course
            int courseDayNumber = 0;
            courseDayNumber = AddDayOfCourse(_CodementorsJournal, courseDayNumber);
            courseDayNumber = AddDayOfCourse(_CodementorsJournal, courseDayNumber);

            Console.WriteLine("Dni kursu minęło: " + courseDayNumber);       //temp
        //************************************** 
        // Add a homework
            

        //************************************** 
        // Print summary
            

        //************************************** 
            
            Console.WriteLine("Witaj!00");  //temp
            Console.ReadKey();              //temp
        }
    }
}




/*
        Pamiętać:
        Funkcja ma przypisywać dane do journala!!

        Dodać "TRY" przy wczytywaniu danych




 */