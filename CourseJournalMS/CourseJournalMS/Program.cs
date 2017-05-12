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
            SampleFullData(CodementorsJournal,4); //temp
        
            while (Working)
            {
                    Console.WriteLine("\n(create / sample / addday / addhome / print / clear / exit / help)");
                    Console.Write("Please enter the name of the action: ");
                try
                {
                    SwitchCommand(GetCommandFromUser());
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
                    Console.WriteLine("Some unexpected error occured!");
                    throw;
                }
            }//while Working
            //*****************TEMP********************* 
        }
    }
}

/*
        Pamiętać opcjonalnie:
        
        Czy pytać na wejsciu czy nowy czy sample?
        Zostawićdomyślny sample, czy nie?
        Jeśli nie to blokada:
        dodania dnia
        pracy domowej
        drukowania raportu
        w przypadku braku studentów / nie stworzenia dziennika.....<<<<<======




 */