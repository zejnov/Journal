using System;
using System.Security.Cryptography.X509Certificates;

namespace CourseJournalMS
{
    public class Program:Functions   
    {
        public static Journal CodementorsJournal = new Journal();
        public static bool Working = true;
        
        static void Main(string[] args)
        {
            while (Working)
            {
                    Console.WriteLine("\n(create / sample / addday / addhome / print / clear / exit / help)");
                    Console.Write("Please enter the name of the action: ");
                SwitchCommand(GetCommandFromUser());
                
            }//while Working
        }
    }
}

/*
        Blokada:
        dodania dnia
        pracy domowej
        drukowania raportu
             w przypadku braku studentów / nie stworzeniu dziennika...
 */