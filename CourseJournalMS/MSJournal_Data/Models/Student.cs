using System;
using System.Collections.Generic;

namespace MSJournal_Data.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public long Pesel { get; set; }
    }
}
