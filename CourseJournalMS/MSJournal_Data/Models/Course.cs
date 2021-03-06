﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSJournal_Data.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LeaderName { get; set; }
        public string LeaderSurname { get; set; }
        public DateTime StartDate { get; set; }
        public double HomeworkThreshold { get; set; }
        public double PresenceThreshold { get; set; }
        public int StudentsNumber { get; set; }

        public List<StudentOnCourse> StudentOnCourse { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var course = obj as Course;
            bool equal = true;

            equal &= course.Id == Id;
            equal &= course.Name == Name;
            equal &= course.LeaderName == LeaderName;
            equal &= course.LeaderSurname == LeaderSurname;
            equal &= course.HomeworkThreshold == HomeworkThreshold;
            equal &= course.PresenceThreshold == PresenceThreshold;
            equal &= course.StartDate == StartDate;

            return equal;
        }

        
    }
}
