using System;

namespace CourseJournalMS
{
    class Program:Functions   
    {
        

        static void Main(string[] args)
        {
        // Creatin new Journal and getting data 
            Journal _CodementorsJournal = new Journal(); 
            _CodementorsJournal.CourseStudentsNumber = 2;  //temp
            GetJournalData(_CodementorsJournal);
            GetStudentsData(_CodementorsJournal.CourseStudentsNumber,_CodementorsJournal.CourseStudentsList);
        //**************************************
        // Add a new day of course
            

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
        Dodać "TRY" przy wczytywaniu danych




 */