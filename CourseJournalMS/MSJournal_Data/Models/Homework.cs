using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Data.Models
{
    public class Homework
    {
        public int Id { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
        public int StudentPoints { get; set; }
        public int MaxPoints { get; set; }
    }
}
