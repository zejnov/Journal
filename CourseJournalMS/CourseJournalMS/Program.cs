using System;

namespace CourseJournalMS
{
    class Program:Functions   
    {
        private static Journal _CodementorsJournal = new Journal();

        static void Main(string[] args)
        {
        // Creatin new Journal and getting data 
          //  Journal _CodementorsJournal = new Journal(); 
            _CodementorsJournal.CourseStudentsNumber = 2;  //temp
            GetJournalData(_CodementorsJournal);
            GetStudentsData(_CodementorsJournal.CourseStudentsNumber,_CodementorsJournal.CourseStudentsList);
        //**************************************
        // Add a new day of course
            AddDayOfCourse(_CodementorsJournal);

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