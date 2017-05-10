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
            //GetStudentsData(_CodementorsJournal);
            SampleFullData(_CodementorsJournal,4);
        //**************************************
        // Add a new day of course
            
            AddDayOfCourse(_CodementorsJournal);
            
            
                                                       //temp
        //************************************** 
        // Add a homework
            AddHomework(_CodementorsJournal);

            
        //************************************** 
        // Print summary
            Console.WriteLine("Testttt");
            Console.WriteLine(CourseDay.DaysOfCourse());
            Console.WriteLine(Homework.NumberOfHomeworks());


            

        //*****************TEMP********************* 
            
            Console.WriteLine("Witaj!00");  //temp
            Console.ReadKey();              //temp
        }
    }
}




/*
        Pamiętać:
        Zrobić drukowanie raportu
        (brak list i prac, tylko lista osób)
        
        Zrobić Main SWITCH
        Dodać "TRY" przy wczytywaniu danych WSZYSTKICH!




 */